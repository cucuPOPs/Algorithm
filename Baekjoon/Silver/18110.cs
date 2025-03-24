class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        int[] difficulty = new int[31]; // 난이도 1이상 30이하
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(sr.ReadLine());
            difficulty[t]++;
        }

        int rounded = myRound(n * 0.15); // 반올림된 제외 개수

        // 하위 15% 제외
        int excludeLeft = rounded;
        for (int i = 1; i < 31; i++)
        {
            if (excludeLeft <= 0) break;
            if (difficulty[i] > 0)
            {
                if (difficulty[i] <= excludeLeft)
                {
                    excludeLeft -= difficulty[i];
                    difficulty[i] = 0;
                }
                else
                {
                    difficulty[i] -= excludeLeft;
                    excludeLeft = 0;
                }
            }
        }

        // 상위 15% 제외
        int excludeRight = rounded;
        for (int i = 30; i >= 1; i--)
        {
            if (excludeRight <= 0) break;
            if (difficulty[i] > 0)
            {
                if (difficulty[i] <= excludeRight)
                {
                    excludeRight -= difficulty[i];
                    difficulty[i] = 0;
                }
                else
                {
                    difficulty[i] -= excludeRight;
                    excludeRight = 0;
                }
            }
        }

        double sum = 0;
        int count = 0;
        for (int i = 1; i < 31; i++)
        {
            sum += i * difficulty[i];
            count += difficulty[i];
        }

        //0으로 나누기 방어.
        sw.WriteLine(count > 0 ? myRound(sum / count) : 0);
        sw.Flush();
    }

    static int myRound(double d)
    {
        if (d % 1 < 0.5)
            return (int)d;
        else
            return (int)d + 1;
    }
}