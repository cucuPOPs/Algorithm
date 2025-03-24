class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        (int kg, int cm)[] a = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            string[] s = sr.ReadLine().Split();
            a[i] = (int.Parse(s[0]), int.Parse(s[1]));
        }

        int[] rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            rank[i] = 1;
            for (int j = 0; j < n; j++)
            {
                if (i != j && a[i].kg < a[j].kg && a[i].cm < a[j].cm)
                {
                    rank[i]++;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            sw.Write(rank[i] + " ");
        }

        sw.Flush();
    }
}