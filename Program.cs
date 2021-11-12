using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMap2._0 // By Brandon V
{
    class Program
    {
        
        static char[,] MAINMAP = new char[,]
        {

        {'*','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'*','*','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','~','\'','\'','\''},
        {'*','*','*','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','~','\'','~','\'','\''},
        {'*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'*','\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','~','~','~','~','~','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','~','~','~','~','~','~','\'','\'','\'','\'','\'','*','\'','\'','\'','\'','\'','\'','\'','^','^','\'','\'','\'','\'','\'','\''},
        {'\'','\'','\'','~','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','~','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','~','^','^','^','^','\'','\'','\''},
        {'\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','\'','\'','\'','\'','\''},
        {'\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','^','\'','\'','\'','\'','\'','\'','\'',},
        {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','*','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','*',},
                };


        static int rows = MAINMAP.GetLength(0);
        static int columns = MAINMAP.GetLength(1);

        static void Main(string[] args)
        {
            Console.WriteLine("Press Any Key To Pull Out Your Map");
            Console.ReadKey();
            Console.WriteLine(" ");
            DisplayMap();
            Console.WriteLine(" ");
            DisplayMap(2);

            Console.ReadKey(true);
        }

        static void DisplayMap()  //MINIMAP
        {

            //TOP
            Console.WriteLine(" MiniMap:  ");
            Console.WriteLine("");
            Console.Write("╒");
            for (int i = 0; i <= columns - 1; i++)
            {
                Console.Write("═");
            }
            Console.Write("╕");
            Console.WriteLine("");

            //MAIN MAP
            for (int x = 0; x <= rows - 1; x++)
            {
                for (int y = 0; y <= columns - 1; y++)
                {
                    if (y == 0)
                    {
                        Console.Write("│");
                    }
                    Console.Write(MAINMAP[x, y]);
                }
                Console.Write("│");
                Console.WriteLine();
            }

            //BOT
            Console.Write("╘");
            for (int i = 0; i <= columns - 1; i++)
            {
                Console.Write("═");
            }
            Console.Write("╛");
            Console.WriteLine("");

            Spacing();
        }

        static void DisplayMap(int scale)   //MAINMAP
        {
            //NOTE: Keep this info. The state was hard to figure out.

            //TOP
            Console.WriteLine(" Main Map:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("╒");
            for (int i = 0; i <= columns * scale - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("═");
            }
            Console.Write("╕");
            Console.WriteLine("");

            //MAINMAP
            for (int x = 0; x <= rows - 1; x++)
            {
                for (int j = 0; j < scale; j++)
                {
                    for (int y = 0; y <= columns - 1; y++)
                    {
                        DisplayColour(x, y);
                        if (y == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("│");
                        }
                        DisplayColour(x, y);
                        for (int i = 0; i < scale; i++)
                        {
                            Console.Write(MAINMAP[x, y]);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("│");
                    Console.WriteLine();
                }
            }


            //BOT
            Console.Write("╘");
            for (int i = 0; i <= columns * scale - 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("═");
            }
            Console.Write("╛");
            Console.WriteLine("");

            Legend();
        }
        

        //MAIN MAP COLOUR
        static void DisplayColour(int x, int y)
        {
            if (MAINMAP[x, y] == '\'')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (MAINMAP[x, y] == '*')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (MAINMAP[x, y] == '~')
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (MAINMAP[x, y] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        //MAINMAP LEGEND
        static void Legend()
        {
            //Legend
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("╔");
            for (int b = 0; b < 16; b++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("═");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("╗");
            Console.WriteLine("");
            Console.WriteLine("║     Legend:    ║");
            Console.WriteLine("║                ║");

            //Mountain
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.DarkGray;           
            Console.Write("^^");
            Console.ResetColor();
            Console.WriteLine(" = Mountain  ║");

            //Grass
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Green;      
            Console.Write("''");
            Console.ResetColor();
            Console.WriteLine(" = Grass     ║");

            //Water
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("~~");
            Console.ResetColor();
            Console.WriteLine(" = Water     ║");

            //Flowers
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("**");
            Console.ResetColor();
            Console.WriteLine(" = Flowers   ║");

            Console.Write("╚");
            for (int l = 0; l < 16; l++)
            {
                Console.Write("═");
            }
            Console.Write("╝");

           
        }
        static void Spacing()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        
    }
}
