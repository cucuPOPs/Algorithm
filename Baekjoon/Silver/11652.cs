class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        int n = int.Parse(sr.ReadLine());
        Dictionary<long, int> dic = new Dictionary<long, int>();

        // 카드 개수 카운트
        for (int i = 0; i < n; i++)
        {
            long card = long.Parse(sr.ReadLine());
            if (dic.ContainsKey(card))
                dic[card]++;
            else
                dic[card] = 1;
        }

        // 최빈값 찾기
        long mostFrequentCard = 0;
        int maxCount = 0;

        foreach (var pair in dic)
        {
            long card = pair.Key;
            int count = pair.Value;

            // 1. 더 많이 나온 카드로 갱신
            // 2. 개수가 같다면 작은 값 선택
            if (count > maxCount || (count == maxCount && card < mostFrequentCard))
            {
                mostFrequentCard = card;
                maxCount = count;
            }
        }

        sw.WriteLine(mostFrequentCard);

        sw.Flush();
    }
}