class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] s = sr.ReadLine().Split();
        int n = int.Parse(s[0]);
        int m = int.Parse(s[1]);
        Dictionary<string, int> dic_stoi = new Dictionary<string, int>();
        string[] itos = new string[n + 1];

        for (int i = 1; i <= n; i++)
        {
            string name = sr.ReadLine();
            dic_stoi.Add(name, i);
            itos[i] = name;
        }

        for (int i = 0; i < m; i++)
        {
            string s1 = sr.ReadLine();
            if (int.TryParse(s1, out int num))
            {
                sw.WriteLine(itos[num]);
            }
            else
            {
                sw.WriteLine(dic_stoi[s1]);
            }
        }

        sw.Flush();
    }
}