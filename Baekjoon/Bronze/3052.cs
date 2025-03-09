class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        bool[] b = new bool[42];
        int tc = 10;
        while (tc-- > 0)
        {
            int num = int.Parse(sr.ReadLine());
            b[num % 42] = true;
        }


        int count = 0;
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i]) count++;
        }
        sw.WriteLine(count);
        sw.Flush();
    }
}