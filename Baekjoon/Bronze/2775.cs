class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int t = int.Parse(sr.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int k = int.Parse(sr.ReadLine());
            int n = int.Parse(sr.ReadLine());

            int[,] arr = new int[k + 1, n + 1];

            //0층.1호부터.
            for (int j = 1; j <= n; j++)
            {
                arr[0, j] = j;
            }



            for (int kk = 1; kk <= k; kk++)
            {
                for (int nn = 1; nn <= n; nn++)
                {
                    arr[kk, nn] = arr[kk - 1, nn] + arr[kk, nn - 1];

                }
            }
            sw.WriteLine(arr[k, n]);
        }


        sw.Flush();
    }
}