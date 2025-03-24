
class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] input = sr.ReadLine().Split();
        int st = int.Parse(input[0]);
        int ed = int.Parse(input[1]);

        bool[] isPrime = new bool[ed + 1];
        for (int i = 2; i <= ed; i++) isPrime[i] = true;

        // 에라토스테네스의 체
        for (int i = 2; i * i <= ed; i++)
        {
            if (isPrime[i])
            {
                //배수제거.
                for (int j = i * i; j <= ed; j += i)
                    isPrime[j] = false;
            }
        }

        for (int i = st; i <= ed; i++)
        {
            if (isPrime[i]) sw.WriteLine(i);
        }
        sw.Flush();
    }
}