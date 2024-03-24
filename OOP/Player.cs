namespace OOP;

public enum PlayerType
{
    None = 0,
    Knight = 1,
    Archer = 2,
    Mage = 3
}
class Player : Creature
{
    // 필드
    protected PlayerType type = PlayerType.None;
    protected int hp;
    protected int attack;
    
    // 생성자
    protected Player(PlayerType type) : base(CreatureType.Player)
    { this.type = type; }
    
    // Setter
    public void SetInfo(int hp, int attack) { this.hp = hp; this.attack = attack; }
    // Getter
    public PlayerType GetPlayerType() { return type;}
    public int GetHp() { return hp; }
    public int GetAttack() { return attack; }
    
    // 동작 함수
    public bool IsDead() { return hp <= 0; }
    public void OnDamaged(int damage)
    {
        hp -= damage;
        if (hp < 0)
            hp = 0;
    }
}

class Knight : Player
{
    public Knight(): base(PlayerType.Knight)
    {
        SetInfo(100, 10);
    }
}
class Archer : Player
{
    public Archer() : base(PlayerType.Archer)
    {
        SetInfo(75, 12);
    }
}

class Mage : Player
{
    public Mage(): base(PlayerType.Mage)
    {
        SetInfo(50,15);
    }
}