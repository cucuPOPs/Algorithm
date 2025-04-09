class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int vertex = int.Parse(sr.ReadLine());
        List<int>[] adj = new List<int>[vertex + 1];

        for (int i = 1; i <= vertex; i++)
        {
            adj[i] = new List<int>();
        }

        int[] p = new int[vertex + 1];
        Array.Fill(p, -1);
        for (int i = 0; i < vertex - 1; i++)
        {
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            adj[arr[0]].Add(arr[1]);
            adj[arr[1]].Add(arr[0]);
        }
        
        //DFS
        /*
        DFS(1);
        void DFS(int cur)
        {
            foreach (int next in adj[cur])
            {
                if (p[cur] == next) continue;
                p[next] = cur;
                DFS(next);
            }
        }
        */
        

        //BFS
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        p[1] = 0;
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            foreach (int next in adj[cur])
            {
                if (p[cur] == next) continue;
                q.Enqueue(next);
                p[next] = cur;
            }
        }

        for (int i = 2; i <= vertex; i++)
        {
            sw.WriteLine(p[i]);
        }

        sw.Flush();
    }
}