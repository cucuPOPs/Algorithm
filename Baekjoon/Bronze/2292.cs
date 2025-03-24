class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        if (n == 1)
        {
            sw.WriteLine(1);
        }
        else
        {
            //1...1
            //2...2~7
            //3...8~19
            //4...20~37
            //5...38~61
            int distance = 1;
            int max = 1;
            while (true)
            {
                if (n <= max) break;
                max += 6 * distance;
                distance++;
            }
            sw.WriteLine(distance);
        }
        sw.Flush();
    }
}