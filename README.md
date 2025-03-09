# Algorithm Study

알고리즘을 공부하고, 순간의 생각들을 기록...하는 레포입니다.

[문제집 링크](./Workbook/README.md)
```markdown
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
```


## 프로젝트 구조
```
📦 Root
 ┣ 📜 README.md
 ┣ 📜 .gitignore
 ┣ 📂백준
 ┃  ┣ 📂[난이도]
 ┃  ┃  ┣ 📜[문제번호].cs (코드)
 ┃  ┃  ┣ 📜[문제번호].cpp (코드)
 ┃  ┃  ┣ 📜[문제번호].md (회고록)
 ┣ 📂문제집
 ┃  ┣ 📜 README.md (모든 문제집)
 ┃  ┣ 📜 ...
```
## 작업과정
1. 코드를 작성한다.
2. cph 확장으로, 예제입출력을 통과한다.
3. 백준사이트에 코드를 제출한다.
   1. if 정답 then break;
   2. if 오답 then 재도전.
   3. if 모르겠다 then 구글링으로 공부한다.
      1. if 이제 알겠다 then 리마인드 항목에 ✔️남긴다.
      2. if 봐도 모르겠다 then 리마인드 항목에 ❓남기고 넘어간다.
4. 주석추가 및 코드정리후, push한다.
6. 필요시, 회고록을 기록한다. ( ex. 내풀이와 다른접근법, )

## 코드템플릿
빠른입출력을 위해, 15552번 코드를 기반으로 문제풀이를 시작. [링크](./Baekjoon/Bronze/15552.md)

## 개발환경
VSCode에디터와, cph 확장을 사용해, 백준사이트의 문제를 푼다.

### 사용언어
C++,  C#

### 사용된 확장
- .net install tool
- C#
- C# Dev Kit
- C/C++
- C/C++ Extension Pack
- C/C++ Themes
- Korean Language Pack for Visual Studio Code
- Competitive Programming Helper(cph)
- atom one dark theme
- Prettier - Code formatter


#### [C/C++] 확장 설정
- [F1] > [C/C++ 구성편집(UI)] > 컴파일러 경로 > C:/MinGW/bin/gcc.exe
- [F1] > [C/C++ 구성편집(UI)] > 컴파일러 경로 > windows-gcc-x64 선택


### VSCode 꿀팁
- [ Ctrl + , ] > Mouse Wheel Zoom 체크.
- [ Alt + Shift + F ] : 코드정렬.


### bits/stdc++.h 에러
[C:\MinGW\lib\gcc\mingw32\{버전}\include\c++\mingw32\bits]폴더에, [stdc++.h]파일을 만들고, 아래내용을 작성한다.
```
// C++ includes used for precompiling -*- C++ -*-

// Copyright (C) 2003-2016 Free Software Foundation, Inc.
//
// This file is part of the GNU ISO C++ Library.  This library is free
// software; you can redistribute it and/or modify it under the
// terms of the GNU General Public License as published by the
// Free Software Foundation; either version 3, or (at your option)
// any later version.

// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// Under Section 7 of GPL version 3, you are granted additional
// permissions described in the GCC Runtime Library Exception, version
// 3.1, as published by the Free Software Foundation.

// You should have received a copy of the GNU General Public License and
// a copy of the GCC Runtime Library Exception along with this program;
// see the files COPYING3 and COPYING.RUNTIME respectively.  If not, see
// <http://www.gnu.org/licenses/>.

/** @file stdc++.h
 *  This is an implementation file for a precompiled header.
 */

// 17.4.1.2 Headers

// C
#ifndef _GLIBCXX_NO_ASSERT
#include <cassert>
#endif
#include <cctype>
#include <cerrno>
#include <cfloat>
#include <ciso646>
#include <climits>
#include <clocale>
#include <cmath>
#include <csetjmp>
#include <csignal>
#include <cstdarg>
#include <cstddef>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <ctime>

#if __cplusplus >= 201103L
#include <ccomplex>
#include <cfenv>
#include <cinttypes>
#include <cstdalign>
#include <cstdbool>
#include <cstdint>
#include <ctgmath>
#include <cuchar>
#include <cwchar>
#include <cwctype>
#endif

// C++
#include <algorithm>
#include <bitset>
#include <complex>
#include <deque>
#include <exception>
#include <fstream>
#include <functional>
#include <iomanip>
#include <ios>
#include <iosfwd>
#include <iostream>
#include <istream>
#include <iterator>
#include <limits>
#include <list>
#include <locale>
#include <map>
#include <memory>
#include <new>
#include <numeric>
#include <ostream>
#include <queue>
#include <set>
#include <sstream>
#include <stack>
#include <stdexcept>
#include <streambuf>
#include <string>
#include <typeinfo>
#include <utility>
#include <valarray>
#include <vector>

#if __cplusplus >= 201103L
#include <array>
#include <atomic>
#include <chrono>
#include <codecvt>
#include <condition_variable>
#include <forward_list>
#include <future>
#include <initializer_list>
#include <mutex>
#include <random>
#include <ratio>
#include <regex>
#include <scoped_allocator>
#include <system_error>
#include <thread>
#include <tuple>
#include <typeindex>
#include <type_traits>
#include <unordered_map>
#include <unordered_set>
#endif

#if __cplusplus >= 201402L
#include <shared_mutex>
#endif

```