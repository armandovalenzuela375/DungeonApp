using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Beholder : Monster
    {
        //fields

        //props
        public bool IsHolding { get; set; }

        public Beholder(string name, int life, byte maxLife, byte hitChance, 
            byte block, byte minDamage, byte maxDamage, string description,
            bool isHolding) 
            : base(name, life, maxLife, hitChance, block, minDamage, 
                  maxDamage, description)
        {
            //need to make the assignment for IsHolding
            IsHolding = isHolding;
        }//end fqctor

        public override string ToString()
        {
            return string.Format("\n*******BEHOLDER*******\n" +
                "{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\t\tDescription:\n{6}\n{7}",
                Name, Life, MaxLife, MinDamage, MaxDamage,
                Block, Description,
                (IsHolding ? "is also holding something suspicious" : ""));
        }//ToString()

        public override int CalcDamage()
        {
            return (IsHolding ? base.CalcDamage() * 2 : base.CalcDamage());
            //if they are "holding" then base * 2 if not then just the base
        }

        //add block by 50%
        public override int CalcBlock()
        {
            int calcBlock = Block;
            return calcBlock += base.CalcBlock() / 2;
        }
    }
}
