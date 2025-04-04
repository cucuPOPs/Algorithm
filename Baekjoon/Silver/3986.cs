class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int goodWordCount = 0;

        for (int i = 0; i < n; i++)
        {
            string word = sr.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char c in word)
            {
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            if (stack.Count == 0)
            {
                goodWordCount++;
            }
        }

        sw.WriteLine(goodWordCount);

        sw.Flush();
    }
}