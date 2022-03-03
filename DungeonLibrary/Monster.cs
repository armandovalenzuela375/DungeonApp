using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
        //public Monster that is a child of Character
    {
        //fields
        private byte _minDamage; //we will have a biz rule for this

        //properties
        public string Description { get; set; }
        public byte MaxDamage { get; set; }
        public byte MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be greater than MaxDamage or less than 1
                if (value <= MaxDamage && value > 0)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    //this is if the value was greater than max and less than 1
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //ctors
        //only going to have a fully qualified ctor
        public Monster(string name, int life, byte maxLife, byte hitChance,
            byte block, byte minDamage, byte maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage; //doing these first due to biz rules
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
            //8 total
        }//end fqctor

        //methods
        public override string ToString()
        {
            return string.Format("\n*******MONSTER*******\n" +
                "{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" + 
                "Block: {5}\t\tDescription:\n{6}\n", 
                Name, Life, MaxLife, MinDamage, MaxDamage, 
                Block, Description);
        }//end ToString()

        //don't need to override calcBlock, because we don't have armor, or a shield
        //or agility.

        //WE HAVE TO override calcDamage, it is ZERO
        public override int CalcDamage()
        {
            //Create a Random number variable
            Random randy = new Random();
            return randy.Next(MinDamage, ++MaxDamage);
            //remember the MaxValue in the .Next() is an exclusive
            //upper bound. So if the damage was 2-8, if we put that in 
            //the next method we would get 2-7...
        }



    }
}
