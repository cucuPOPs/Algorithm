using System.Text;
class Program
{
    private const int bufferSize = 131072;//131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));
    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        int title = 666;
        while (n > 0)
        {
            if (title.ToString().Contains("666")) n--;
            title++;
        }
        sw.WriteLine(title - 1);
        sw.Flush();
    }
}