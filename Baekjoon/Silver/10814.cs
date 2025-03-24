class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        List<string>[] member = new List<string>[201];
        while (n-- > 0)
        {
            string[] s = sr.ReadLine().Split();
            int age = int.Parse(s[0]);
            string name = s[1];

            if (member[age] == null)
                member[age] = new List<string>();

            member[age].Add(name);
        }


        for (int i = 0; i < member.Length; i++)
        {
            if (member[i] == null) continue;

            foreach (string name in member[i])
            {
                sw.WriteLine($"{i} {name}");
            }
        }
        sw.Flush();
    }
}