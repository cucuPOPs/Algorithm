class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);
        int[,] a = new int[n, m];
        for (int i = 0; i < 2 * n; i++)
        {
            string[] t = sr.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                a[i % n, j] += int.Parse(t[j]);
            }
        }


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sw.Write("{0} ", a[i, j]);
            }
            sw.WriteLine();
        }
        sw.Flush();
    }
}