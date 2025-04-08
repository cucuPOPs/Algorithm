class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int tc = int.Parse(sr.ReadLine());
        while (tc-- > 0)
        {
            int n = int.Parse(sr.ReadLine());
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            PriorityQueue<long, long> q = new PriorityQueue<long, long>();
            for (int i = 0; i < arr.Length; i++)
            {
                q.Enqueue(arr[i], arr[i]);
            }

            long total = 0;
            while (q.Count > 1)
            {
                long a = q.Dequeue();
                long b = q.Dequeue();
                long sum = a + b;
                total += sum;
                q.Enqueue(sum, sum);
            }

            sw.WriteLine(total);
        }

        sw.Flush();
    }
}