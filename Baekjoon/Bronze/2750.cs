class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장 빠른 속도.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(sr.ReadLine());
        }

        Array.Sort(arr);
        
        for (int i = 0; i < n; i++)
        {
            sw.WriteLine(arr[i]);
        }

        sw.Flush();
    }
}