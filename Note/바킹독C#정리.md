[Back(메인으로)](/README.md)  

# C#기준으로 강의정리

이 문서는 C++기준인 바킹독 강의를 듣고, C#기준으로 정리가 필요한 내용들을 기록함.

# 0x01 기초코드작성요령1

## char 자료형

char는 문자를 저장하는데 사용되는 자료형.  
유니코드UTF-16문자를 나타내고, 16비트=2바이트를 사용함.  
U+0000~U+FFFF 의 범위값을 가짐.  
또한 char 피연산자의 경우 산술 및 비트 논리 연산자는 해당 문자 코드에 대한 연산을 수행하고 int 형식의 결과를 생성함.

## 정수자료형

| 자료형 | 크기  | 범위                                                   |
| ------ | ----- | ------------------------------------------------------ |
| byte   | 1byte | 0 ~ 255 (부호 없음)                                    |
| int    | 4byte | -2,147,483,648 ~ 2,147,483,647                         |
| long   | 8byte | -9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807 |

## 실수 자료형

| 자료형  | 크기   | 설명                               |
| ------- | ------ | ---------------------------------- |
| float   | 4byte  | 유효 숫자 6~7자리 (오차 발생 가능) |
| double  | 8byte  | 유효 숫자 15~16자리 (더 정밀함)    |
| decimal | 16byte | 금융 계산 등에 사용(더더더 정밀함) |

> decimal이있지만, double에서 커버가능하지않을까....

```C#
double d = 3D;
d = 4d;
d = 3.934_001;

float f = 3_000.5F;
f = 5.4f;

decimal myMoney = 3_000.5m;
myMoney = 400.75M;
```

접미사가 없거나 d 또는 D 접미사가 있는 리터럴은 double 형식입니다.
f 또는 F 접미사가 있는 리터럴은 float 형식입니다.
m 또는 M 접미사가 있는 리터럴은 decimal 형식입니다.

# 0x02 기초코드작성요령2

## C++ `vector` vs C# `List<T>`

```C#
List<int> list = new List<int>();
list.Add(10);  // 추가
list.Remove(10); // 삭제
```

## C#의 빠른입출력

Console.Write함수들은 기본적으로 매출력마다 flush연산을 실행함.

1. StringBuilder 에 출력할 내용을 모아둔 뒤 한꺼번에 출력하기.

```C#
static void Main()
{
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 100000; i++)
    {
        sb.Append(i + "\n");
    }
    Console.Write(sb.ToString());
}
```

2. auto flush 를 하지 않는 output stream 을 Console 에 연결하기.

```C#
Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

/* Console.Write 을 사용하는 코드 본문 */

Console.Out.Flush();
```

3. auto flush 를 하지 않는 output stream으로 BufferedStream을 쓸 수도 있음.

```C#
private const int bufferSize = 131072;
public static readonly StreamReader input = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
public static readonly StreamWriter output = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
```

> 나는 3번이 맘에 들었음.

# 0x03 배열

## C++ `std::swap()` vs C# 직접구현

C++에서는 swap()을 직접 구현하거나 STL의 std::swap()을 사용할 수 있지만, C#에서는 기본 제공되지 않음.  
C#에서는 ref키워드를 사용해서, 원본수정이 가능함.

```C#
void Swap(ref int a, ref int b) {
    int temp = a;
    a = b;
    b = temp;
}
```

## C++ `memset()` vs C# `Array.Fill()`

C++에서는 `memset()`을 사용하지만, C#에서는 `Array.Fill()`을 사용하면 돼.

```csharp
int[] arr = new int[10];
Array.Fill(arr, -1); // 모든 요소를 -1로 초기화
```

## C#의 foreach에서는 원본수정을 할수없음.

ref키워드 사용이 불가하고, List\<T>를 수정할거라면 반드시 for 사용.

## if(1) 왜안됨?

C++에서는 조건문(if, while 등)에서 정수(int)를 자동으로 논리값(bool)으로 변환하지만,  
C#에서는 if 문에서 반드시 bool 타입이 와야함.  
즉, 정수를 bool로 자동 변환하지 않음.  
`if (Convert.ToBoolean(1))`와같이 명시적으로 변환하면 가능.

# 0x04 연결리스트

## C++ std::list vs C# LinkedList<T>

C++의 list와 C#의 LinkedList 둘다, 이중연결리스트로 구현되어있음.

| 연산                         | C++ `std::list`                   | 시간복잡도 | C# `LinkedList<T>`                            | 시간복잡도 |
| ---------------------------- | --------------------------------- | ---------- | --------------------------------------------- | ---------- |
| **맨 앞에 추가**             | `push_front(val)`                 | `O(1)`     | `AddFirst(val)`                               | `O(1)`     |
| **맨 뒤에 추가**             | `push_back(val)`                  | `O(1)`     | `AddLast(val)`                                | `O(1)`     |
| **중간 삽입 (노드 제공됨)**  | `insert(it, val)`                 | `O(1)`     | `AddAfter(node, val)`, `AddBefore(node, val)` | `O(1)`     |
| **중간 삽입 (탐색 필요 시)** | `insert(it, val)`                 | `O(n)`     | `Find(val) → AddAfter(node, newVal)`          | `O(n)`     |
| **맨 앞 삭제**               | `pop_front()`                     | `O(1)`     | `RemoveFirst()`                               | `O(1)`     |
| **맨 뒤 삭제**               | `pop_back()`                      | `O(1)`     | `RemoveLast()`                                | `O(1)`     |
| **중간 삭제 (노드 제공됨)**  | `erase(it)`                       | `O(1)`     | `Remove(node)`                                | `O(1)`     |
| **중간 삭제 (탐색 필요 시)** | `remove(val)`                     | `O(n)`     | `Remove(val)`                                 | `O(n)`     |
| **특정 값 탐색**             | `find(it.begin(), it.end(), val)` | `O(n)`     | `Find(val)`                                   | `O(n)`     |
| **크기 확인**                | `size()`                          | `O(1)`     | `Count`                                       | `O(1)`     |
| **비었는지 확인**            | `empty()`                         | `O(1)`     | `Count == 0` 또는 `First == null`             | `O(1)`     |
| **첫 번째 원소 접근**        | `front()`                         | `O(1)`     | `First.Value`                                 | `O(1)`     |
| **마지막 원소 접근**         | `back()`                          | `O(1)`     | `Last.Value`                                  | `O(1)`     |

C#에는 iterator가 없어서, 해당노드를 가리킬 변수가 필요한데, 이때 `LinkedListNode<T>` 를 사용함.
각 노드에서는 속성으로, Previous, Next, Value가 있음.
또한 C++의 end()와 동일한 빈위치가 정의되지않음.

```C#
using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        LinkedList<int> myList = new LinkedList<int>();

        // 추가
        myList.AddFirst(1); // {1}
        myList.AddLast(2);  // {1, 2}

        LinkedListNode<int> node = myList.First;
        myList.AddAfter(node, 3);  // {1, 3, 2}

        // 삭제
        myList.Remove(3);  // {1, 2}
        myList.RemoveFirst();  // {2}

        Console.WriteLine($"First: {myList.First.Value}, Size: {myList.Count}");
    }
}
```

# 0x05 스택

## C++ std::stack vs C# Stack<T>

| 연산                       | C++ (`std::stack<T>`)   | 시간 복잡도 | C# (`Stack<T>`)   | 시간 복잡도 |
| -------------------------- | ----------------------- | ----------- | ----------------- | ----------- |
| **값 추가**                | `push(value)`           | **O(1)**    | `Push(value)`     | **O(1)**    |
| **값 제거**                | `pop()`                 | **O(1)**    | `Pop()`           | **O(1)**    |
| **맨 위 값 확인**          | `top()`                 | **O(1)**    | `Peek()`          | **O(1)**    |
| **스택 크기 확인**         | `size()`                | **O(1)**    | `Count` (속성)    | **O(1)**    |
| **스택이 비었는지 확인**   | `empty()`               | **O(1)**    | `Count == 0`      | **O(1)**    |
| **특정 값 포함 여부 확인** | ❌ (제공하지 않음)      | -           | `Contains(value)` | **O(n)**    |
| **모든 요소 삭제**         | ❌ (`swap()` 사용 가능) | -           | `Clear()`         | **O(n)**    |

# 0x06 큐

C++과 다르게, C#에서는 back을 지원하지않음.  

## C++ std::queue vs C# Queue<T>

### **🔍 C++ `std::queue<T>` vs C# `Queue<T>` 비교표**

| 연산                      | C++ (`std::queue<T>`)   | 시간 복잡도 | C# (`Queue<T>`)   | 시간 복잡도 |
| ------------------------- | ----------------------- | ----------- | ----------------- | ----------- |
| **값 추가 (뒤에 삽입)**   | `push(value)`           | **O(1)**    | `Enqueue(value)`  | **O(1)**    |
| **값 제거 (앞에서 삭제)** | `pop()`                 | **O(1)**    | `Dequeue()`       | **O(1)**    |
| **맨 앞 값 확인**         | `front()`               | **O(1)**    | `Peek()`          | **O(1)**    |
| **맨 뒤 값 확인**         | `back()`                | **O(1)**    | ❌ (없음)         | -           |
| **큐 크기 확인**          | `size()`                | **O(1)**    | `Count` (속성)    | **O(1)**    |
| **큐가 비었는지 확인**    | `empty()`               | **O(1)**    | `Count == 0`      | **O(1)**    |
| **특정 값 포함 여부**     | ❌ (제공하지 않음)      | -           | `Contains(value)` | **O(n)**    |
| **모든 요소 삭제**        | ❌ (`swap()` 사용 가능) | -           | `Clear()`         | **O(n)**    |

## Contains , Clear의 성능은?

스택이나 큐같은 컬렉션에서도 Contains나 Clear메소드를 지원한다.  
내부적으로 배열로 구현되어있어서, 원본을 손상시키지않고, 탐색이 가능.  
Contains이나 Clear의 성능은 O(N).  
큐의 요소를 하나씩 확인하는 head부터 순차적으로 선형탐색방식이다.  
그렇다면, 컬렉션의 자료구조에 따라서, Contains의 성능이 달라진다고 볼수있다.
물론 string클래스에서 contains메소드도 있지만, 여기서는 컬렉션에 존재하는 Contains를 말한다.  
### **🔍 C# 컬렉션별 `Contains(value)` 성능 비교**

| 컬렉션 유형                  | 내부 구조        | `Contains(value)` 시간 복잡도    | 설명                    |
| ---------------------------- | ---------------- | -------------------------------- | ----------------------- |
| **`List<T>`**                | 동적 배열        | **O(n)**                         | 순차 탐색이 필요        |
| **`LinkedList<T>`**          | 이중 연결 리스트 | **O(n)**                         | 처음부터 하나씩 탐색    |
| **`Queue<T>`**               | 원형 배열        | **O(n)**                         | 내부 배열을 순차 탐색   |
| **`Stack<T>`**               | 동적 배열        | **O(n)**                         | 내부 배열을 순차 탐색   |
| **`Dictionary<K, V>`**       | 해시 테이블      | **O(1) (평균)**, **O(n) (최악)** | 키 기반 조회            |
| **`SortedDictionary<K, V>`** | 이진 검색 트리   | **O(log n)**                     | 균형 BST(AVL 트리) 기반 |
| **`HashSet<T>`**             | 해시 테이블      | **O(1) (평균)**, **O(n) (최악)** | 값 기반 조회            |
| **`SortedSet<T>`**           | 이진 검색 트리   | **O(log n)**                     | 균형 BST 기반           |

### **🔍 C# 컬렉션별 `Clear()` 성능 비교**

| 컬렉션 유형                 | 내부 구조        | `Clear()` 시간 복잡도 | 동작 방식                       |
| --------------------------- | ---------------- | --------------------- | ------------------------------- |
| **`List<T>`**               | 동적 배열        | **O(n)**              | 내부 배열의 참조 제거           |
| **`LinkedList<T>`**         | 이중 연결 리스트 | **O(1)**              | `head`와 `tail`을 `null`로 설정 |
| **`Queue<T>`**              | 원형 배열        | **O(n)**              | 내부 배열 참조 제거             |
| **`Stack<T>`**              | 동적 배열        | **O(n)**              | 내부 배열 참조 제거             |
| **`Dictionary<K,V>`**       | 해시 테이블      | **O(n)**              | 모든 엔트리 삭제                |
| **`SortedDictionary<K,V>`** | 이진 검색 트리   | **O(n)**              | 모든 노드 삭제                  |
| **`HashSet<T>`**            | 해시 테이블      | **O(n)**              | 모든 버킷 초기화                |
| **`SortedSet<T>`**          | 이진 검색 트리   | **O(n)**              | 모든 노드 삭제                  |

# 0x07 덱
C#에서는, c++의 덱에 대응되는 컬렉션이 존재하지않음.  

# 0x08 스택의 활용(수식의 괄호쌍)
...

# 0x09 BFS
# 0x0A DFS
# 0x0B 재귀
# 0x0C 백트레킹
# 0x0D 시뮬레이션


