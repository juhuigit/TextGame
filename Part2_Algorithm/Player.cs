namespace Part2_Algorithm;

public class Player
{
    public int PosY { get; private set; }
    public int PosX { get; private set; }
    private Board _board;
    private Random _random = new Random();
    public void Initialize(int posY, int posX, int destY, int dextX, Board board)
    {
        PosX = posX;
        PosY = posY;

        _board = board;
    }

    const int MOVE_TICK = 100;
    int _sumTick = 0;
    public void Update(int deltaTick)
    {
        _sumTick += deltaTick;
        if (_sumTick >= MOVE_TICK)
        {
            _sumTick = 0;
            
            // 0.1초마다 실행될 로직
            int randValue = _random.Next(0, 5);
            switch (randValue)
            {
                case 0: // 상
                    if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                        PosY = PosY - 1;
                    break;
                case 1: // 하
                    if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                        PosY = PosY + 1;
                    break;
                case 2: // 좌
                    if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                        PosY = PosX - 1;
                    break;
                case 3: // 우
                    if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                        PosY = PosX + 1;
                    break;
            }
        }
    }
}