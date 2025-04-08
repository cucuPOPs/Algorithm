class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        PriorityQueue<int, int> q = new PriorityQueue<int, int>();
        for (int i = 0; i < n; i++)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int j = 0; j < n; j++)
            {
                q.Enqueue(arr[j], arr[j]);
                if (q.Count > n)
                    q.Dequeue(); // 가장 작은 수 제거
            }
        }

        sw.WriteLine(q.Dequeue());
        sw.Flush();
    }
}