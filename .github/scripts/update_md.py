import os
import re

# 환경 변수에서 추가된 파일 목록을 가져옴
def get_added_files():
    return os.getenv("ADDED_FILES", "").split()

# 파일 경로에서 문제 정보(난이도, 문제 번호, 확장자) 추출
def parse_problem_info(filepath):
    match = re.search(r"Baekjoon/([^/]+)/(\d+)\.(cpp|cs|md)$", filepath)
    return (match.group(1), match.group(2), match.group(3)) if match else (None, None, None)

# 문제 링크를 md 파일에서 수정
def update_problem_link(md_file, problem_number, ext, difficulty):
    found = False
    
    with open(md_file, 'r', encoding='utf-8') as file:
        lines = file.readlines()
    
    for i, line in enumerate(lines):
        if line.startswith(f'| {problem_number} '):
            found = True
            col_index = {'cpp': 3, 'cs': 4, 'md': 5}.get(ext)
            link_label = "Memo" if ext == "md" else "Code"
            link = f'[{link_label}](../Baekjoon/{difficulty}/{problem_number}.{ext})'
            cells = line.split('|')
            cells[col_index] = f' {link} '
            lines[i] = '|'.join(cells)
            break
    
    with open(md_file, 'w', encoding='utf-8') as file:
        file.writelines(lines)
    
    return found

# 진행률 바를 업데이트
def update_progress(md_file, ext):
    with open(md_file, 'r', encoding='utf-8') as file:
        content = file.read()

    total_match = re.search(r'# .+ - (\d+)', content)
    total_count = int(total_match.group(1)) if total_match else 0

    solved_count = sum(1 for line in content.split('\n') if '[Code]' in line)

    old_progress = r'!\[100%\]\(https://progress-bar.xyz/\d+/?.*?\)'
    new_progress = f'![100%](https://progress-bar.xyz/{solved_count}/?scale={total_count}&title=progress&width=500&color=babaca&suffix=/{total_count})'
    content = re.sub(old_progress, new_progress, content)
    
    with open(md_file, 'w', encoding='utf-8') as file:
        file.write(content)
    
    return total_count, solved_count

# README.md에서 진행률을 업데이트
def update_readme_progress(readme_file, progress_info):
    with open(readme_file, 'r', encoding='utf-8') as file:
        content = file.readlines()

    for i, line in enumerate(content):
        for filename, (total_count, solved_count) in progress_info.items():
            if f'{filename}' in line:
                old_progress = r'!\[100%\]\(https://progress-bar.xyz/\d+/?.*?\)'
                new_progress = f'![100%](https://progress-bar.xyz/{solved_count}/?scale={total_count}&title=progress&width=500&color=babaca&suffix=/{total_count})'
                line = re.sub(old_progress, new_progress, line)
                content[i] = line
                break
    
    with open(readme_file, 'w', encoding='utf-8') as file:
        file.writelines(content)


def main():
    added_files = get_added_files()

    progress_info = {}  # 파일명, 총문제수, 푼문제수 정보를 저장할 딕셔너리
    
    for file in added_files:
        difficulty, problem_number, ext = parse_problem_info(file)

        if not problem_number:
            continue
        
        for root, _, filenames in os.walk("Workbook"):
            for filename in filenames:
                if filename == "README.md":
                    continue
                md_file = os.path.join(root, filename)
                found = update_problem_link(md_file, problem_number, ext, difficulty)
                if found and ext != "md":
                    total_count, solved_count = update_progress(md_file, ext)
                    progress_info[filename] = (total_count, solved_count)
                    
    update_readme_progress("Workbook/README.md", progress_info)


if __name__ == "__main__":
    main()
