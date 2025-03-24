using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        List<string> result = new List<string>();

        int current = 1; // 스택에 넣을 숫자
        bool possible = true; // 가능한지 판별

        for (int i = 0; i < n; i++)
        {
            int target = int.Parse(Console.ReadLine());

            // 목표 숫자까지 Push
            while (current <= target)
            {
                stack.Push(current++);
                result.Add("+");
            }

            // Pop 수행
            if (stack.Peek() == target)
            {
                stack.Pop();
                result.Add("-");
            }
            else
            {
                possible = false;
                break;
            }
        }

        // 결과 출력
        if (possible)
            Console.WriteLine(string.Join("\n", result));
        else
            Console.WriteLine("NO");
    }
}
