class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] score = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int max = score[0];
        for (int i = 1; i < n; i++)
        {
            if (max < score[i]) max = score[i];
        }
        float sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += 1f * score[i] / max * 100;
        }
        sw.WriteLine(sum / n);
        sw.Flush();
    }
}