class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int sum = 0;
        Stack<int> stack = new Stack<int>();
        while (n-- > 0)
        {
            int read = int.Parse(sr.ReadLine());
            if (read == 0)
            {
                sum -= stack.Pop();
            }
            else
            {
                stack.Push(read);
                sum += read;
            }
        }
        sw.WriteLine(sum);
        sw.Flush();
    }
}