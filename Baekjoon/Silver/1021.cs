class Program
{
    private const int bufferSize = 131072; //131072=128KB. 경험적 가장빠른속도. 기본=4096=4KB.
    public static readonly StreamReader sr = new(new BufferedStream(Console.OpenStandardInput(), bufferSize));
    public static readonly StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput(), bufferSize));

    static void Main()
    {
        string[] inputs = sr.ReadLine().Split();
        int N = int.Parse(inputs[0]); // 큐의 크기
        //int M = int.Parse(inputs[1]); // 뽑아야 하는 수의 개수

        int[] targets = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); // 뽑아야 하는 숫자 리스트
        LinkedList<int> deque = new LinkedList<int>(); // 큐를 덱(Deque)으로 구현
        int count = 0; // 이동 횟수

        // 1부터 N까지 큐에 넣음
        for (int i = 1; i <= N; i++)
        {
            deque.AddLast(i);
        }

        foreach (int target in targets)
        {
            int index = 0;
            LinkedListNode<int> node = deque.First;

            // 찾고자 하는 숫자의 현재 위치(index) 찾기
            while (node.Value != target)
            {
                node = node.Next;
                index++;
            }

            int leftMoves = index;                   // 왼쪽으로 회전하는 횟수
            int rightMoves = deque.Count - index;    // 오른쪽으로 회전하는 횟수

            // 최소 이동 횟수 선택
            if (leftMoves <= rightMoves)
            {
                // 왼쪽으로 회전
                for (int i = 0; i < leftMoves; i++)
                {
                    deque.AddLast(deque.First.Value);
                    deque.RemoveFirst();
                    count++;
                }
            }
            else
            {
                // 오른쪽으로 회전
                for (int i = 0; i < rightMoves; i++)
                {
                    deque.AddFirst(deque.Last.Value);
                    deque.RemoveLast();
                    count++;
                }
            }

            // 숫자 제거
            deque.RemoveFirst();
        }

        sw.WriteLine(count);
        sw.Flush();
    }
}