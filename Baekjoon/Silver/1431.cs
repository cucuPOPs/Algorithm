class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장 빠른 속도.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = sr.ReadLine();
        }

        Array.Sort(arr, (x, y) =>
        {
            if (x.Length == y.Length)
            {
                int sumX = 0, sumY = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    if ('0' <= x[i] && x[i] <= '9') sumX += x[i] - '0';
                    if ('0' <= y[i] && y[i] <= '9') sumY += y[i] - '0';
                }

                if (sumX == sumY)
                {
                    return x.CompareTo(y);
                }
                else
                {
                    return sumX.CompareTo(sumY);
                }
            }
            else
            {
                return x.Length.CompareTo(y.Length);
            }
        });

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(arr[i]);
        }

        sw.Flush();
    }
}