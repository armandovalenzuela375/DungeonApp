using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //we are making this class public, so that it can be used OUTSIDE of the project
    //it is INTERNAL by default

    //the abstract modifier indicates that where we use the abstract modifier
    //has an INCOMPLETE implemenation.  we can use the abstract modifier with
    //classes, methods, or properties.
    //in this case we are going to use the ABSTRACT modifier to indicate that 
    //we are NOT going to be able to create objects of this type
    //we are simply using this class as a base/parent class.
    public abstract class Character
    {
        //fields
        private int _life; //brought in from player

        //properties
        public string Name { get; set; } //brought in from player
        public byte HitChance { get; set; }
        public byte Block { get; set; }
        public byte MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                //MINI LAB 
                //create a biz rule, where life cannot be GREATER than maxLife
                //otherwise just assign life the value of MaxLife
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife; //make life equal to MaxLife
                }
            }
        }//end Life

        //ctors
        //since this class is a parent class AND abstract (will never create)
        //we do not need a ctor.  because it won't be created
        //however, this means that all the assignments will HAVE TO take 
        //place in the CHILD classes.

        //methods
        //no need to override the ToString() here, I'm never going to print 
        //a character object to the screen and player already has one.
        //we will need to create a ToString() for Monster.

        //these will be methods inherited by both player and monster
        //these will help us create/use our combat class that we will create
        //later.
        public virtual int CalcBlock()
        {
            //to make it so we can override in a child class we made this VIRTUAL
            //this will just be a basic version, we intend to override in a child
            //class so we will just return a value.
            return Block;
        }//end CalcBlock()

        //MINI LAB
        //create CalcHitChance() and make it overrideable
        //then create CalcDamage() also making it overrideable
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcDamage()
        {
            return 0; //we need to remember to make sure to override this
        }




    }
}
