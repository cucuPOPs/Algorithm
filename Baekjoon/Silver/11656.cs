class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string s = sr.ReadLine();
        string[] arr = new string[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            arr[i] = s.Substring(i, s.Length - i);
        }

        Array.Sort(arr);
        
        for (int i = 0; i < arr.Length; i++)
        {
            sw.WriteLine(arr[i]);
        }

        sw.Flush();
    }
}