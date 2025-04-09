class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int vertex = int.Parse(s[0]);
        int edge = int.Parse(s[1]);

        int[,] adj = new int[vertex + 1, vertex + 1];
        for (int i = 0; i < edge; i++)
        {
            s = sr.ReadLine().Split();
            int a = int.Parse(s[0]);
            int b = int.Parse(s[1]);
            adj[a, b] = 1;
            adj[b, a] = 1;
        }


        bool[] visited = new bool[vertex + 1];
        int count = 0;
        for (int i = 1; i <= vertex; i++)
        {
            if (visited[i]) continue;
            count++;
            Queue<int> q = new();
            q.Enqueue(i);
            visited[i] = true;
            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                for (int j = 1; j <= vertex; j++)
                {
                    if (adj[cur, j] == 1 && !visited[j])
                    {
                        q.Enqueue(j);
                        visited[j] = true;
                    }
                }
            }
        }

        sw.WriteLine(count);

        sw.Flush();
    }
}

//인접행렬로 구현.