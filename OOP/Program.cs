using System;
namespace OOP;

class Program
{
    static void Main(string[] args)
    {
        Player knight = new Knight();
        Monster orc = new Orc();

        int damage = knight.GetAttack();
        orc.OnDamaged(damage);
    }
}




