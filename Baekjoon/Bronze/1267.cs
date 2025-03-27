class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        sr.ReadLine();//n은 버린다.
        int[] calls = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int ySum = 0;//영식
        int mSum = 0;//민식

        foreach (int call in calls)
        {
            ySum += ((call / 30) + 1) * 10;
            mSum += ((call / 60) + 1) * 15;
        }

        if (ySum < mSum)
            sw.WriteLine($"Y {ySum}");
        else if (ySum > mSum)
            sw.WriteLine($"M {mSum}");
        else
            sw.WriteLine($"Y M {ySum}");

        sw.Flush();
    }
}