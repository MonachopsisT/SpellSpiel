using System;
using System.Collections.Generic;
using System.Text;

namespace SpellSpiel
{
    /* This class is mainly used to print ther differnt screens 
     *      it is also used to set the value which helps with the obfuscation
     * The class contains a constructor and two method
     * The method PrintWord() prints the "word" screen taking it from the Obfuscate.cs`s method Print() 
     * The DifficultyScreen() method validates the input and offers a choice to the user to choose what level of difficulty they want
     *      then it sets the value which helps with the obfuscation in Obfuscate.cs
     */

    class PrintUI
    {
        //VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES
        public Obfuscate obf = new Obfuscate();

        public int input;
        bool isValid = true;
        double value;
        private int lvl;

        public PrintUI()
        {

        }

        public void PrintWord()
        {
            obf.Print(lvl);
        }

        //pRINTS THE SCREEN FOR CHOOSING THE DIFFICULTY LEVEL AND VALIDATING INPUT
        public void DifficultyScreen()
        {
            do
            {
                Console.WriteLine("Choose the level of difficulty for the game!");
                Console.WriteLine("Type a number between 1 and 4 and then press \"Enter\" ");
                Console.WriteLine();
                Console.WriteLine("Press 1 for LEVEL 1 ---> 1/3 of the charecters are obfuscated");
                Console.WriteLine("Press 2 for LEVEL 2 ---> 1/2 of the charecters are obfuscated");
                Console.WriteLine("Press 3 for LEVEL 3 ---> 2/3 of the charecters are obfuscated");
                Console.WriteLine("Press 4 for LEVEL 4 ---> ALL charecters are missing");
                Console.WriteLine();

                //VALIDATING THE INPUT
                try
                {
                    input = int.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {
                   // Console.WriteLine("Invalid input trye again!");
                    isValid = false;
                }

                if (input >= 1 && input <= 4)
                {
                    isValid = true;
                }
                else
                    isValid = false;

                Console.Clear();
                
            }
            while (!isValid);

            switch (input)
            {
                case 1:
                    {
                       value = 1f / 3f;
                        obf.ObfValue = value;
                        lvl = 1;
                        break;
                    }
                case 2:
                    {
                        value = 1f / 2f;
                        obf.ObfValue = value;
                        lvl = 2;
                        break;
                    }
                case 3:
                    {
                        value = 2f / 3f;
                        obf.ObfValue = (value);
                        lvl = 3;
                        break;
                    }
                case 4:
                    {
                       value = 1;
                        obf.ObfValue =value;
                        lvl = 4;
                        break;
                    }
            }
            
            Console.Clear();
        }

    }

}

