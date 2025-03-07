import os
import re

def get_added_files():
    print(os.getenv("ADDED_FILES", "").split())
    return os.getenv("ADDED_FILES", "").split()

# (난이도, 문제번호, 확장자)를 추출.
def extract_problem_info(filepath):
    match = re.search(r"백준/([^/]+)/(\d+)\.(cpp|cs|md)$", filepath)
    return (match.group(1), match.group(2), match.group(3)) if match else (None, None, None)

# 문제집md파일에, 문제번호를 찾아, 코드링크 추가하는작업.
def update_problem_links(md_file, problem_number, ext, difficulty):
    found = False
      
    with open(md_file, 'r', encoding='utf-8') as file:
        lines = file.readlines()
    
    for i, line in enumerate(lines):
        if line.startswith(f'| {problem_number} '):
            found = True
            col_index = {'cpp': 2, 'cs': 3, 'md': 4}.get(ext)
            link_label = "회고" if ext == "md" else "코드"
            link = f'[{link_label}](../백준/{difficulty}/{problem_number}.{ext})'
            cells = line.split('|')
            cells[col_index] = f' {link} '
            lines[i] = '|'.join(cells) + '\n'
            break
    
    with open(md_file, 'w', encoding='utf-8') as file:
        file.writelines(lines)
    
    return found

def update_progress(md_file, ext):
    with open(md_file, 'r', encoding='utf-8') as file:
        content = file.read()

    # 문제집의 첫줄에서 "# 제목 - 숫자" 패턴에서, totalCount를 추출.
    total_match = re.search(r'# .+ - (\d+)', content)
    total_count = int(total_match.group(1)) if total_match else 0

    # "[코드](../백준/" 패턴에 맞는 라인수를 카운트.
    solved_count = sum(1 for line in content.split('\n') if f'[코드](../백준/' in line and f'.{ext})' in line)
    
    progress_pattern = rf'!\[100%\]\(https://progress-bar.xyz/\d+.*title=progress.*\)'
    new_progress = f'![100%](https://progress-bar.xyz/{solved_count}/?scale={total_count}&title=progress&width=500&color=babaca&suffix=/{total_count})'
    content = re.sub(progress_pattern, new_progress, content)
    
    with open(md_file, 'w', encoding='utf-8') as file:
        file.write(content)

def main():
    added_files = get_added_files()
    
    for file in added_files:
        difficulty, problem_number, ext = extract_problem_info(file)
        if not problem_number:
            continue
        
        for root, _, filenames in os.walk("문제집"):
            for filename in filenames:
                if filename == "README.md":
                    continue
                md_file = os.path.join(root, filename)
                found = update_problem_links(md_file, problem_number, ext, difficulty)
                if found and ext != "md":
                    update_progress(md_file, ext)

if __name__ == "__main__":
    main()
