using System;
using System.Collections.Generic;
using System.Text;

namespace SpellSpiel
{
    /*DISCLAMER
    //when there is a 2-letter word and the obf. is 1/3 there is no missing letter
    */

    /*The Main purpose of theis class is the obfuscation
     *      it contains a constructor and 5 methods
     * ChooseTheWord() -> gets the next word in the list
     * ObfValue -> is a method of the type get;set; snd is used to set the value of obfuscation
     * Words() -> this is the method that obfuscates the charecters in the word
     * CorrectAnswer() -> compare the correct answer with the user input
     * Print() -> prints the "word" screen
     */

    class Obfuscate
    {
        //VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES
        private FileLoader instance = new FileLoader(); //instance of FileLoader.cs to take the List
        private List<string[]> dictionary = new List<string[]>();

        private string word;
        private string example;
        private bool isEndOfDictionery = false;

        private string[] current = new string[2];

        private double obfValue; //lvl1->1/3 etc.

        private bool isNew = true;
        private int indexToObf;
        private char underscore = '_';  //the symbol that will replace the letters
        private int wordLength;
        private string obfWord;
        private string correct;
        private int lettersToObf;
        Random rand;
        private string wordToPrint;

        public string userAnswer;
        private int points = 0;

        private int correctNum = 0;
        private int wrongNum = 0;
        private int levelOfObf;
        
        //CONSTRUCTOR
        public Obfuscate()
        {
            dictionary = instance.OpenFile();
        }

        //USED TO GET THE NEXT WORD IN THE LIST
        public void ChooseTheWord(int wordNumber)
        {
            if (wordNumber < dictionary.Count)
            {
                word = dictionary[wordNumber][0];
                example = dictionary[wordNumber][1];
                isEndOfDictionery = false;
            }
            else
            {
                isEndOfDictionery = true;
            }
        }

        /* the user chooses between the four levels of dificulty ib PrintUI.cs
         * then the value is taken with switch-case
         * this will then set the amount of letters that has to be obfuscated
         * eg. Lvl 1 -> obfValue = 1/3
         *     Lvl 2 -> obfValue = 1/2
         */
        public double ObfValue
        {
            get
            {
                return obfValue;
            }
            set
            {
                obfValue = value;
            }
        }

        //OBFUSCATEING CHARECTERS
        private string Words(int wordNum)
        {
            
            rand = new Random();
            ChooseTheWord(wordNum);
            correct = word;
            obfWord = correct;
            wordLength = correct.Length;
            lettersToObf = (int)Math.Floor(wordLength * obfValue);

            if (levelOfObf != 4)
            {
                for (int i = 0; i < lettersToObf; i++)
                {

                    lettersToObf = (int)Math.Floor(wordLength * obfValue);
                    indexToObf = rand.Next(0, wordLength);

                    if (obfWord[indexToObf] == underscore)
                    {
                        isNew = false;
                    }
                    else
                    {
                        isNew = true;
                        obfWord = obfWord.Replace(obfWord[indexToObf], underscore);
                    }


                    while (!isNew)
                    {

                        indexToObf = rand.Next(0, wordLength);

                        if (obfWord[indexToObf] != underscore)
                        {
                            isNew = true;
                            obfWord = obfWord.Replace(obfWord[indexToObf], underscore);
                        }
                    }


                }
            }
            else
            {
                for(int i=0; i<obfWord.Length;i++)
                {
                    obfWord = obfWord.Replace(obfWord[i],underscore);
                }
            }
            return obfWord;
        }

        //Check if the answer is correct and returns the current points
        public int CorrectAnswer()
        {
            userAnswer = Console.ReadLine();
            if (correct.Equals(userAnswer))
            {
                points += 2;
                correctNum++;
            }
            else
            {
                wrongNum++;
            }
                return points;
        }

        //Prints the main screen of the game
        public void Print(int level)
        {
            levelOfObf = level;
            for (int i = 0; i < dictionary.Count; i++)
            {
                wordToPrint = Words(i);
                if (!isEndOfDictionery)
                {
                    example = example.Replace(correct, obfWord);
                    Console.WriteLine("Current Level: {0}                                     Correct Words: {1}", level, correctNum);
                    Console.WriteLine("Points: {0}                                            Wrong Words: {1}", points,wrongNum);
                    Console.WriteLine("\n");
                    Console.WriteLine("             After you are sure in your answer press \"Enter\"");
                    Console.WriteLine();
                    Console.WriteLine("                               {0}", wordToPrint);
                    Console.WriteLine("                             ({0})", example);
                    Console.WriteLine();

                    CorrectAnswer();

                    System.Threading.Thread.Sleep(1000); //wait 1 sec before clearing the console so thet it does not disappear imediately
                    Console.Clear();
                }
                
                if(i == dictionary.Count-1)
                {
                    isEndOfDictionery = true;
                }
            }


            if (isEndOfDictionery)
            {
                Console.WriteLine("Points: {0}", points);
                Console.WriteLine("\n");
                Console.WriteLine("You have reached the last word!");
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
