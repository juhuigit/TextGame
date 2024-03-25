namespace Part2_Algorithm;

public class MyList<T>
{
    // 동적 배열
    private const int DEFAULT_SIZE = 1;
    private T[] _data = new T[DEFAULT_SIZE];
    
    public int Count = 0; // 실제로 사용중인 데이터 개수
    public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수

    public void Add(T item)
    {
        // 1. 공간이 남아있는지 확인
        if (Count >= Capacity)
        {
            // 공간을 늘려서 확보
            T[] newArray = new T[Count * 2];
            for (int i = 0; i < Count; i++)
                newArray[i] = _data[i];
            _data = newArray; // 값 최종적으로 대치
        }
        
        // 2. 공간에 데이터 삽입
        _data[Count] = item;
        Count++;
    }

    public T this[int index]
    {
        get { return _data[index]; }
        set { _data[index] = value; }
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < Count - 1; i++)
            _data[i] = _data[i + 1];
        _data[Count - 1] = default(T);
        Count--;
    }
}

public class Board
{
    // 데이터를 셋 중에 뭐로 이용하는게 좋을까 ?
    public TileType[,] Tile { get; private set; } // 배열
    // public MyList<int> _data2 = new MyList<int>(); // 동적 배열
    // public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스트
    public int Size { get; private set; }
    const char SQUARE = '\u25a0';

    private Player _player;


    public enum TileType
    {
        Empty,
        Wall,
    }
    public void Initialize(int size, Player player)
    {
        _player = player;
        
        if (size % 2 == 0)
            return;
        
        Tile = new TileType[size, size];
        Size = size;

        GenerateByBinaryTree();
        GenerateBySideWinder();
    }
    void GenerateByBinaryTree()
    {
        // 길을 막아버리는 작업
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    Tile[y, x] = TileType.Wall;
                else
                    Tile[y, x] = TileType.Empty;
            }
        }
        
        // 랜덤으로 우측 또는 아래로 길을 뚫는 작업
        // Binary Tree Algorithm
        Random rand = new Random();
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    continue;

                if (y == Size - 2 && x == Size - 2)
                {
                    continue;
                }
                
                if (y == Size - 2)
                {
                    Tile[y, x + 1] = TileType.Empty;
                    continue;
                }
                
                if (x == Size - 2)
                {
                    Tile[y + 1, x] = TileType.Empty;
                    continue;
                }

                if (rand.Next(0, 2) == 0) // 0 ~ 1의 값 
                {
                    Tile[y, x + 1] = TileType.Empty;
                }
                else
                {
                    Tile[y + 1, x] = TileType.Wall;
                }
                    
            }
        }
    }
    void GenerateBySideWinder()
    {
        // 길을 막아버리는 작업
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    Tile[y, x] = TileType.Wall;
                else
                    Tile[y, x] = TileType.Empty;
            }
        }
        
        // 랜덤으로 우측 또는 아래로 길을 뚫는 작업
        Random rand = new Random();
        for (int y = 0; y < Size; y++)
        {
            int count = 1;
            for (int x = 0; x < Size; x++)
            {
                if (x % 2 == 0 || y % 2 == 0)
                    continue;
                
                if (y == Size - 2 && x == Size - 2)
                {
                    continue;
                }
                
                if (y == Size - 2)
                {
                    Tile[y, x + 1] = TileType.Empty;
                    continue;
                }
                
                if (x == Size - 2)
                {
                    Tile[y + 1, x] = TileType.Empty;
                    continue;
                }
                if (rand.Next(0, 2) == 0) // 0 ~ 1의 값 
                {
                    Tile[y, x + 1] = TileType.Empty;
                    count++;
                }
                else
                {
                    int randomIndex = rand.Next(0, count);
                    Tile[y + 1, x - randomIndex * 2] = TileType.Wall;
                    count = 1;
                }
                    
            }
        }
    }
    public void Render()
    {
        ConsoleColor prevColor = Console.ForegroundColor;
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                // 플레이어 좌표를 갖고 와서, 그 좌표와 현재 y, x 가 일치하면 플레이어 전용 색상으로 표시.
                if (y == _player.PosY && x == _player.PosX)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = GetTileColor(Tile[y, x]);
                
                Console.Write(SQUARE);
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = prevColor;
    }
    ConsoleColor GetTileColor(TileType type)
    {
        switch (type)
        {
            case TileType.Empty:
                return ConsoleColor.Yellow;
            case TileType.Wall:
                return ConsoleColor.DarkBlue;
            default:
                return ConsoleColor.Green;
        }
    }
}