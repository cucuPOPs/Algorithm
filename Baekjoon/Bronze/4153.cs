class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        const string WRONG = "wrong";
        const string RIGHT = "right";

        while (true)
        {
            int[] a = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (a[0] + a[1] + a[2] == 0) break;

            int max = a[0];
            if (max < a[1])
                max = a[1];
            if (max < a[2])
                max = a[2];
            long temp = a[0] * a[0] + a[1] * a[1] + a[2] * a[2] - 2 * max * max;
            sw.WriteLine(temp == 0 ? RIGHT : WRONG);
        }

        sw.Flush();
    }
}