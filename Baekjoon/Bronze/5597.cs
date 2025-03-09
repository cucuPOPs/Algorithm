class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        bool[] check = new bool[30];
        for (int i = 0; i < 28; i++)
        {
            int a = int.Parse(sr.ReadLine());
            check[a - 1] = true;
        }

        for (int i = 0; i < check.Length; i++)
        {
            if (!check[i])
                sw.WriteLine(i + 1);
        }
        sw.Flush();
    }
}