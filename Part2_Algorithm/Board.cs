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
    public TileType[,] _tile; // 배열
    // public MyList<int> _data2 = new MyList<int>(); // 동적 배열
    // public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스트
    public int _size;
    const char CIRCLE = '\u25cf';


    public enum TileType
    {
        Empty,
        Wall,
    }
    public void Initialize(int size)
    {
        _tile = new TileType[size, size];
        _size = size;

        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                    _tile[y, x] = TileType.Wall;
                else
                    _tile[y, x] = TileType.Empty;
            }
        }
    }

    public void Render()
    {
        ConsoleColor prevColor = Console.ForegroundColor;
        for (int y = 0; y < _size; y++)
        {
            for (int x = 0; x < _size; x++)
            {
                Console.ForegroundColor = GetTileColor(_tile[y, x]);
                Console.Write(CIRCLE);
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
                return ConsoleColor.Gray;
            case TileType.Wall:
                return ConsoleColor.DarkCyan;
            default:
                return ConsoleColor.Green;
        }
    }
}