[Back(메인으로)](/README.md)  


# Foreach

## IEnumerable을 받음

foreach는 `IEnumerable<T>`를 구현하는 인스턴스를 받는다.  
`Stack<int> stack = new Stack<int>();`도 IEnumerable을 구현하고있다.  
그래서, `foreach(var i in stack)` 이렇게 순회도 가능하다.

## 원본수정이 불가능하다

foreach는 출력목적에 적합하다.

## 순회중에 컬렉션 변경이되면, InvalidOperationException 발생.

그래서, `foreach(var item in ~~~.ToList())`와같이 ToList()나 ToArray()같은 복사본을 생성하여, 순회.

# string클래스

## concat의 재발견

본디 concat은 string끼리 붙여주는 메소드로 알고있었따.  
concat의 명세를보니, IEnumerable를 받는다.  
그래서, `string.concat(stack)`도 가능하다.  
또한 내부적으로 stringbuilder를 사용한다.

#### 그렇다면, 출력을 찍을때, foreach가 빠를까, concat이 빠를까...?
둘다 IEnumerable을 받는건 공통이고, concat이 stringbuilder를 사용해 좀더 입출력에 장점이 있다고 말할수있곘지만, foreach에서도 stringbuilder를 선언하고 사용하는게 가능하니, 비슷한 수준이라 생각하는게 맞는거같다.

## join은 이럴때 유용하다

list가 있다고 치자. `1,2,3,4,5` 처럼 출력을 하려고할때, 마지막 콤마처리가 애매하다.  
이럴때, Join을 사용하면 깔끔하게 처리가능하다.  
`string.Join(",", list);`

# string 비교보다, char비교가 빠르다

char는 값타입이고, string은 참조타입.
`string s1="A"; string s2="B";`를 비교하려할때, `if(s1==s2)`느리고, `if(s1[0]==s2[0])`이 빠르다.

# 직접구현 vs Math.Abs()

```C#
static int myAbs(int a)
{
    return a < 0 ? -a : a;
}
```

직접구현한게 더 빠르다.

# 직접구현 vs Math.Round

```C#
//올림
static int RoundUp(double d)
{
    if (d % 1 != 0)
        return (int)d + 1;
    else
        return (int)d;
}
//반올림
static int myRound(double d)
{
    if (d % 1 < 0.5)
        return (int)d;
    else
        return (int)d + 1;
}
```

직접구현이 속도가 더 빠르다.  
C#에서 Math.Round의 반올림은 [은행가 반올림](/Baekjoon/Silver/18110.md) 방식으로 처리된다.  
수학적 반올림과 차이가있다.  



# Array 클래스
유용하다고 느낀 함수들을 정리해보았다.
```C#
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 8, 1, 3 };

        // 1. 배열 정렬 (Sort)
        Array.Sort(numbers);
        Console.WriteLine("Sorted: " + string.Join(", ", numbers)); // 1, 2, 3, 5, 8

        // 2. 배열 초기화 (Clear)
        Array.Clear(numbers);
        Console.WriteLine("Cleared: " + string.Join(", ", numbers)); // 0, 0, 0, 0, 0

        // 3. 모든 요소를 특정 값으로 설정 (Fill)
        Array.Fill(numbers, 9);
        Console.WriteLine("Filled: " + string.Join(", ", numbers)); // 9, 9, 9, 9, 9

        //4. 빈배열 선언
        int[] good = Array.Empty<int>();
        int[] notbad = new int[0];
        //유니티의 Vector3.zero같은, 캐싱되어있는것을 참조하기때문.
    }
}

```
# Enumerable 클래스
```C#
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //Range
        var numbers = Enumerable.Range(1, 5); // 1부터 시작해서 5개 생성
        Console.WriteLine(string.Join(", ", numbers)); // 출력: 1, 2, 3, 4, 5

        //Repeat
        var repeated = Enumerable.Repeat("Hello", 3);
        Console.WriteLine(string.Join(", ", repeated)); // 출력: Hello, Hello, Hello

        //SelectMany
        string[] phrases = { "Hello World", "C# LINQ" };
        var words = phrases.SelectMany(p => p.Split(' '));
        Console.WriteLine(string.Join(", ", words)); // 출력: Hello, World, C#, LINQ

        //Aggregate
        int[] numbers = { 1, 2, 3, 4 };
        int sum = numbers.Aggregate((total, num) => total + num);
        Console.WriteLine(sum); // 출력: 10

        //GroupBy
        string[] words = { "apple", "banana", "apricot", "blueberry", "avocado" };
        var groups = words.GroupBy(w => w[0]); // 첫 글자로 그룹화

        foreach (var group in groups)
        {
            Console.WriteLine($"Group {group.Key}: {string.Join(", ", group)}");
            //출력
            //Group a: apple, apricot, avocado
            //Group b: banana, blueberry
        }
        
    }
}

```