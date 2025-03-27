class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] n = new int[5];

        double ave = 0;
        for (int i = 0; i < 5; i++)
        {
            n[i] = int.Parse(sr.ReadLine());
            ave += n[i];
        }
        ave /= 5;
        sw.WriteLine(ave);

        Array.Sort(n);
        sw.WriteLine(n[2]);

        sw.Flush();
    }
}