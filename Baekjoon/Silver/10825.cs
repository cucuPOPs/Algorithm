class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());

        (int kor, int eng, int math, string name)[] arr = new (int, int, int, string)[n];
        for (int i = 0; i < n; i++)
        {
            string[] s = sr.ReadLine().Split();
            arr[i].name = s[0];
            arr[i].kor = int.Parse(s[1]);
            arr[i].eng = int.Parse(s[2]);
            arr[i].math = int.Parse(s[3]);
        }

        Array.Sort(arr, (a, b) =>
        {
            if (a.kor != b.kor) return b.kor.CompareTo(a.kor);
            if (a.eng != b.eng) return a.eng.CompareTo(b.eng);
            if (a.math != b.math) return b.math.CompareTo(a.math);
            return a.name.CompareTo(b.name);
        });

        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(arr[i].name);
        }

        sw.Flush();
    }
}