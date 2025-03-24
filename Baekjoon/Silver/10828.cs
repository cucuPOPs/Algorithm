class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Stack<string> stack = new Stack<string>();

        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            string command = s[0];

            switch (command)
            {
                case "push":
                    stack.Push(s[1]);
                    break;
                case "pop":
                    sw.WriteLine(stack.Count > 0 ? stack.Pop() : "-1");
                    break;
                case "size":
                    sw.WriteLine(stack.Count);
                    break;
                case "empty":
                    sw.WriteLine(stack.Count == 0 ? "1" : "0");
                    break;
                case "top":
                    sw.WriteLine(stack.Count > 0 ? stack.Peek() : "-1");
                    break;
            }
        }

        sw.Flush();
    }
}