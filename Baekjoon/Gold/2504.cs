class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string input = sr.ReadLine();
        Stack<char> stack = new Stack<char>(); 
        int result = 0; // 최종 결과 값
        int temp = 1; // 현재 괄호의 곱셈 값을 추적하는 변수

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == '(')
            {
                stack.Push(c);
                temp *= 2;
            }
            else if (c == '[')
            {
                stack.Push(c);
                temp *= 3;
            }
            else if (c == ')')
            {
                // 잘못된 괄호열
                if (stack.Count == 0 || stack.Peek() != '(')
                {
                    result = 0;
                    break;
                }

                // 바로 이전 문자가 '('라면 현재 temp 값을 결과에 추가
                if (input[i - 1] == '(')
                    result += temp;

                stack.Pop(); // '(' 제거
                temp /= 2; // 닫을 때는 다시 원래 값으로 나누어 복구
            }
            else if (c == ']')
            {
                // 잘못된 괄호열
                if (stack.Count == 0 || stack.Peek() != '[')
                {
                    result = 0;
                    break;
                }

                // 바로 이전 문자가 '['라면 현재 temp 값을 결과에 추가
                if (input[i - 1] == '[')
                    result += temp;

                stack.Pop(); // '[' 제거
                temp /= 3; // 닫을 때 다시 원래 값으로 나누어 복구
            }
        }

        // 스택이 비어 있어야 정상적인 괄호열, 남아 있으면 잘못된 괄호열
        sw.WriteLine(stack.Count == 0 ? result : 0);
        sw.Flush();
    }
}