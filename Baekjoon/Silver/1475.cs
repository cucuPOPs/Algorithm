class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] a = new int[10];
        while (n > 0)
        {
            a[n % 10]++;
            n /= 10;
        }

        int max = 0;
        for (int i = 0; i < 10; i++)
        {
            if (i == 6 || i == 9)
                continue;
            max = Math.Max(max, a[i]);
        }
        max = Math.Max(max, (a[6] + a[9] + 1) / 2);

        sw.Write(max);
        sw.Flush();
    }
}