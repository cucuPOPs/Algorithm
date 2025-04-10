class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] nm = sr.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        int[] p = new int[n + 1];
        Array.Fill(p, -1);

        for (int i = 0; i < m; i++)
        {
            string[] s = sr.ReadLine().Split();
            int cmd = int.Parse(s[0]);
            int a = int.Parse(s[1]);
            int b = int.Parse(s[2]);
            if (cmd == 0)
            {
                Union(a, b);
            }
            else
            {
                if (Find(a) == Find(b))
                    sw.Write("YES\n");
                else
                {
                    sw.Write("NO\n");
                }
            }
        }
        sw.Flush();

        int Find(int x)
        {
            if (p[x] < 0) return x;//루트노드이면, 본인.
            return p[x] = Find(p[x]);//부모노드가 루트노드가 아닐때, 부모노드를 루트노드로 바꿔주고, 루트노드를 리턴.
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

        //랭크기반 병합.
        void Union2(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return;

            int rankA = -p[rootA];
            int rankB = -p[rootB];

            if (rankA > rankB)
            {
                p[rootB] = rootA; // rootB를 rootA 아래에 붙임
            }
            else if (rankA < rankB)
            {
                p[rootA] = rootB; // rootA를 rootB 아래에 붙임
            }
            else
            {
                // 같은 랭크면 아무 쪽이나 붙이고 랭크 증가
                p[rootB] = rootA;
                p[rootA]--;
            }
        }
    }
}