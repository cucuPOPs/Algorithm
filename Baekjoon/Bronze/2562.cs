class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int[] arr = new int[9];
        int max = arr[0];
        int maxIndex = 0;
        for (int i = 0; i < 9; ++i)
        {
            arr[i] = int.Parse(sr.ReadLine());
            if (max < arr[i])
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        sw.WriteLine(max);
        sw.WriteLine(maxIndex + 1);

        sw.Flush();
    }
}