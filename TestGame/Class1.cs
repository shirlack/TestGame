using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Tank      //В отдельном файле создан класс и все его методы
    {
        public Tank(int H, int A, int D, string name) { Healts = H; Max_Healts = H; Armor = A; Damage = D; TankName = name; }
                        //конструктор который принимает все данные для создания объекта
        private string TankName;
        public int Max_Healts;
        public int Healts;
        public int Armor;
        public int Damage;
        public int BulletCount = 6;
        Random rng = new Random();  

        public void Shot(Tank Target)       //Метод выстрела
        {
            int RandomChance = rng.Next(1, 11);//переменная для обработки событий Промаха и критического шанса
            if (RandomChance == 10)
            {
                Target.Healts -= Convert.ToInt32(Damage * 1.2) - Target.Armor;
                BulletCount--;
                Console.WriteLine(TankName + " Нанес Критический урон");
            }
            else if (RandomChance == 1 || RandomChance == 2) { Console.WriteLine(TankName + " Промахнулся"); BulletCount--; }
            else
            {
                Target.Healts -= Damage - Target.Armor;
                Console.WriteLine(TankName + " Выстрелил");
                BulletCount--;
            }

        }

        public void getArmor() //Метод для поднятия брони .
        {
            if (Healts == Max_Healts) //не дает поднять здоровье выше максимального значения .уведомляя пользователя об этом
            { Console.WriteLine(TankName + " Броня не нуждается в ремонте"); }
            else
            {
                Healts += Armor;
                Console.WriteLine(TankName + " Поднял Броню");
                if (Healts > Max_Healts) { Healts = Max_Healts; }
            }

        }

        public void Reloud()//Метод перезарядки ,идет обновление переменной к изначальному значению 
        {
            this.BulletCount = 6;   
        }


    }

}
