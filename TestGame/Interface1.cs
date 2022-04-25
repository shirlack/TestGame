using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
     interface IPlayer
    {
         string TankName { get => TankName; set => TankName= value; }
         int Max_Healts { get => Max_Healts; set => Max_Healts = value; }
         int Healts { get => Healts; set => Healts = value; }
         int Armor { get => Armor; set => Armor = value; }
         int Damage { get => Damage; set => Damage = value; }
         int BulletCount { get => BulletCount; set => BulletCount = value; }

        void Shot(IComputer target);
        void GetArmor();
        void Reloud();


    }

     interface IComputer 
    {
        string TankName { get => TankName; set => TankName = value; }
        int Max_Healts { get => Max_Healts; set => Max_Healts = value; }
        int Healts { get => Healts; set => Healts = value; }
        int Armor { get => Armor; set => Armor = value; }
        int Damage { get => Damage; set => Damage = value; }
        int BulletCount { get => BulletCount; set => BulletCount = value; }

        void Shot(IPlayer target);
        void GetArmor();
        void Reloud();


    }




}
