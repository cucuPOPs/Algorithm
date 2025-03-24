class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= n; i++)
            q.Enqueue(i);

        int last = 0;
        while(true)
        {
            last = q.Dequeue();
            if (q.Count == 0) break;
            q.Enqueue(q.Dequeue());
        }

        sw.WriteLine(last);
        sw.Flush();
    }
}