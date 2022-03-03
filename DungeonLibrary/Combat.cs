using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //this is just a warehouse for methods related to combat
        //we will have 2 methods, one that attacks, and another 
        //that strings two attacks (one from attack and one from defender)
        //together.
        public static void DoAttack(Character attacker, Character defender)
        {

            //to figure our attack I'm first going to create a random number
            //as our "dice roll"
            Random randy = new Random();
            int diceRoll = randy.Next(1, 101); // 1-100
            //sometimes in computing, we don't give a class enough time
            //to generate a unique 'seed' in the list of Random
            //for this reason I'm going to add a Sleep();
            System.Threading.Thread.Sleep(30);
            //let's check if the attack works
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                // random# <= (player.HitChance(25) - monster.Block(10))
                //this is if they hit
                //get the damage dealt by the attacker
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //write a result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!!!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }//if attack works
            else
            {
                //if the attack missed
                Console.WriteLine($"{attacker.Name} missed...");
            }//end else

        }//end DoAttack

        public static void DoBattle(Player player, Monster monster)
        {

            //assume that the player attacks first
            DoAttack(player, monster);

            //monster will attack again if they are alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
            //else
            //{
                //the monster died, but we can't get a new room from the combat
                //class here.
            //}

        }//end DoBattle
    }
}
