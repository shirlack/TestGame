using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestGame {
    class Program
{
    static void Main(string[] args)
    {
        static void StartGame() //Вся программа работает в функции StartGame,в будущем это позволило бы создать меню игры , производить какие то надстройки перед запуском
        {   
            Tank Player = new Tank(200, 35, 50, "Игрок");   //Конструктор класса имеет три входных параметра при создании Здоровье,Броню,Урон и Имя объекта
            Tank Computer = new Tank(300, 15, 60, "Компьютер");

            int Action;     //Создаются дополнительные переменные что бы обрабатывать действия Игрока и Случайные действия Компьютера
            int ComputerAction;
            Random rng = new Random(); 
                while (Player.Healts > 0 && Computer.Healts > 0)
                {

                    Console.WriteLine("Характеристики Игрока. Здоровье: " + Player.Healts + " Броня:" + Player.Armor + " Боекомплект: " + Player.BulletCount);
                    Console.WriteLine("Характеристики Компьютера. Здоровье: " + Computer.Healts + " Броня:" + Computer.Armor + " Боекомплект: " + Computer.BulletCount);
                    Console.WriteLine("Выберете действие:" + "\n" + "1.Выстрел " + "\n" + "2.Поднять Броню" + "\n" + "3.Купить Боекомплект");
                    //Простой интерфейс с выводом текущих характерист объекта + возможные действия пользователя


                    Action = Convert.ToInt32(Console.ReadLine());
                    ComputerAction = rng.Next(1, 3);

                    switch (Action)     //В данном свиче обрабатываются входные параметры и происходит действие согласно выбору пользователя
                    {
                        case 1:
                            if (Player.BulletCount >= 1) //При выборе Выстрела происходит проврка на наличие потронов
                            {                            //Если потронов нет, Игрока уведомляют о необходимости их купить и он пропускает свой ход
                                Player.Shot(Computer);  //если Введено значение которого нет в списке , то предлагается выбрать заново
                                ComputerMotion();
                            }
                            else
                            {
                                Console.WriteLine("Купите Боекомплект что бы стрелять");
                                ComputerMotion();
                            }
                            break;

                        case 2:
                            Player.getArmor();
                            ComputerMotion();
                            break;

                        case 3:
                            Player.Reloud();
                            ComputerMotion();
                            break;

                        default:
                            Console.WriteLine("Введенно не верное значение");

                            break;
                    }
                    void ComputerMotion()               //Функция обработки дейсвий компьютера
                    {if (Computer.Healts == Computer.Max_Healts && Computer.BulletCount >= 1)//Проверка на максимально колличиство здоровья
                        {                                                                   //что бы компьтер не пытался лечится с полным здоровьем 
                            Computer.Shot(Player);                                          //Если здоровья не хватает происходит случайно действие 
                        }
                        else
                        {
                            switch (ComputerAction)
                              {   
                                case 1:
                                 if (Computer.BulletCount >= 1)
                                 {
                                  Computer.Shot(Player);                        
                                 }
                                 else
                                 {Computer.Reloud();Console.WriteLine("Компьютер Перезарядился"); }
                                  break;
                                 case 2:                            
                                   Computer.getArmor();                    
                                   break;                
                              }
                        }
                                   
                    };
               
                    //Вывод статистики после действия, так же показывается промахнулся ли Игрок или компьютер или был нанесен критический урон
                    Console.WriteLine("Характеристики Игрока. Здоровье: " + Player.Healts + " Броня:" + Player.Armor + " Боекомплект: " + Player.BulletCount);
                    Console.WriteLine("Характеристики Компьютера. Здоровье: " + Computer.Healts + " Броня:" + Computer.Armor + " Боекомплект: " + Computer.BulletCount);
                    Console.WriteLine("Нажмите Enter что бы продолжить");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (Computer.Healts <= 0) { Console.WriteLine("Ура, Вы победили"); } else { Console.WriteLine("Вы проиграли"); }//Событие при выходе из цикла в случае окончания здоровья
                Console.ReadLine();
        }
        StartGame();

    }
} 
}

 














