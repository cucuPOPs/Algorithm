[Back(메인으로)](/README.md)  

# githubAction 사용기

## 기능
문제파일이 push되면, 진행률을 업데이트하고, 목록에 링크를 만들고, 커밋되도록 하였다.

## 작업흐름
- `.github/workflows/update-md.yml` 파일이 push 트리거를 인식한다.
- `.github/scripts/update_md.py` 파일을 실행한다.

## 느낀점
- PAT(Personal Access Token)인증작업은 필요가 없었다.
- 파이썬 언어가 낯설었다.
- gpt는 아직...멍청했다.
- 이걸 열심히 하려던건 아닌데... 이젠진짜 알고리즘...해야겠다.

## TODO
- 새 문제집을 push하면, 이미 푼 문제들을 확인해서, 업데이트하는 작업이 필요할예정.