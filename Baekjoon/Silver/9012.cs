class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        while (n-- > 0)
        {
            string s = sr.ReadLine();
            sw.WriteLine(IsValid(s) ? "YES" : "NO");
        }
        sw.Flush();
    }

    static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (var t in s)
        {
            if (t == '(') stack.Push(t);
            else
            {
                if (stack.Count == 0) return false;
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}