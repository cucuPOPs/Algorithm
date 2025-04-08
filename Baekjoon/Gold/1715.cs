class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        while (n-- > 0)
        {
            int x = int.Parse(sr.ReadLine());
            q.Enqueue(x, x);
        }

        int total = 0;
        while (q.Count > 1)
        {
            int a = q.Dequeue();
            int b = q.Dequeue();
            int sum = a + b;
            total += sum;
            if (q.Count == 0) break;
            q.Enqueue(sum, sum);
        }
        sw.WriteLine(total);

        sw.Flush();
    }
}