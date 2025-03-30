class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int k = int.Parse(s[1]);

        Queue<int> queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            queue.Enqueue(i);
        }

        sw.Write("<");
        while (queue.Count > 1)
        {
            for (int i = 0; i < k - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            sw.Write($"{queue.Dequeue()}, ");
        }

        sw.Write($"{queue.Dequeue()}>");

        sw.Flush();
    }
}