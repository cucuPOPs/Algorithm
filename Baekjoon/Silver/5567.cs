class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int vertex = int.Parse(sr.ReadLine());
        int edge = int.Parse(sr.ReadLine());
        List<int>[] adj = new List<int>[vertex + 1];
        for (int i = 1; i <= vertex; i++)
        {
            adj[i] = new List<int>();
        }

        for (int i = 0; i < edge; i++)
        {
            string[] input = sr.ReadLine().Split();
            int u = int.Parse(input[0]);
            int v = int.Parse(input[1]);
            adj[u].Add(v);
            adj[v].Add(u);
        }


        int[] dist = new int[vertex + 1];
        Array.Fill(dist, -1);
        int count = 0;
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        dist[1] = 0;
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            foreach (int next in adj[cur])
            {
                if (dist[next] != -1) continue;
                dist[next] = dist[cur] + 1;
                q.Enqueue(next);
            }
        }

        for (int i = 1; i <= vertex; i++)
        {
            if (dist[i] > 0 && dist[i] < 3) count++;
        }

        sw.Write(count);
        sw.Flush();
    }
}