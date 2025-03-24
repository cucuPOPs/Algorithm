class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static (int pre, int nxt)[] arr = new (int, int)[5002];
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] tSize = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        string[] s = sr.ReadLine().Split();
        int t = int.Parse(s[0]);
        int p = int.Parse(s[1]);

        int tSum = 0;
        for (int i = 0; i < tSize.Length; i++)
        {
            tSum += tSize[i] / t;
            if (tSize[i] % t != 0) tSum += 1;
        }

        sw.WriteLine(tSum);
        sw.WriteLine($"{n / p} {n % p}");


        sw.Flush();
    }
}