[Back(메인으로)](/README.md)

# C#의 Collections에 대해 알아보자

C#에서 주로 사용되는 컬렉션들은 다음과 같다.  
List, LinkedList, Queue, Stack, HashSet, Dictionary, SortedSet, SortedDictionary, PriorityQueue.
이들 컬렉션들을 살펴보기전에, 각각의 컬렉션들은 상속받는 인터페이스들이 많은데, 인터페이스들을 먼저 살펴보자.

# `IEnumerable`

IEnumerable을 구현하면, foreach문을 사용하여 순회할수 있음.  
제네릭이 아닌 컬렉션에 대한 간단한 반복을 지원하는 열거자를 노출합니다.

```C#
public interface IEnumerable
{
    IEnumerator GetEnumerator(); // 컬렉션을 반복하는 열거자를 반환합니다.
}
```

# `IEnumerable<T>`

지정된 형식의 컬렉션에 대한 간단한 반복을 지원하는 열거자를 노출합니다.

```C#
public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator(); // 컬렉션을 반복하는 열거자를 반환합니다.
}
```

# `<out T>는, 그냥<T>랑 어떻게 다르나?`

위 코드에서 T는 out 키워드로 선언되었으므로 반환값(출력)으로만 사용됩니다.

```C#
public interface IExample<T>
{
    void SetValue(T value); // 입력값으로 사용
    T GetValue(); // 출력값으로 사용
}
```

위코드에서, out T를 사용한다면 입력값으로 T를 사용하지 못하는것이다.

# `IEnumerator`

IEnumerable을 구현하기위해, IEnumerator을 알아보자.

```C#
public interface IEnumerator
{
    bool MoveNext();
    object Current { get; }
    void Reset();
}
```

# `IEnumerator<out T>`

제네릭 컬렉션에 대한 간단한 반복을 지원합니다.

```C#
public interface IEnumerator<out T> : IDisposable, IEnumerator
{
    T Current { get; }
}
```

여기선 current밖에 없는것이 아니라, 인터페이스도 상속이 가능하다.  
그래서, current뿐아니라, IEnumerator의 moveNext, Current,Reset 모두 구현해야한다.  
또한 IDisposable도 구현해야하는데, 알아보자.

# `IDisposable`

관리되지 않는 리소스를 해제하는 메커니즘을 제공합니다.

```C#
public interface IDisposable
{
    void Dispose();
}
```

# IEnumerator 구현을 컴파일러가??

```C#
class MyEnumerator
{
     private int[] numbers = { 1, 2, 3, 4 };

     public IEnumerator GetEnumerator()
     {
         yield return numbers[0];
         yield return numbers[1];
         yield return numbers[2];
         yield break;             // yield break는 GetEnumerator() 메소드를 종료시킴
         yield return numbers[3]; // 따라서 이 부분은 실행되지 않음
     }
}
```

이렇게 yield문을 사용하면, IEnumerator 인터페이스를 상속받는 클래스를 따로 구현하지않아도,
컴파일러가 자동으로 해당 인터페이스를 구현한 클래스를 생성해 준다.

# `ICollection`

모든 비제네릭 컬렉션의 크기, 열거자 및 동기화 메서드를 정의합니다.

```C#
public interface ICollection : IEnumerable
{
    int Count { get; } // 컬렉션의 요소 개수 반환
    bool IsSynchronized { get; } // 스레드 동기화 여부
    object SyncRoot { get; } // 동기화된 액세스를 위한 객체 반환
    void CopyTo(Array array, int index); // 배열로 복사
}
```

# `ICollection<T>`

제네릭 컬렉션을 조작하는 메서드를 정의합니다.

```C#
public interface ICollection<T> : IEnumerable<T>, IEnumerable
{
    int Count { get; } // 컬렉션의 요소 개수 반환
    bool IsReadOnly { get; } // 읽기 전용 여부
    void Add(T item); // 요소 추가
    void Clear(); // 모든 요소 제거
    bool Contains(T item); // 특정 요소 포함 여부 확인
    void CopyTo(T[] array, int arrayIndex); // 배열로 복사
    bool Remove(T item); // 특정 요소 제거
}
```

# `IList`

인덱스로 개별적으로 액세스할 수 있는 제네릭이 아닌 개체 컬렉션을 나타냅니다.

```C#
public interface IList : ICollection, IEnumerable
{
    object? this[int index] { get; set; } // 인덱서를 통한 접근
    int Add(object? value); // 요소 추가
    bool Contains(object? value); // 요소 포함 여부 확인
    void Clear(); // 모든 요소 제거
    bool IsReadOnly { get; } // 읽기 전용 여부
    bool IsFixedSize { get; } // 고정 크기 여부
    int IndexOf(object? value); // 특정 요소의 인덱스 반환
    void Insert(int index, object? value); // 특정 위치에 요소 삽입
    void Remove(object? value); // 특정 요소 제거
    void RemoveAt(int index); // 특정 인덱스의 요소 제거
}
```

# `IList<T>`

인덱스로 개별적으로 액세스할 수 있는 개체의 컬렉션을 나타냅니다.

```C#
public interface IList<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    T this[int index] { get; set; } // 인덱서를 통한 접근
    int IndexOf(T item); // 특정 요소의 인덱스 반환
    void Insert(int index, T item); // 특정 위치에 요소 삽입
    void RemoveAt(int index); // 특정 인덱스의 요소 제거
}
```

# `IDictionary`

키/값 쌍의 비제네릭 컬렉션을 나타냅니다.

```C#
public interface IDictionary : ICollection, IEnumerable
{
  object? this[object key] { get; set; } // 키를 통한 값 접근
  ICollection Keys { get; } // 키 컬렉션
  ICollection Values { get; } // 값 컬렉션
  bool Contains(object key); // 특정 키 포함 여부 확인
  void Add(object key, object? value); // 키-값 쌍 추가
  void Clear(); // 모든 요소 제거
  bool IsReadOnly { get; } // 읽기 전용 여부
  bool IsFixedSize { get; } // 고정 크기 여부
  IDictionaryEnumerator GetEnumerator(); // 열거자 반환
  void Remove(object key); // 특정 키의 요소 제거
}
```

# `IDictionary<TKey, TValue>`

키/값 쌍의 제네릭 컬렉션을 나타냅니다.

```C#
public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
   TValue this[TKey key] { get; set; } // 키를 통한 값 접근
   ICollection<TKey> Keys { get; } // 키 컬렉션
   ICollection<TValue> Values { get; } // 값 컬렉션
   bool ContainsKey(TKey key); // 특정 키 포함 여부 확인
   void Add(TKey key, TValue value); // 키-값 쌍 추가
   bool Remove(TKey key); // 특정 키의 요소 제거
   bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value); // 특정 키의 값 가져오기
}
```

# `KeyValuePair<TKey,TValue> 구조체`

설정하거나 검색할 수 있는 키/값 쌍을 정의합니다.  
구조체이며, 읽기전용이다.

```C#
public readonly struct KeyValuePair<TKey, TValue>
{
    public TKey Key { get; }
    public TValue Value { get; }
}
```

아래코드같이, foreach문에서 받는자료형이 `KeyValuePair<Tkey, TValue>` 자료형이다.

```C#
foreach( KeyValuePair<string, string> kvp in myDictionary )
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}
```

# `ISet<T>`

집합의 추상화에 대한 기본 인터페이스를 제공합니다.

```C#
public interface ISet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    bool Add(T item); // 요소 추가 (중복 방지)
    void UnionWith(IEnumerable<T> other); // 합집합 연산 수행
    void IntersectWith(IEnumerable<T> other); // 교집합 연산 수행
    void ExceptWith(IEnumerable<T> other); // 차집합 연산 수행
    void SymmetricExceptWith(IEnumerable<T> other); // 대칭 차집합 연산 수행
    bool IsSubsetOf(IEnumerable<T> other); // 부분집합 여부 확인
    bool IsSupersetOf(IEnumerable<T> other); // 전체집합 여부 확인
    bool IsProperSupersetOf(IEnumerable<T> other); // 진부분집합 여부 확인
    bool IsProperSubsetOf(IEnumerable<T> other); // 진상위집합 여부 확인
    bool Overlaps(IEnumerable<T> other); // 중복 요소 존재 여부 확인
    bool SetEquals(IEnumerable<T> other); // 집합 동일 여부 확인
}
```

이렇게 인터페이스들을 살펴봤다.

# 이제다시, 주요컬렉션들이 무얼 상속받는지 살펴보자.

## `List<T>`

`public class List<T> : IList<T>, IList, IReadOnlyList<T>`
`List<T>`는 다음 인터페이스들을 구현합니다.

- `IList<T>`
- `ICollection<T>`
- `IEnumerable<T>`
- `IReadOnlyList<T>`
- `IReadOnlyCollection<T>`
- `IList`
- `ICollection`
- `IEnumerable`

### 속성(Properties)

| 속성                   | 인터페이스 출처                                           | 시간복잡도    | 설명                                     |
| ---------------------- | --------------------------------------------------------- | ------------- | ---------------------------------------- |
| `Capacity`             | **List<T> 고유**                                          | O(1) / O(n)\* | 내부 배열의 용량을 가져오거나 설정       |
| `Count`                | `ICollection<T>`, `ICollection`, `IReadOnlyCollection<T>` | O(1)          | 포함된 요소 수를 가져옴                  |
| `Item[Int32]` (인덱서) | `IList<T>`, `IList`, `IReadOnlyList<T>`                   | O(1)          | 지정된 인덱스에서 요소를 가져오거나 설정 |
| `IsReadOnly`           | `ICollection<T>`, `IList`                                 | O(1)          | 읽기 전용 여부 (항상 false)              |

### 메서드(Methods)

| 메서드                                        | 인터페이스 출처                 | 시간복잡도 | 설명                                   |
| --------------------------------------------- | ------------------------------- | ---------- | -------------------------------------- |
| **추가 연산**                                 |                                 |            |                                        |
| `Add(T)`                                      | `ICollection<T>`, `IList`       | O(1)\*     | List 끝에 개체를 추가                  |
| `AddRange(IEnumerable<T>)`                    | **List<T> 고유**                | O(n)\*     | 컬렉션의 요소를 List 끝에 추가         |
| `Insert(Int32, T)`                            | `IList<T>`, `IList`             | O(n)       | 지정된 인덱스에 요소 삽입              |
| `InsertRange(Int32, IEnumerable<T>)`          | **List<T> 고유**                | O(n)       | 컬렉션의 요소를 지정된 인덱스에 삽입   |
| `EnsureCapacity(Int32)`                       | **List<T> 고유**                | O(n)\*     | 지정된 용량 이상으로 확보              |
| **제거 연산**                                 |                                 |            |                                        |
| `Clear()`                                     | `ICollection<T>`, `IList`       | O(1)       | 모든 요소 제거                         |
| `Remove(T)`                                   | `ICollection<T>`, `IList`       | O(n)       | 특정 개체의 첫 번째 항목 제거          |
| `RemoveAt(Int32)`                             | `IList<T>`, `IList`             | O(n)       | 지정된 인덱스의 요소 제거              |
| `RemoveRange(Int32, Int32)`                   | **List<T> 고유**                | O(n)       | 지정된 범위의 요소 제거                |
| `RemoveAll(Predicate<T>)`                     | **List<T> 고유**                | O(n)       | 조건과 일치하는 모든 요소 제거         |
| `TrimExcess()`                                | **List<T> 고유**                | O(n)\*     | 내부 배열을 실제 요소 수에 맞게 조정   |
| **검색 연산**                                 |                                 |            |                                        |
| `Contains(T)`                                 | `ICollection<T>`, `IList`       | O(n)       | 요소 포함 여부 확인                    |
| `IndexOf(T)`                                  | `IList<T>`, `IList`             | O(n)       | 개체의 첫 번째 위치 인덱스 반환        |
| `IndexOf(T, Int32)`                           | `IList<T>`                      | O(n)       | 지정된 인덱스부터 개체의 첫 위치 찾기  |
| `IndexOf(T, Int32, Int32)`                    | `IList<T>`                      | O(n)       | 지정된 범위 내에서 개체의 첫 위치 찾기 |
| `LastIndexOf(T)`                              | **List<T> 고유**                | O(n)       | 개체의 마지막 위치 인덱스 반환         |
| `LastIndexOf(T, Int32)`                       | **List<T> 고유**                | O(n)       | 지정된 인덱스까지 거꾸로 검색          |
| `LastIndexOf(T, Int32, Int32)`                | **List<T> 고유**                | O(n)       | 지정된 범위 내에서 거꾸로 검색         |
| `BinarySearch(T)`                             | **List<T> 고유**                | O(log n)   | 정렬된 리스트에서 이진 검색            |
| `BinarySearch(T, IComparer<T>)`               | **List<T> 고유**                | O(log n)   | 지정된 비교자로 이진 검색              |
| `BinarySearch(Int32, Int32, T, IComparer<T>)` | **List<T> 고유**                | O(log n)   | 지정된 범위에서 이진 검색              |
| `Find(Predicate<T>)`                          | **List<T> 고유**                | O(n)       | 조건과 일치하는 첫 요소 찾기           |
| `FindLast(Predicate<T>)`                      | **List<T> 고유**                | O(n)       | 조건과 일치하는 마지막 요소 찾기       |
| `FindAll(Predicate<T>)`                       | **List<T> 고유**                | O(n)       | 조건과 일치하는 모든 요소 찾기         |
| `FindIndex(Predicate<T>)`                     | **List<T> 고유**                | O(n)       | 조건과 일치하는 첫 요소의 인덱스       |
| `FindIndex(Int32, Predicate<T>)`              | **List<T> 고유**                | O(n)       | 지정된 인덱스부터 조건 일치 인덱스     |
| `FindIndex(Int32, Int32, Predicate<T>)`       | **List<T> 고유**                | O(n)       | 지정된 범위에서 조건 일치 인덱스       |
| `FindLastIndex(Predicate<T>)`                 | **List<T> 고유**                | O(n)       | 조건 일치하는 마지막 요소 인덱스       |
| `FindLastIndex(Int32, Predicate<T>)`          | **List<T> 고유**                | O(n)       | 지정 인덱스까지 역방향 조건 검색       |
| `FindLastIndex(Int32, Int32, Predicate<T>)`   | **List<T> 고유**                | O(n)       | 지정 범위에서 역방향 조건 검색         |
| `Exists(Predicate<T>)`                        | **List<T> 고유**                | O(n)       | 조건 일치 요소 존재 여부 확인          |
| `TrueForAll(Predicate<T>)`                    | **List<T> 고유**                | O(n)       | 모든 요소가 조건과 일치하는지 확인     |
| **정렬 및 변환 연산**                         |                                 |            |                                        |
| `Sort()`                                      | **List<T> 고유**                | O(n log n) | 기본 비교자로 전체 리스트 정렬         |
| `Sort(IComparer<T>)`                          | **List<T> 고유**                | O(n log n) | 지정된 비교자로 전체 리스트 정렬       |
| `Sort(Comparison<T>)`                         | **List<T> 고유**                | O(n log n) | 지정된 비교 델리게이트로 정렬          |
| `Sort(Int32, Int32, IComparer<T>)`            | **List<T> 고유**                | O(n log n) | 지정된 범위와 비교자로 정렬            |
| `Reverse()`                                   | **List<T> 고유**                | O(n)       | 전체 리스트 요소 순서 반전             |
| `Reverse(Int32, Int32)`                       | **List<T> 고유**                | O(n)       | 지정된 범위의 요소 순서 반전           |
| `ConvertAll<TOutput>(Converter<T,TOutput>)`   | **List<T> 고유**                | O(n)       | 요소를 다른 형식으로 변환              |
| `ForEach(Action<T>)`                          | **List<T> 고유**                | O(n)       | 각 요소에 대해 작업 수행               |
| **복사 및 변환 연산**                         |                                 |            |                                        |
| `ToArray()`                                   | **List<T> 고유**                | O(n)       | 요소를 새 배열에 복사                  |
| `CopyTo(T[])`                                 | `ICollection<T>`, `ICollection` | O(n)       | 배열에 모든 요소 복사                  |
| `CopyTo(T[], Int32)`                          | `ICollection<T>`, `ICollection` | O(n)       | 지정된 인덱스부터 배열에 복사          |
| `CopyTo(Int32, T[], Int32, Int32)`            | **List<T> 고유**                | O(n)       | 지정된 범위를 배열에 복사              |
| `GetRange(Int32, Int32)`                      | **List<T> 고유**                | O(n)       | 지정된 범위의 요소 복사본 생성         |
| `Slice(Int32, Int32)`                         | **List<T> 고유** (.NET 8.0+)    | O(n)       | 지정된 범위의 요소 복사본 생성         |
| `AsReadOnly()`                                | **List<T> 고유**                | O(1)       | 읽기 전용 래퍼 반환                    |
| **열거 및 기타 연산**                         |                                 |            |                                        |
| `GetEnumerator()`                             | `IEnumerable<T>`, `IEnumerable` | O(1)       | 리스트를 반복하는 열거자 반환          |
| `Equals(Object)`                              | `Object`에서 상속               | O(n)       | 개체가 현재 개체와 같은지 확인         |
| `GetHashCode()`                               | `Object`에서 상속               | O(1)       | 기본 해시 함수로 사용                  |
| `GetType()`                                   | `Object`에서 상속               | O(1)       | 현재 인스턴스의 Type 가져옴            |
| `ToString()`                                  | `Object`에서 상속               | O(n)       | 개체를 나타내는 문자열 반환            |

### 인터페이스별 메서드 분포:

List\<T> 고유 메서드: 주로 고급 검색(FindAll, FindIndex), 정렬(Sort), 변환(ConvertAll), 범위 연산(GetRange, RemoveRange) 등
ICollection\<T>/IList\<T>: 기본적인 컬렉션 연산(Add, Remove, Contains 등)
Object 클래스 상속: 기본 객체 동작(Equals, GetHashCode 등)

### 특이점

- Add연산에서, 평균 시간복잡도는 O(1)이지만, 내부 배열 크기 조정이 발생하면 O(n)이다.
- Remove가 O(n)인데, 앞에서부터 타겟을 찾아나가고, 찾은뒤엔, 요소들을 앞으로 당겨야 하기 때문이다.
- RemoveAt에서 맨뒤요소를 삭제한다면, O(1)이 된다. O(n) 에서 n 은 (Count - index)이다.
- 의외였던건 Clear도 O(n)이다. 각 요소들을 초기화 작업이 필요하다.
- sort가 O(NLogN)인건, Array.Sort가 퀵소트로 구현되기때문이다.
- BinarySearch가 O(LogN)으로 더 좋지만, 정렬된 상태에서 진행해야하는 조건이 있다. 결국 정렬하려면 O(NLogN)...
- 대체로 O(N)으로, 순차탐색인걸로 생각된다.

#### Count는 인터페이스가 3개인데??

Count라는 프로퍼티는, `ICollection<T>`, `ICollection`, `IReadOnlyCollection<T>`에 각각 Count가 있다.  
지금생각으론 Count변수가 3개를 구현해야하지않나 라는생각인데, C#의 `List<T>`는 Count가 1개이다. 이를 알아보자.  
예제코드를 만들어서 살펴보자.

```C#
public interface T1
{
    int A { get; set; }
}

public interface T2
{
    int A { get; set; }
    int B{ get; set; }
}

public interface T3
{
    int A { get; set; }
    int B{ get; set; }
    int C{ get; set; }
}

public class C1 : T1, T2, T3
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
}
```

클래스 C1에서, 인터페이스의 변수명이겹친다. 하지만 자동구현으로 테스트결과, A,B,C만 생겼다.
이 현상을 인터페이스 멤버 공유(Interface Member Sharing)이라고 한다.. .NET 인터페이스 구현 방식에서 일반적으로 발생하는것이라고 한다..
구현만 되어있으면 상관없다는 느낌인가...

```C#
public class C1 : T1, T2, T3
{
    int T1.A { get; set; } = 10;
    int T2.A { get; set; } = 20;
    int T3.A { get; set; } = 30;

    public int B { get; set; }
    public int C { get; set; }
}
```

이렇게 명시적으로 각가의 인터페이스별로 구현할수도 있다. 하지만 이때 발생하는문제점이 생긴다.

#### 클래스 C1에게 A변수를 달라고하면, 어떤것을 넘겨줄까??

```C#
C1 obj = new C1();
Console.WriteLine(obj.A);  // ❌ 컴파일 오류! (A는 명시적으로 구현되었기 때문에 직접 접근 불가)
```

이렇게 직접접근이 불가하다.

#### 그렇다면 명시적으로 구현한 의미가 없나??

아니다. 해당인터페이스로 캐스팅을 해야 명시적구현된것이 호출된다.

```C#
C1 obj = new C1();

T1 t1 = obj;
T2 t2 = obj;
T3 t3 = obj;

Console.WriteLine(t1.A);  // ✅ 10 출력
Console.WriteLine(t2.A);  // ✅ 20 출력
Console.WriteLine(t3.A);  // ✅ 30 출력
```

이와같은 상황의 예시로는, 다음의 LinkedList에서 살펴보겠지만, Add가 Icollection구현인데, AddLast로 명시적구현이 되어있다.

## `LinkedList<T>`

`public class LinkedList<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>`
`LinkedList<T>`는 다음 인터페이스들을 구현합니다:

- `ICollection<T>`
- `IEnumerable<T>`
- `IReadOnlyCollection<T>`
- `ICollection`
- `IEnumerable`
- `ISerializable`
- `IDeserializationCallback`

주목할 점은 `List<T>`와 달리 `IList<T>` 또는 `IList` 인터페이스를 구현하지 않는다는 것입니다. 이는 `LinkedList<T>`가 인덱스를 통한 접근을 지원하지 않기 때문입니다.

### 속성(Properties)

| 속성         | 인터페이스 출처                                           | 시간복잡도 | 설명                        |
| ------------ | --------------------------------------------------------- | ---------- | --------------------------- |
| `Count`      | `ICollection<T>`, `ICollection`, `IReadOnlyCollection<T>` | O(1)       | 포함된 노드 수를 가져옴     |
| `First`      | **LinkedList<T> 고유**                                    | O(1)       | 첫 번째 노드를 가져옴       |
| `Last`       | **LinkedList<T> 고유**                                    | O(1)       | 마지막 노드를 가져옴        |
| `IsReadOnly` | `ICollection<T>`, `ICollection`                           | O(1)       | 읽기 전용 여부 (항상 false) |

### 메서드(Methods)

| 메서드                                               | 인터페이스 출처                 | 시간복잡도 | 설명                                            |
| ---------------------------------------------------- | ------------------------------- | ---------- | ----------------------------------------------- |
| **추가 연산**                                        |                                 |            |                                                 |
| `AddAfter(LinkedListNode<T>, T)`                     | **LinkedList<T> 고유**          | O(1)       | 지정된 노드 뒤에 값 추가                        |
| `AddAfter(LinkedListNode<T>, LinkedListNode<T>)`     | **LinkedList<T> 고유**          | O(1)       | 지정된 노드 뒤에 새 노드 추가                   |
| `AddBefore(LinkedListNode<T>, T)`                    | **LinkedList<T> 고유**          | O(1)       | 지정된 노드 앞에 값 추가                        |
| `AddBefore(LinkedListNode<T>, LinkedListNode<T>)`    | **LinkedList<T> 고유**          | O(1)       | 지정된 노드 앞에 새 노드 추가                   |
| `AddFirst(T)`                                        | **LinkedList<T> 고유**          | O(1)       | 리스트 시작 부분에 값 추가                      |
| `AddFirst(LinkedListNode<T>)`                        | **LinkedList<T> 고유**          | O(1)       | 리스트 시작 부분에 노드 추가                    |
| `AddLast(T)`                                         | **LinkedList<T> 고유**          | O(1)       | 리스트 끝 부분에 값 추가                        |
| `AddLast(LinkedListNode<T>)`                         | **LinkedList<T> 고유**          | O(1)       | 리스트 끝 부분에 노드 추가                      |
| `Add(T)`                                             | `ICollection<T>`                | O(1)       | 리스트 끝에 항목 추가 (내부적으로 AddLast 호출) |
| **제거 연산**                                        |                                 |            |                                                 |
| `Clear()`                                            | `ICollection<T>`, `ICollection` | O(1)       | 모든 노드 제거                                  |
| `Remove(T)`                                          | `ICollection<T>`                | O(n)       | 특정 값의 첫 번째 발생 항목 제거                |
| `Remove(LinkedListNode<T>)`                          | **LinkedList<T> 고유**          | O(1)       | 지정된 노드 제거                                |
| `RemoveFirst()`                                      | **LinkedList<T> 고유**          | O(1)       | 첫 번째 노드 제거                               |
| `RemoveLast()`                                       | **LinkedList<T> 고유**          | O(1)       | 마지막 노드 제거                                |
| **검색 연산**                                        |                                 |            |                                                 |
| `Contains(T)`                                        | `ICollection<T>`, `ICollection` | O(n)       | 값이 리스트에 포함되는지 확인                   |
| `Find(T)`                                            | **LinkedList<T> 고유**          | O(n)       | 지정된 값을 포함하는 첫 번째 노드 찾기          |
| `FindLast(T)`                                        | **LinkedList<T> 고유**          | O(n)       | 지정된 값을 포함하는 마지막 노드 찾기           |
| **복사 및 변환 연산**                                |                                 |            |                                                 |
| `CopyTo(T[], Int32)`                                 | `ICollection<T>`, `ICollection` | O(n)       | 지정된 인덱스부터 배열에 복사                   |
| **열거 및 기타 연산**                                |                                 |            |                                                 |
| `GetEnumerator()`                                    | `IEnumerable<T>`, `IEnumerable` | O(1)       | 리스트를 반복하는 열거자 반환                   |
| `Equals(Object)`                                     | `Object`에서 상속               | O(n)       | 개체가 현재 개체와 같은지 확인                  |
| `GetHashCode()`                                      | `Object`에서 상속               | O(1)       | 기본 해시 함수로 사용                           |
| `GetType()`                                          | `Object`에서 상속               | O(1)       | 현재 인스턴스의 Type 가져옴                     |
| `ToString()`                                         | `Object`에서 상속               | O(n)       | 개체를 나타내는 문자열 반환                     |
| `GetObjectData(SerializationInfo, StreamingContext)` | `ISerializable`                 | O(n)       | 직렬화를 위한 데이터 제공                       |
| `OnDeserialization(Object)`                          | `IDeserializationCallback`      | O(n)       | 역직렬화 완료 후 콜백 메서드                    |

### `LinkedListNode<T>` 속성

| 속성       | 시간복잡도 | 설명                                           |
| ---------- | ---------- | ---------------------------------------------- |
| `Value`    | O(1)       | 노드의 값을 가져오거나 설정                    |
| `Next`     | O(1)       | 다음 노드에 대한 참조를 가져옴                 |
| `Previous` | O(1)       | 이전 노드에 대한 참조를 가져옴                 |
| `List`     | O(1)       | 노드가 속한 LinkedList<T>에 대한 참조를 가져옴 |

### 특이점

- 인덱스 기반 접근을 지원하지 않아 `IList<T>` 인터페이스를 구현하지 않습니다.
- `LinkedListNode<T>` 객체를 통해 직접 노드를 조작할 수 있습니다.
- `AddFirst()`, `AddLast()`, `RemoveFirst()`, `RemoveLast()`는 **O(1)**의 성능을 가짐.
- 내부구현은 이중연결리스트로 구현되어있음.  

#### 왜 Add는 함수리스트에 안뜸?

ICollection을 상속받았으면, Add함수가 있어야할텐데, 없다.
구현체를 살펴보니, `void ICollection<T>.Add(T item) => AddLast(item);` 이렇게 Add함수가 명시적으로 AddLast메소드를 호출하도록 되어있었다.  
이렇게 명시적으로 구현된것은, 직접적으로 호출할수가 없다.
그래서 공식문서에서도 명시적 인터페이스구현목록이 따로 정리되어있는거구나...알게되었다.

```C#
LinkedList<int> linkedList = new LinkedList<int>();
// linkedList.Add(10);  // 컴파일 에러!
ICollection<int> collection = linkedList;
collection.Add(10);  // 정상적으로 동작
```

이렇게, ICollection으로 캐스팅된다면, Add함수를 호출할수있게 된다.

## `Stack<T>`

`public class Stack<T> : IEnumerable<T>, IReadOnlyCollection<T>, ICollection`

### 인터페이스 제공 연산들

| 프로퍼티 | 인터페이스       | 설명                    | 시간 복잡도 |
| -------- | ---------------- | ----------------------- | ----------- |
| `Count`  | `ICollection<T>` | 스택에 포함된 요소 개수 | `O(1)`      |

| 메서드                              | 인터페이스       | 설명                     | 시간 복잡도 |
| ----------------------------------- | ---------------- | ------------------------ | ----------- |
| `Clear()`                           | `ICollection<T>` | 모든 요소 제거           | `O(n)`      |
| `Contains(T item)`                  | `ICollection<T>` | 특정 요소 포함 여부 확인 | `O(n)`      |
| `CopyTo(T[] array, int arrayIndex)` | `ICollection<T>` | 스택을 배열로 복사       | `O(n)`      |
| `GetEnumerator()`                   | `IEnumerable<T>` | 열거자 반환              | `O(n)`      |

### 고유연산들

| 메서드         | 설명                                   | 시간 복잡도                               |
| -------------- | -------------------------------------- | ----------------------------------------- |
| `Push(T item)` | 스택의 맨 위에 요소 추가               | `O(1)` (평균), `O(n)` (배열 크기 증가 시) |
| `Pop()`        | 스택의 맨 위 요소 제거 및 반환         | `O(1)`                                    |
| `Peek()`       | 스택의 맨 위 요소 반환 (제거하지 않음) | `O(1)`                                    |
| `ToArray()`    | 스택을 배열로 변환 (위쪽부터 순서대로) | `O(n)`                                    |
| `TrimExcess()` | 사용되지 않는 여유 공간을 줄여 최적화  | `O(n)`                                    |

### 특이점

- 스태깅 비어있는지 체크할때, `if(st.Peek() != null)`,`if(st.Count > 0)` 둘다 가능한데, 후자가 더 안전한 방법이다. 스택에는 참조타입, 값타입 둘다 받을수있다.
- 스택이라면, Contains함수는 존재하지않아야할텐데 있.다...추상적개념인 스택만 보면 그렇지만, 내부적 구현상으로는 모든요소에 접근가능한 구조라서, Contains가 존재가능하고, 순차탐색을 하기때문에 O(N)성능을 보인다.
- LIFO(Last In First Out)

## `Queue<T>`

`public class Queue<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>`

### 인터페이스 제공 연산들

| 프로퍼티 | 인터페이스       | 설명                  | 시간 복잡도 |
| -------- | ---------------- | --------------------- | ----------- |
| `Count`  | `ICollection<T>` | 큐에 포함된 요소 개수 | `O(1)`      |

| 메서드                              | 인터페이스       | 설명                     | 시간 복잡도 |
| ----------------------------------- | ---------------- | ------------------------ | ----------- |
| `Clear()`                           | `ICollection<T>` | 모든 요소 제거           | `O(n)`      |
| `Contains(T item)`                  | `ICollection<T>` | 특정 요소 포함 여부 확인 | `O(n)`      |
| `CopyTo(T[] array, int arrayIndex)` | `ICollection<T>` | 큐를 배열로 복사         | `O(n)`      |
| `GetEnumerator()`                   | `IEnumerable<T>` | 열거자 반환              | `O(n)`      |

### 고유연산들

| 메서드            | 설명                                     | 시간 복잡도                               |
| ----------------- | ---------------------------------------- | ----------------------------------------- |
| `Enqueue(T item)` | 큐의 끝에 요소 추가                      | `O(1)` (평균), `O(n)` (배열 크기 증가 시) |
| `Dequeue()`       | 큐의 앞에서 요소 제거 및 반환            | `O(1)`                                    |
| `Peek()`          | 큐의 앞 요소 반환 (제거하지 않음)        | `O(1)`                                    |
| `ToArray()`       | 큐를 배열로 변환 (앞에서 뒤로 순서 유지) | `O(n)`                                    |
| `TrimExcess()`    | 사용되지 않는 여유 공간을 줄여 최적화    | `O(n)`                                    |

### 특이점

- 큐가 비어있는지 체크할때, `if(q.Peek() != null)`,`if(q.Count > 0)` 둘다 가능한데, 후자가 더 안전한 방법이다. 큐에는 참조타입, 값타입 둘다 받을수있다.
- 스택에서와 마찬가지로 큐에서도 Contains가 구현되어있는데, 내부적 구현이 모든요소를 조회가 가능하기때문이고, 성능은 순차탐색으로 O(N)성능을 보인다.
- FIFO(FirstInFirstOut).

## `HashSet<T>`

`public class HashSet<T> : ICollection<T>, ISet<T>, IReadOnlyCollection<T>, IReadOnlySet<T>, ISerializable, IDeserializationCallback`

### 인터페이스 제공 연산들

| 프로퍼티   | 인터페이스       | 설명                                   | 시간 복잡도 |
| ---------- | ---------------- | -------------------------------------- | ----------- |
| `Count`    | `ICollection<T>` | 요소 개수 반환                         | `O(1)`      |
| `Comparer` | `ISet<T>`        | 해시 및 비교 논리를 제공하는 개체 반환 | `O(1)`      |

| 메서드                                      | 인터페이스                  | 설명                                    | 시간 복잡도                              |
| ------------------------------------------- | --------------------------- | --------------------------------------- | ---------------------------------------- |
| `Add(T item)`                               | `ISet<T>`, `ICollection<T>` | 요소 추가 (중복 허용 안 함)             | `O(1)` (평균), `O(n)` (리사이징 발생 시) |
| `Remove(T item)`                            | `ICollection<T>`            | 특정 요소 제거                          | `O(1)`                                   |
| `Contains(T item)`                          | `ICollection<T>`            | 특정 요소 포함 여부 확인                | `O(1)`                                   |
| `Clear()`                                   | `ICollection<T>`            | 모든 요소 제거                          | `O(n)`                                   |
| `CopyTo(T[] array, int index)`              | `ICollection<T>`            | 배열로 복사                             | `O(n)`                                   |
| `GetEnumerator()`                           | `IEnumerable<T>`            | 요소를 반복하는 열거자 반환             | `O(n)`                                   |
| `UnionWith(IEnumerable<T> other)`           | `ISet<T>`                   | 다른 컬렉션과 **합집합** 수행           | `O(n)`                                   |
| `IntersectWith(IEnumerable<T> other)`       | `ISet<T>`                   | 다른 컬렉션과 **교집합** 수행           | `O(n)`                                   |
| `ExceptWith(IEnumerable<T> other)`          | `ISet<T>`                   | 다른 컬렉션의 요소를 **제거**           | `O(n)`                                   |
| `SymmetricExceptWith(IEnumerable<T> other)` | `ISet<T>`                   | **대칭 차집합** 연산 수행               | `O(n)`                                   |
| `IsSubsetOf(IEnumerable<T> other)`          | `ISet<T>`                   | 현재 집합이 **하위 집합**인지 확인      | `O(n)`                                   |
| `IsSupersetOf(IEnumerable<T> other)`        | `ISet<T>`                   | 현재 집합이 **상위 집합**인지 확인      | `O(n)`                                   |
| `IsProperSubsetOf(IEnumerable<T> other)`    | `ISet<T>`                   | 현재 집합이 **진 하위 집합**인지 확인   | `O(n)`                                   |
| `IsProperSupersetOf(IEnumerable<T> other)`  | `ISet<T>`                   | 현재 집합이 **진 상위 집합**인지 확인   | `O(n)`                                   |
| `Overlaps(IEnumerable<T> other)`            | `ISet<T>`                   | 공통 요소가 하나라도 있는지 확인        | `O(n)`                                   |
| `SetEquals(IEnumerable<T> other)`           | `ISet<T>`                   | 두 집합이 동일한 요소를 포함하는지 확인 | `O(n)`                                   |

### 고유연산들

| 메서드                                         | 설명                                                                  | 시간 복잡도 |
| ---------------------------------------------- | --------------------------------------------------------------------- | ----------- |
| `EnsureCapacity(int capacity)`                 | 내부 저장소를 확장하여 최소한 `capacity`개 요소를 저장할 수 있도록 함 | `O(n)`      |
| `TrimExcess()`                                 | 해시셋의 여유 공간을 줄임                                             | `O(n)`      |
| `RemoveWhere(Predicate<T> match)`              | 특정 조건을 만족하는 요소를 모두 제거                                 | `O(n)`      |
| `TryGetValue(T equalValue, out T actualValue)` | 값이 존재하면 반환 (성능 최적화)                                      | `O(1)`      |
| `CreateSetComparer()`                          | `HashSet<T>`의 맞춤 비교자를 반환                                     | `O(1)`      |

### 특이점

- ICollection의 Add와 ISet의 Add,, Add가 2번 나오는데, ICollection의 Add는 명시적구현으로 숨겨진다.
- 내부구현은 해시테이블로 이루어져있음. 

#### 왜..? 숨길필요성은 어디서나온거지?

구현체를 살펴보면 그 이유를 알수있는데, 코드를 봐보자.

```C#
public class HashSet<T> : ICollection<T>, ISet<T>
{
    // 일반적인 Add 메서드 (ISet<T>.Add를 구현)
    public bool Add(T item)
    {
        // 실제 내부적으로 항목을 추가하는 로직
    }

    // ICollection<T>.Add를 명시적 인터페이스 구현
    void ICollection<T>.Add(T item)
    {
        Add(item);  // 기존 Add 호출
    }
}

```

HashSet특성으로 중복이 없어야한다. 그래서 추가가 실패되었을때, bool을 리턴해야한다. 그래서 숨겨야할 필요성이 생긴다.

## `Dictionary<TKey, TValue>`

`public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback where TKey : notnull`

### 인터페이스 제공 연산들

| 프로퍼티     | 인터페이스                  | 설명                                                         | 시간 복잡도 |
| ------------ | --------------------------- | ------------------------------------------------------------ | ----------- |
| `Count`      | `ICollection<T>`            | ICollection<T>에 포함된 요소 수를 가져옵니다.                | `O(1)`      |
| `Keys`       | `IDictionary<TKey, TValue>` | Dictionary<TKey,TValue>의 키를 포함하는 컬렉션을 가져옵니다. | `O(1)`      |
| `Values`     | `IDictionary<TKey, TValue>` | Dictionary<TKey,TValue>의 값을 포함하는 컬렉션을 가져옵니다. | `O(1)`      |
| `Item[TKey]` | `IDictionary<TKey, TValue>` | 지정된 키에 연결된 값을 가져오거나 설정합니다.               | `O(1)`      |

| 메서드                                    | 인터페이스                                | 설명                                                                | 시간 복잡도                  |
| ----------------------------------------- | ----------------------------------------- | ------------------------------------------------------------------- | ---------------------------- |
| `Add(TKey key, TValue value)`             | `IDictionary<TKey, TValue>`               | 제공된 키와 값을 가진 요소를 IDictionary<TKey,TValue>에 추가합니다. | `O(1)` (평균), `O(n)` (최악) |
| `Remove(TKey key)`                        | `IDictionary<TKey, TValue>`               | 특정 키를 가진 요소 제거                                            | `O(1)` (평균), `O(n)` (최악) |
| `ContainsKey(TKey key)`                   | `IDictionary<TKey, TValue>`               | 특정 키 포함 여부 확인                                              | `O(1)`                       |
| `ContainsValue(TValue value)`             | 없음                                      | 특정 값 포함 여부 확인                                              | `O(n)`                       |
| `TryGetValue(TKey key, out TValue value)` | `IDictionary<TKey, TValue>`               | 키가 존재하면 값을 반환                                             | `O(1)`                       |
| `Clear()`                                 | `ICollection<KeyValuePair<TKey, TValue>>` | 모든 요소 제거                                                      | `O(n)`                       |
| `GetEnumerator()`                         | `IEnumerable<KeyValuePair<TKey, TValue>>` | 열거자 반환                                                         | `O(n)`                       |

### 고유연산들

| 프로퍼티   | 설명                                       | 시간 복잡도 |
| ---------- | ------------------------------------------ | ----------- |
| `Comparer` | 키 비교를 위한 `IEqualityComparer<T>` 반환 | `O(1)`      |

| 메서드                               | 설명                                                                                             | 시간 복잡도                              |
| ------------------------------------ | ------------------------------------------------------------------------------------------------ | ---------------------------------------- |
| `Remove(TKey key, out TValue value)` | Dictionary<TKey,TValue>에서 지정된 키를 갖는 값을 제거하고, value 매개 변수에 요소를 복사합니다. | .                                        |
| `EnsureCapacity(int capacity)`       | 내부 저장소를 확장하여 최소한 `capacity`개의 요소 저장 가능하도록 설정                           | `O(n)` (재할당 발생 시)                  |
| `TrimExcess()`                       | 해시테이블의 용량을 현재 요소 개수에 맞게 줄임                                                   | `O(n)`                                   |
| `TrimExcess(int capacity)`           | 지정된 개수에 맞춰 용량을 줄임                                                                   | `O(n)`                                   |
| `TryAdd(TKey key, TValue value)`     | 키가 없을 경우에만 추가                                                                          | `O(1)` (평균), `O(n)` (리사이징 발생 시) |

### 특이점

- 기존키가 있을때, Add로 추가하면 기존요소를 수정하지않음. `myCollection["myNonexistentKey"] = myValue`로 작성시 기존요소를 덮어씀.
- ContainsKey는 O(1), ContainsValue는 O(N)
- Keys는 O(1), Values도 O(1)

## `SortedSet<T>`

### 인터페이스 제공 연산들

| 프로퍼티 | 인터페이스       | 설명           | 시간 복잡도 |
| -------- | ---------------- | -------------- | ----------- |
| `Count`  | `ICollection<T>` | 요소 개수 반환 | `O(1)`      |

| 메서드                         | 인터페이스       | 설명                | 시간 복잡도 |
| ------------------------------ | ---------------- | ------------------- | ----------- |
| `Add(T item)`                  | `ISet<T>`        | 요소 추가           | `O(log n)`  |
| `Remove(T item)`               | `ISet<T>`        | 요소 제거           | `O(log n)`  |
| `Contains(T item)`             | `ISet<T>`        | 요소 포함 여부 확인 | `O(log n)`  |
| `Clear()`                      | `ICollection<T>` | 모든 요소 제거      | `O(n)`      |
| `CopyTo(T[] array, int index)` | `ICollection<T>` | 배열로 복사         | `O(n)`      |
| `GetEnumerator()`              | `IEnumerable<T>` | 열거자 반환         | `O(n)`      |

### 고유연산들

| 프로퍼티   | 설명                      | 시간 복잡도 |
| ---------- | ------------------------- | ----------- |
| `Comparer` | 정렬에 사용되는 개체 반환 | `O(1)`      |
| `Min`      | 가장 작은 요소 반환       | `O(1)`      |
| `Max`      | 가장 큰 요소 반환         | `O(1)`      |

| 메서드                                      | 설명                                    | 시간 복잡도 |
| ------------------------------------------- | --------------------------------------- | ----------- |
| `GetViewBetween(T lower, T upper)`          | 지정된 범위 내 요소를 포함하는 뷰 반환  | `O(log n)`  |
| `Reverse()`                                 | 내림차순으로 정렬된 열거자 반환         | `O(n)`      |
| `UnionWith(IEnumerable<T> other)`           | 다른 컬렉션과 합집합 수행               | `O(n)`      |
| `IntersectWith(IEnumerable<T> other)`       | 다른 컬렉션과 교집합 수행               | `O(n)`      |
| `ExceptWith(IEnumerable<T> other)`          | 다른 컬렉션의 요소를 제거               | `O(n)`      |
| `SymmetricExceptWith(IEnumerable<T> other)` | 대칭 차집합 연산 수행                   | `O(n)`      |
| `Overlaps(IEnumerable<T> other)`            | 다른 컬렉션과 겹치는 요소가 있는지 확인 | `O(n)`      |
| `SetEquals(IEnumerable<T> other)`           | 동일한 요소를 포함하는지 확인           | `O(n)`      |

### 특이점
내부구현이 RB트리 기반으로, 중복없는 정렬된 집합이다.  


## `SortedDictionary<TKey, TValue>`

### 인터페이스 제공 연산들

| 프로퍼티 | 인터페이스                                | 설명           | 시간 복잡도 |
| -------- | ----------------------------------------- | -------------- | ----------- |
| `Count`  | `ICollection<KeyValuePair<TKey, TValue>>` | 요소 개수 반환 | `O(1)`      |

| 메서드                                                  | 인터페이스                  | 설명                   | 시간 복잡도 |
| ------------------------------------------------------- | --------------------------- | ---------------------- | ----------- |
| `Add(TKey key, TValue value)`                           | `IDictionary<TKey, TValue>` | 키-값 쌍 추가          | `O(log n)`  |
| `Remove(TKey key)`                                      | `IDictionary<TKey, TValue>` | 키-값 쌍 제거          | `O(log n)`  |
| `ContainsKey(TKey key)`                                 | `IDictionary<TKey, TValue>` | 특정 키 포함 여부 확인 | `O(log n)`  |
| `ContainsValue(TValue value)`                           | `IDictionary<TKey, TValue>` | 특정 값 포함 여부 확인 | `O(n)`      |
| `Clear()`                                               | `ICollection<T>`            | 모든 요소 제거         | `O(n)`      |
| `CopyTo(KeyValuePair<TKey, TValue>[] array, int index)` | `ICollection<T>`            | 배열로 복사            | `O(n)`      |
| `GetEnumerator()`                                       | `IEnumerable<T>`            | 열거자 반환            | `O(n)`      |

### 고유연산들

| 프로퍼티   | 설명                           | 시간 복잡도 |
| ---------- | ------------------------------ | ----------- |
| `Comparer` | 키 정렬에 사용되는 비교자 반환 | `O(1)`      |
| `Keys`     | 정렬된 키 목록 반환            | `O(1)`      |
| `Values`   | 정렬된 값 목록 반환            | `O(1)`      |

| 메서드                                    | 설명                           | 시간 복잡도 |
| ----------------------------------------- | ------------------------------ | ----------- |
| `TryGetValue(TKey key, out TValue value)` | 키에 대한 값을 안전하게 가져옴 | `O(log n)`  |

### SortedDictionary란?
우선 Dictionary는 해시테이블로 구현이 되어있고, 해시테이블의 시간복잡도는 일반적으로 O(1)이지만, 최악의 경우는 O(N)입니다.  
하지만 SortedDictionary는 모든케이스에 대해서 O(LogN) 입니다.  
SortedDictionary는 내부구현이 RB트리로 구현되어있는데, RB트리는 모든케이스에 대해 O(LogN)의 시간복잡도를 가지기 때문입니다.  


### 특이점

- ContainsKey는 O(LogN), ContainsValue는 O(N)

## `PriorityQueue<TKey, TValue>`

`public class PriorityQueue<TElement,TPriority>`

| 프로퍼티 | 설명                          | 시간복잡도 |
| -------- | ----------------------------- | ---------- |
| `Count`  | 현재 큐에 있는 요소 개수 반환 | **O(1)**   |

| 메서드                                          | 설명                                           | 시간복잡도                |
| ----------------------------------------------- | ---------------------------------------------- | ------------------------- |
| `Enqueue(TElement element, TPriority priority)` | 요소를 우선순위와 함께 추가                    | **O(log n)**              |
| `Dequeue()`                                     | 가장 높은 우선순위를 가진 요소를 제거하고 반환 | **O(log n)**              |
| `Peek()`                                        | 가장 높은 우선순위를 가진 요소를 반환 (제거 X) | **O(1)**                  |
| `Clear()`                                       | 모든 요소 제거                                 | **O(1)**                  |
| `UnorderedItems`                                | 내부 배열을 반환 (순서 보장 X)                 | **O(n)**                  |
| `EnsureCapacity(int capacity)`                  | 내부 저장소 크기를 확장                        | **O(n)** (재할당 발생 시) |
| `TrimExcess()`                                  | 내부 저장소 크기를 `Count`에 맞게 줄임         | **O(n)**                  |

## 기본동작은 최소힙

우선순위가 낮은숫자가 먼저나옴. 힙구조

### 특이점

인터페이스 상속이 없넹..

# 에필로그

c++STL과 C#의컬렉션을 비교분석해보면서, 컬렉션과 전혀관련없어보이는, Contains는 왜있지? 라는 의문에서 시작되었지만,  
상당히 글이 길어졌다. 하지만 기분은 좋은게, 새로운사실들을 많이 알게되었다.  
명시적 인터페이스 구현이라던가..  
Clear가 사실 Array.Clear()를 호출하고있어서,O(1)아니라, O(n)이라던가..  
FindIndex로 체크하는게 결국, Exist함수를 호출하는것과 같은거라던가..
쓰다보니 지쳐서 gpt도움을 많이받았지만,  
왜 이런건 아무도 정리를 안했을까 생각하며 정리했지만, 결국엔...
정리문서의 컬렉션들을,,주요 메서드만 남기고싶다는 생각이 들게되었다.
튜닝의 끝은 순정이라말이 떠올랐다.

# 참고링크

C# 구현의 참고코드를 검색해볼수있다.
https://referencesource.microsoft.com/
