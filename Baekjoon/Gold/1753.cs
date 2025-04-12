class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] ve = sr.ReadLine().Split();
        int v = int.Parse(ve[0]);
        int e = int.Parse(ve[1]);
        int start = int.Parse(sr.ReadLine());
        const int INF = int.MaxValue;
        int[] dist = new int[v + 1];
        Array.Fill(dist, INF);

        List<(int cost, int v)>[] adj = new List<(int, int)>[v + 1];
        for (int i = 1; i <= v; i++)
        {
            adj[i] = new List<(int, int)>();
        }

        for (int i = 0; i < e; i++)
        {
            string[] s = sr.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);
            int cost = int.Parse(s[2]);
            adj[a].Add((cost, b));
        }

        PriorityQueue<(int cost, int v), int> pq = new PriorityQueue<(int, int), int>(); //priority: cost
        dist[start] = 0;
        pq.Enqueue((0, start), 0);

        while (pq.Count > 0)
        {
            var (curDist, cur) = pq.Dequeue();

            // 이미 더 짧은 거리로 방문했다면 무시
            if (dist[cur] < curDist) continue;

            foreach (var (cost, next) in adj[cur])
            {
                int newDist = dist[cur] + cost;
                if (newDist < dist[next])
                {
                    dist[next] = newDist;
                    pq.Enqueue((newDist, next), newDist);
                }
            }
        }

        for (int i = 1; i <= v; i++)
        {
            sw.WriteLine(dist[i] == INF ? "INF" : dist[i].ToString());
        }

        sw.Flush();
    }
}