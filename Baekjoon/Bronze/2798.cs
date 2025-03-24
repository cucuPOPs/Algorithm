class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);

        int[] cards = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int maxSum = 0;
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    int sum = cards[i] + cards[j] + cards[k];

                    if (sum <= m)
                    {
                        maxSum = maxSum < sum ? sum : maxSum;
                    }
                }
            }
        }
        sw.WriteLine(maxSum);
        sw.Flush();
    }
}