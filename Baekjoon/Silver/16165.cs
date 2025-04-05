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

        Dictionary<string, string> memerGroup = new();
        Dictionary<string, List<string>> groupMember = new();

        for (int i = 0; i < n; i++)
        {
            string group = sr.ReadLine();
            int count = int.Parse(sr.ReadLine());

            groupMember[group] = new List<string>();

            for (int j = 0; j < count; j++)
            {
                string member = sr.ReadLine();
                groupMember[group].Add(member);
                memerGroup[member] = group;
            }
        }

        for (int i = 0; i < m; i++)
        {
            string quest = sr.ReadLine();
            int type = int.Parse(sr.ReadLine());

            if (type == 0)
            {
                foreach (string name in groupMember[quest].OrderBy(x => x))
                {
                    sw.WriteLine(name);
                }
            }
            else
            {
                sw.WriteLine(memerGroup[quest]);
            }
        }

        sw.Flush();
    }
}