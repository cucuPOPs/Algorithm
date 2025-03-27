class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            string[] s = sr.ReadLine().Split();
            int zeroCount = 0;
            foreach (string ss in s)
            {
                if (ss == "0") zeroCount++;
            }

            if (zeroCount == 1) sw.WriteLine("A");
            else if (zeroCount == 2) sw.WriteLine("B");
            else if (zeroCount == 3) sw.WriteLine("C");
            else if (zeroCount == 4) sw.WriteLine("D");
            else sw.WriteLine("E");
        }

        sw.Flush();
    }
}