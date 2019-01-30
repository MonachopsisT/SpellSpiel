using System;
using System.Collections.Generic;
using System.IO;

namespace SpellSpiel
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintUI game = new PrintUI();
            game.DifficultyScreen();
            game.PrintWord();
        }
    }
}
