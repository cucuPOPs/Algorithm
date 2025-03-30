class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Stack<char> leftStack = new Stack<char>();
        Stack<char> rightStack = new Stack<char>();

        while (n-- > 0)
        {
            leftStack.Clear();
            rightStack.Clear();
            string s = sr.ReadLine();


            foreach (char ch in s)
            {
                if (ch == '-')
                {
                    if (leftStack.Count > 0)
                        leftStack.Pop();
                }
                else if (ch == '<')
                {
                    if (leftStack.Count > 0)
                        rightStack.Push(leftStack.Pop());
                }
                else if (ch == '>')
                {
                    if (rightStack.Count > 0)
                        leftStack.Push(rightStack.Pop());
                }
                else
                {
                    leftStack.Push(ch);
                }
            }

            while (leftStack.Count > 0)
                rightStack.Push(leftStack.Pop());

            while (rightStack.Count > 0)
                sw.Write(rightStack.Pop());

            sw.WriteLine();
        }

        sw.Flush();
    }
}