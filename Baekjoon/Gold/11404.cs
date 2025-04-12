class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int v = int.Parse(sr.ReadLine());
        int e = int.Parse(sr.ReadLine());

        const int INF = int.MaxValue / 2;
        int[,] dist = new int[v + 1, v + 1];
        for (int i = 1; i <= v; i++)
        for (int j = 1; j <= v; j++)
            dist[i, j] = INF;

        for (int i = 1; i <= v; i++)
            dist[i, i] = 0;

        for (int i = 0; i < e; i++)
        {
            string[] s = sr.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);
            int cost = int.Parse(s[2]);
            dist[a, b] = Min(dist[a, b], cost);
        }

        for (int k = 1; k <= v; k++)
        {
            for (int i = 1; i <= v; i++)
            {
                for (int j = 1; j <= v; j++)
                {
                    if (dist[i, k] + dist[k, j] < dist[i, j])
                        dist[i, j] = dist[i, k] + dist[k, j];
                }
            }
        }

        for (int i = 1; i <= v; i++)
        {
            for (int j = 1; j <= v; j++)
            {
                sw.Write(dist[i, j] == INF ? 0 : dist[i, j]);
                sw.Write(' ');
            }

            sw.Write('\n');
        }

        sw.Flush();
    }

    static int Min(int a, int b)
    {
        return a < b ? a : b;
    }
}