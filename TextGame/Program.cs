﻿using System;

namespace TextGame // Note: actual namespace depends on the project name.
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        struct Player
        {
            public int hp;
            public int attack;
        }
        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1" :
                    choice = ClassType.Knight;
                    break;
                case "2" :
                    choice = ClassType.Archer;
                    break;
                case "3" :
                    choice = ClassType.Mage;
                    break;
                    
            }
            return choice;
        }
        static void CreatePlayer(ClassType choice,out Player player)
        {
            // 기사 (100, 10) 궁수 (75, 12) 법사 (50, 15)
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }
        static void CreateRandomMonster(out Monster monster)
        {
            // 랜덤으로 몬스터 중 하나를 리스폰
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 스폰되었습니다.");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 스폰되었습니다.");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 스폰되었습니다.");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }
        static void EnterGame()
        {
            while (true)
            {
                Console.WriteLine("게임에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다.");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        EnterField();
                        break;
                    case "2":
                        return;
                }
            }
        }
        static void EnterField()
        {
            Console.WriteLine("필드에 접속했습니다!");
            // 몬스터 생성
            Monster monster;
            // 랜덤으로 1-3 몬스터 중 하나를 리스폰
            CreateRandomMonster(out monster);

            Console.WriteLine("[1] 전투 모드로 돌입");
            Console.WriteLine("[2] 일정 확률로 마을로 도망");
            
            
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice != ClassType.None)
                {
                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);

                    EnterGame();
                }
            }
        }
    }
}