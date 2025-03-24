class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        Stack<char> stack = new Stack<char>();

        while (true)
        {
            string s = sr.ReadLine();
            if (s == ".") break;
            stack.Clear();
            bool isBalanced = true;
            foreach (char c in s)
            {
                if (c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (c == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            //여는괄호만 있는경우, false.
            if (isBalanced)
                isBalanced = stack.Count == 0 ? true : false;

            sw.WriteLine(isBalanced ? "yes" : "no");
        }
        sw.Flush();
    }
}