class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
                sw.Write('*');

            for (int j = 0; j < (n - i - 1) * 2; j++)
                sw.Write(' ');

            for (int j = 0; j < i + 1; j++)
            {
                sw.Write('*');
            }
            sw.Write('\n');
        }

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < i + 1; j++)
                sw.Write('*');

            for (int j = 0; j < (n - i - 1) * 2; j++)
                sw.Write(' ');

            for (int j = 0; j < i + 1; j++)
            {
                sw.Write('*');
            }
            sw.Write('\n');
        }

        sw.Flush();
    }
}