namespace OOP;

public enum MonsterType
{
    None = 0,
    Slime = 1,
    Orc = 2,
    Skelton = 3
}

public class Monster : Creature
{
    protected MonsterType type;
    protected Monster(MonsterType type) : base(CreatureType.Monster)
    {
        this.type = type;
    }

    public MonsterType getMonsterType() { return type; }
}

class Slime : Monster
{
    public Slime() : base(MonsterType.Slime)
    {
        SetInfo(10, 10);
    }
}
class Orc : Monster
{
    public Orc() : base(MonsterType.Orc)
    {
        SetInfo(20, 15);
    }
}
class Skelton : Monster
{
    public Skelton() : base(MonsterType.Skelton)
    {
        SetInfo(30, 20);
    }
}