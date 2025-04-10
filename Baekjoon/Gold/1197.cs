class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int v = int.Parse(s[0]);
        int e = int.Parse(s[1]);
        int[] p = new int[v + 1];
        Array.Fill(p, -1);
        List<(int, int, int)> edge = new List<(int, int, int)>();
        for (int i = 0; i < e; i++)
        {
            string[] s1 = sr.ReadLine().Split();
            int a = int.Parse(s1[0]);
            int b = int.Parse(s1[1]);
            int cost = int.Parse(s1[2]);
            edge.Add((cost, a, b));
        }

        edge.Sort();//비용순으로 정렬.

        int totalCost = 0;
        foreach ((int cost, int a, int b) in edge)
        {
            if (Find(a) != Find(b))
            {
                Union(a, b);
                totalCost += cost;
            }
        }

        sw.WriteLine(totalCost);

        sw.Flush();

        int Find(int x)
        {
            if (p[x] < 0) return x; //루트노드이면, 본인.
            return p[x] = Find(p[x]); //부모노드가 루트노드가 아닐때, 부모노드를 루트노드로 바꿔주고, 루트노드를 리턴.
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            //루트가 다르면, 합치기.
            if (rootA != rootB)
            {
                p[rootB] = rootA;
            }
        }
    }
}