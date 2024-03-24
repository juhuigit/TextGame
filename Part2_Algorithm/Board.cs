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
    public int[] _data = new int[25]; // 배열
    public MyList<int> _data2 = new MyList<int>(); // 동적 배열
    public LinkedList<int> _data3 = new LinkedList<int>(); // 연결 리스트

    public void Initialize()
    {
        _data2.Add(101);
        _data2.Add(102);
        _data2.Add(103);
        _data2.Add(104);
        _data2.Add(105);
        
        int temp = _data2[2];
        
        _data2.RemoveAt(2); // 해당 index 삭제
    }
}