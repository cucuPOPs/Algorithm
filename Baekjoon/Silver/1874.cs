class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Stack<int> stack = new Stack<int>();
        StringBuilder sb = new StringBuilder();
        int current = 1;
        bool possible = true;

        for (int i = 0; i < n; i++)
        {
            int target = int.Parse(sr.ReadLine());

            while (current <= target)
            {
                stack.Push(current++);
                sb.AppendLine("+");
            }

            if (stack.Peek() == target)
            {
                stack.Pop();
                sb.AppendLine("-");
            }
            else
            {
                possible = false;
                break;
            }
        }

        if (possible)
            sw.WriteLine(sb.ToString());
        else
            sw.WriteLine("NO");

        sw.Flush();
    }


}