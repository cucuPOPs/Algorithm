class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static int[] count = new int[2_000_002];
    //카운팅 소팅
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(sr.ReadLine());
            count[num + 1_000_000]++;
        }

        for (int i = 0; i <= 2_000_000; i++)
        {
            while (count[i] > 0)
            {
                sw.WriteLine(i - 1_000_000);
                count[i]--;
            }
        }


        sw.Flush();
    }
}