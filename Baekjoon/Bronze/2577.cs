class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int num = 1;
        for (int i = 0; i < 3; i++)
        {
            num *= int.Parse(sr.ReadLine());
        }

        int[] arr = new int[10];
        while (num != 0)
        {
            arr[num % 10]++;
            num /= 10;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            sw.WriteLine(arr[i]);
        }


        sw.Flush();
    }
}