class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] a = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(sr.ReadLine());
        }

        //정렬.
        Array.Sort(a);

        //산술평균.반올림.
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += a[i];
        }
        sw.WriteLine((int)(Math.Round((double)sum / n)));

        //중앙값
        sw.WriteLine(a[n / 2]);



        //최빈값
        int[] count = new int[8001];
        for (int i = 0; i < n; i++)
        {
            count[a[i] + 4000]++;
        }

        int maxCount = 0;
        int maxIndex = 0;
        int maxIndex2 = 0;
        for (int i = 0; i < count.Length; i++)
        {
            if (maxCount < count[i])
            {
                maxCount = count[i];
                maxIndex = i;
                maxIndex2 = i;
            }
            else if (maxCount == count[i] && maxIndex == maxIndex2)
            {
                maxIndex2 = i;
            }
        }
        sw.WriteLine(maxIndex2 - 4000);


        //범위
        sw.WriteLine(a[n - 1] - a[0]);
        sw.Flush();
    }
}