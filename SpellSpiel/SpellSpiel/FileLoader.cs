using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SpellSpiel
{
    /*This class is uesed to operate with the files
     *      it contains a constructor and one method
     *      In the constructor the path to the file is created
     * The OpenFile() is used to open the file and save all of its lines to a List thet is later used as dictionary for the game
     */

    class FileLoader
    {
        //VARIABLES//VARIABLES//VARIABLES//VARIABLES//VARIABLES
        private string dictionaryName = "KS";//the main part of the file name
        private string path = @"../../../../../Dictionaries/"; //goes back to the main folder and then to the folder containing the files
        private StreamReader sR;
        private string line; //save the line of text from the file

        private int index = 0;
        private string[] temp = new string[2];
        private List<string[]> parts = new List<string[]>();

        //only used if choosing a random dictionary
        private byte dictionaryNumber = 1; //using byte to save space since the value of the variable will be from 1 to 3

        //CONSTRUCTOR -> create the path to the file
        public FileLoader()
        {
            //Chose a random dictionary
            //Random rand = new Random();
            //dictionaryNumber = (byte)rand.Next(1,4);//1-3

            dictionaryName += dictionaryNumber.ToString() + ".txt";
            path += dictionaryName;
        }

        //open the file and read through it and add everything in the dictionary
        public List<String[]> OpenFile()
        {
            try
            {
                //UTF-8 is the encoding or all the text files so thet when there is a special symbol it is displayed properly and not with a '?'
                sR = new StreamReader(path, Encoding.UTF8);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("No File");
            }

            //do this until you reach the end of the file
            while (!sR.EndOfStream)
            {
                line = sR.ReadLine();
                index = parts.Count;

                //if the line should not be ommited then go on
                if (!(line.Contains('[') && line.Contains(']')))
                {
                    if (line.Contains('-'))
                    {

                        temp = line.Split('-');
                        temp[0] = temp[0].Trim();
                        temp[1] = temp[1].Trim();

                        //each element of the list is a 2D array
                        parts.Add(new string[2]);

                        parts[index][0] = temp[0];
                        parts[index][1] = temp[1];


                    }

                }

            }

            sR.Close();

            return parts;
        }

    }

}
