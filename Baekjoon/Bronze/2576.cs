class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int sumOdd = 0;
        int minOdd = int.MaxValue;

        for (int i = 0; i < 7; i++)
        {
            int num = int.Parse(sr.ReadLine());
            if (num % 2 == 1)
            {
                sumOdd += num;
                if (num < minOdd)
                    minOdd = num;
            }
        }

        if (sumOdd == 0)
            sw.WriteLine(-1);
        else
        {
            sw.WriteLine(sumOdd);
            sw.WriteLine(minOdd);
        }
        sw.Flush();
    }
}