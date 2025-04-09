using System.Text;

partial class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    public static readonly StringBuilder sb = new StringBuilder();
    static void Main()
    {
        string[] ss = sr.ReadLine().Split();
        int vertex = int.Parse(ss[0]);
        int edge = int.Parse(ss[1]);
        int start = int.Parse(ss[2]);

        List<int>[] adj = new List<int>[vertex + 1];
        for (int i = 0; i <= vertex; i++)
        {
            adj[i] = new List<int>();
        }
        
        
        for (int i = 0; i < edge; i++)
        {
            ss = sr.ReadLine().Split();
            int a = int.Parse(ss[0]);
            int b = int.Parse(ss[1]);

            adj[a].Add(b);
            adj[b].Add(a);
        }
        
        
        //작은번호를 먼저방문.
        for (int i = 1; i <= vertex; i++)
            adj[i].Sort();
        
        

        //DFS
        bool[] visited = new bool[vertex + 1];
        Stack<int> s = new Stack<int>();
        s.Push(start);

        while (s.Count > 0)
        {
            int cur = s.Pop();

            if (visited[cur]) continue;
            visited[cur] = true;
            sb.Append(cur).Append(" ");

            for (int i = adj[cur].Count - 1; i >= 0; i--)
            {
                int next = adj[cur][i];
                if (visited[next]) continue;
                s.Push(next);
            }
        }

        sb.Append("\n");

        //BFS
        Queue<int> q = new Queue<int>();
        Array.Fill(visited, false);
        q.Enqueue(start);
        visited[start] = true;
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            sb.Append(cur).Append(" ");

            foreach(int next in adj[cur])
            {
                if (visited[next]) continue;
                q.Enqueue(next);
                visited[next] = true;
            }
        }


        sw.Write(sb);
        sw.Flush();
    }
}