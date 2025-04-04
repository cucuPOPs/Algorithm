class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        //int c = int.Parse(inputs[1]);

        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Dictionary<int, (int cnt, int idx)> dic = new Dictionary<int, (int, int)>();

        for (int i = 0; i < n; i++)
        {
            int num = arr[i];
            if (dic.ContainsKey(num))
                dic[num] = (dic[num].cnt + 1, dic[num].idx);
            else
                dic[num] = (1, i);
        }

        (int num, int cnt, int idx)[] arr2 = dic.Select(x => (x.Key, x.Value.cnt, x.Value.idx)).ToArray();

        Array.Sort(arr2, (a, b) =>
        {
            if (a.cnt != b.cnt)
                return b.cnt.CompareTo(a.cnt);
            else
                return a.idx.CompareTo(b.idx);
        });

        foreach (var item in arr2)
        {
            for (int i = 0; i < item.cnt; i++)
            {
                sw.Write(item.num + " ");
            }
        }

        sw.Flush();
    }
}