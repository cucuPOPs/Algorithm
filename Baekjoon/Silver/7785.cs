class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        HashSet<string> set = new HashSet<string>();
        for (int i = 0; i < n; i++)
        {
            string[] s = sr.ReadLine().Split();

            if (set.Contains(s[0])) set.Remove(s[0]);
            else set.Add(s[0]);
        }

        string[] arr = set.ToArray();
        Array.Sort(arr);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            sw.WriteLine(arr[i]);
        }

        sw.Flush();
    }
}