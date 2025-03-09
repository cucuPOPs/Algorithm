class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        string[] s = sr.ReadLine().Split();

        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(s[i]);
            if (max < num) max = num;
            if (min > num) min = num;
        }
        sw.WriteLine($"{min} {max}");
        sw.Flush();
    }
}