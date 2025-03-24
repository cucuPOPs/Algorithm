class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        sr.ReadLine();
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        bool[] isPrime = new bool[1001];
        for (int i = 2; i < 1001; i++) isPrime[i] = true;

        // 에라토스테네스의 체
        for (int i = 2; i * i <= 1000; i++)
        {
            if (isPrime[i])
            {
                //배수제거.
                for (int j = i * i; j < 1001; j += i)
                    isPrime[j] = false;
            }
        }


        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (isPrime[arr[i]]) count++;
        }
        sw.WriteLine(count);
        sw.Flush();
    }
}