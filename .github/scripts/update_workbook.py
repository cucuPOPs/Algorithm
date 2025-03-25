import os
import re

BAEKJOON_DIR = "Baekjoon"
WORKBOOK_DIR = "Workbook"

# 📌 환경 변수에서 추가된 파일 목록을 가져옴
def get_added_files():
    return os.getenv("ADDED_FILES", "").split()

# 📌 Baekjoon 폴더에서 푼 문제 목록을 수집
def get_solved_problems():
    solved = {}  # {문제번호: {"cpp": "", "cs": "", "md": ""}}

    for root, _, files in os.walk(BAEKJOON_DIR):
        for file in files:
            match = re.match(r"(\d+)\.(cpp|cs|md)$", file)
            if match:
                problem_number, ext = match.groups()
                if problem_number not in solved:
                    solved[problem_number] = {"cpp": "", "cs": "", "md": ""}
                solved[problem_number][ext] = os.path.join(root, file)

    return solved

# 📌 문제집 Markdown 업데이트 (풀이 링크 추가 및 진행도 바 생성)
def update_workbook(md_file, solved_problems):
    with open(md_file, "r", encoding="utf-8") as file:
        lines = file.readlines()

    total_count = 0
    solved_count = 0
    updated_lines = []

    for line in lines:
        match = re.match(r"\|\s*(\d+)\s*\|", line)  # 문제 번호 추출
        if match:
            total_count += 1
            problem_number = match.group(1)

            if problem_number in solved_problems:
                solved_count += 1
                cpp_link = f'[Code]({solved_problems[problem_number]["cpp"]})' if solved_problems[problem_number]["cpp"] else " "
                cs_link = f'[Code]({solved_problems[problem_number]["cs"]})' if solved_problems[problem_number]["cs"] else " "
                md_link = f'[Memo]({solved_problems[problem_number]["md"]})' if solved_problems[problem_number]["md"] else " "

                columns = line.split("|")
                columns[3] = f" {cpp_link} "
                columns[4] = f" {cs_link} "
                columns[5] = f" {md_link} "
                line = "|".join(columns)

        updated_lines.append(line)

    # 📌 진행도 바 업데이트
    progress_bar = f"![100%](https://progress-bar.xyz/{solved_count}/?scale={total_count}&title=progress&width=500&color=babaca&suffix=/{total_count})"
    updated_lines = [re.sub(r"!\[100%\]\(https://progress-bar\.xyz/.*?\)", progress_bar, line) for line in updated_lines]

    with open(md_file, "w", encoding="utf-8") as file:
        file.writelines(updated_lines)

    return total_count, solved_count

# 📌 WorkBook/README.md 진행도 업데이트
def update_readme_progress(readme_file, progress_info):
    if not os.path.exists(readme_file):
        return  # README 파일이 없으면 종료

    with open(readme_file, "r", encoding="utf-8") as file:
        content = file.readlines()

    for i, line in enumerate(content):
        for filename, (total_count, solved_count) in progress_info.items():
            if filename in line:  # 문제집 파일명이 포함된 줄 찾기
                new_progress = f'![100%](https://progress-bar.xyz/{solved_count}/?scale={total_count}&title=progress&width=500&color=babaca&suffix=/{total_count})'
                content[i] = re.sub(r"!\[100%\]\(https://progress-bar\.xyz/.*?\)", new_progress, line)
                break  # 한 번 수정하면 루프 종료

    with open(readme_file, "w", encoding="utf-8") as file:
        file.writelines(content)

# 📌 메인 실행 함수
def main():
    solved_problems = get_solved_problems()
    added_files = get_added_files()  # README.md 제외
    progress_info = {}  # 문제집 진행도 저장 딕셔너리

    for md_file in added_files:
        total_count, solved_count = update_workbook(md_file, solved_problems)
        progress_info[os.path.basename(md_file)] = (total_count, solved_count)

    # WorkBook/README.md 진행도 업데이트
    update_readme_progress(os.path.join(WORKBOOK_DIR, "README.md"), progress_info)

if __name__ == "__main__":
    main()
