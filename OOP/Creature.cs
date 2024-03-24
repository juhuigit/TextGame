namespace OOP;

public enum CreatureType
{
    None = 0,
    Player = 1,
    Monster = 2
}
public class Creature
{ 
    // 필드
    CreatureType type;
    protected int hp;
    protected int attack;
    
    // 생성자
    protected Creature(CreatureType type)
    {
        this.type = type;
    }
    
    // Setter
    public void SetInfo(int hp, int attack) { this.hp = hp; this.attack = attack; }
    
    // Getter
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