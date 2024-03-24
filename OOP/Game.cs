using System.Diagnostics;
using System.Threading.Channels;

namespace OOP;

public enum GameMode
{
    None,
    Lobby,
    Town,
    Field
}

public class Game
{
    private GameMode mode = GameMode.Lobby;
    private Player player = null;
    private Monster monster = null;
    private Random rand = new Random();
    
    public void Process()
    {
        switch (mode)
        {
            case GameMode.Lobby :
                ProcessLobby();
                break;
            case GameMode.Town:
                ProcessTown();
                break;
            case GameMode.Field:
                ProcessField();
                break;
        }
    }

    public void ProcessLobby()
    {
        Console.WriteLine("직업을 선택하세요.");
        Console.WriteLine("[1] 기사");
        Console.WriteLine("[2] 궁수");
        Console.WriteLine("[3] 법사");

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                player = new Knight();
                mode = GameMode.Town;
                break;
            case "2":
                player = new Archer();
                mode = GameMode.Town;
                break;
            case "3":
                player = new Mage();
                mode = GameMode.Town;
                break;
        }
    }

    public void ProcessTown()
    {
        Console.WriteLine("마을에 입장했습니다.");
        Console.WriteLine("[1] 필드로 가기");
        Console.WriteLine("[2] 로비로 돌아가기");
        
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                mode = GameMode.Field;
                break;
            case "2":
                mode = GameMode.Lobby;
                break;
        }
    }
    
    public void ProcessField()
    {
        Console.WriteLine("필드에 입장했습니다.");
        Console.WriteLine("[1] 싸우기");
        Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

        CreateRandomMonster();

        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                ProcessFight();
                break;
            case "2":
                // 일정확률로 도망치고, 도망못치면 싸움.
                TryEscape();
                break;
        }
    }

    private void TryEscape()
    {
        int randVaule = rand.Next(0, 101);
        if (randVaule < 33)
        {
            mode = GameMode.Town;
        }
        else
        {
            ProcessFight();
        }
    }
    private void ProcessFight()
    {
        while (true)
        {
            int damage = player.GetAttack();
            monster.OnDamaged(damage);
            if (monster.IsDead())
            {
                Console.WriteLine("승리했습니다.");
                Console.WriteLine($"남은체력: {player.GetHp()}");
                break;
            }

            damage = monster.GetAttack();
            player.OnDamaged(damage);
            if (player.IsDead())
            {
                Console.WriteLine("패배했습니다.");
                Console.WriteLine($"남은체력: {monster.GetHp()}");
                break;
            }
        }
    }
    private void CreateRandomMonster()
    {
        int randValue = rand.Next(0, 3);
        switch (randValue)
        {
            case 0:
                monster = new Slime();
                Console.WriteLine("슬라임이 생성되었습니다.");
                break;
            case 1:
                monster = new Orc();
                Console.WriteLine("오크가 생성되었습니다.");
                break;
            case 2:
                monster = new Skelton();
                Console.WriteLine("스켈레톤이 생성되었습니다.");
                break;
        }
    }
}