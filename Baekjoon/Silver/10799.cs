class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string s = sr.ReadLine();
        Stack<char> stack = new Stack<char>();
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push('(');
            }
            else // ')'
            {
                stack.Pop();
                if (s[i - 1] == '(')
                {
                    // 레이저인 경우
                    result += stack.Count;
                }
                else
                {
                    // 막대기의 끝
                    result += 1;
                }
            }
        }

        sw.WriteLine(result);

        sw.Flush();
    }
}