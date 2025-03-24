class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int k = int.Parse(s[0]);
        int n = int.Parse(s[1]);

        long[] cables = new long[k];
        for (int i = 0; i < k; i++)
        {
            cables[i] = long.Parse(sr.ReadLine());
        }

        // 이분 탐색을 위한 범위 설정
        long left = 1;
        long right = cables.Max();
        long result = 0;

        while (left <= right)
        {
            long mid = (left + right) / 2;
            long count = 0;

            // mid 길이로 잘랐을 때 몇 개를 만들 수 있는지 계산
            foreach (long cable in cables)
            {
                count += cable / mid;
            }

            // N개 이상 만들 수 있으면, 더 긴 길이를 시도
            if (count >= n)
            {
                result = mid;  // 최대 길이 갱신
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        sw.WriteLine(result);
        sw.Flush();
    }
}