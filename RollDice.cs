using System;
using System.Collections.Generic;

namespace DiceRoller
{
    class RollDice
    {
        public RollDice() { _RequestDiceInformation(); }

        private void _RequestDiceInformation()
        {
            bool ready = false;
            while (!ready)
            {
                Console.Clear();
                Console.WriteLine("Please choose number of sides on the die: ");
                Int32.TryParse(Console.ReadLine(), out int numDieSides);
                Console.WriteLine("Please choose number of rolls to make: ");
                Int32.TryParse(Console.ReadLine(), out int numRolls);
                if(numRolls > 0 && numDieSides > 0)
                {
                    ready = true;
                    _RollDice(numRolls, numDieSides);
                }
            }
        }

        private void _RollDice(int numRolls, int numDieSides)
        {
            Random random = new Random();
            List<int> results = new List<int>();
            
            for(int count = 0; count < numRolls; count++)
            {
                results.Add(random.Next(1, numDieSides + 1));
            }

            string rollText = "";
            for(int count = 0; count < results.Count; count++)
            {
                rollText = rollText + results[count] + ", ";
            }

            Console.WriteLine("Dice Rolls:\n\n" + rollText);
            Console.WriteLine("\n\nEnter 'r'epeat to roll the same dice again.");
            Console.WriteLine("\nEnter 'n'ew dice to roll different dice.\n");
            string exit = Console.ReadLine().ToLower();
            if (exit.Length > 0)
            {
                if (exit[0] == 'r')
                {
                    _RollDice(numRolls, numDieSides);
                }
                if (exit[0] == 'n')
                {
                    _RequestDiceInformation();
                }
            }
        }
    }
}
