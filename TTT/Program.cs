using System;
using System.Collections.Generic;
using System.Linq;

namespace TTT // Note: actual namespace depends on the project name.
{
    public class Program
    {

        public static bool isOver(Enemy ene)
        {
            bool isOver = false;
            for (int i = 0; i < ene.winningComb3.Count; i++)
            {
                int countX = 0;
                int countO = 0;
                for (int j = 0; j < ene.X.Count; j++)
                {
                    if (ene.winningComb3[i].ToString().Contains(ene.X[j].ToString()))
                    {
                        countX++;
                    }
                }

                for (int x = 0; x < ene.OM.Count; x++)
                {
                    if (ene.winningComb3[i].ToString().Contains(ene.OM[x].ToString()))
                    {
                        countO++;
                    }
                }
                if (countX == 3 || countO == 3)
                {
                    isOver = true;
                }
            }
            return isOver;
        }

        public static void Board(Enemy ene)
        {
            Console.WriteLine($"|  { ene.grid[0]}  | { ene.grid[1]}   | { ene.grid[2]}");
            Console.WriteLine($" ----  ---- ----");
            Console.WriteLine($"|  {ene.grid[3]}  | {ene.grid[4]}   | {ene.grid[5]}");
            Console.WriteLine($" ----  ---- ----");
            Console.WriteLine($"|  {ene.grid[6]}  | {ene.grid[7]}   | {ene.grid[8]}");
            Console.WriteLine(" ----  ---- ----");
        }


        public static void Main(string[] args)
        {

            Enemy ene = new Enemy();
            int attempts = 0;
            int count = 0;


            /////////////////////////////////////////////////////
            /////////////////////////////////////////////////////

            Board(ene);
            Console.WriteLine("Enter position: ");
            int position = int.Parse(Console.ReadLine());
            bool Over = isOver(ene);
            while (position != 10 && !Over)
            {
                if (!Over)
                {


                    ene.grid[position - 1] = 'X';
                    ene.X.Add(position);
                    ene.XO.Add(position);
                    ene.possible.Remove(position);
                    ene.possible2.Remove(position);
                    Over = isOver(ene);

                    Board(ene);
                    ene.RemoveComb();
                    Console.WriteLine("Winning comb for O");
                    for (int i = 0; i < ene.winningComb2.Count; i++)
                    {
                        Console.Write(ene.winningComb2[i] + " ");
                    }
                    //Console.WriteLine(ene.winningComb2[0]);
                    Console.WriteLine("Possible");
                    for (int i = 0; i < ene.possible.Count; i++)
                    {
                        Console.Write(ene.possible[i] + " ");
                    }
                    Console.WriteLine("Identify");

                    ene.IdentifyComb();
                    Console.WriteLine(ene.Identify[0]);

                    Console.WriteLine(attempts);
                    Console.WriteLine();
                    attempts++;
                    Console.WriteLine(attempts);
                    if (!isOver(ene))
                    {


                        if (ene.isWin())
                        {
                            ene.RemoveComb();
                            ene.isWin();
                            ene.MoveWin();
                        }
                        else if (ene.isIdentify())
                        {
                            ene.IdentifyComb();
                            ene.MoveBlock();
                        }
                        else
                        {
                            ene.RemoveComb();
                            ene.isWin();
                            ene.MoveWin();
                        }


                    }
                    // Print the game board
                    /*if (attempts % 2 == 1)
                    {
                        ene.RemoveComb();
                        position = ene.MoveWin();
                        Console.WriteLine(ene.winningComb[0]);
                        ene.grid[position - 1] = 'O';
                        ene.XO.Add(position);
                        ene.possible.Remove(position);
                    }
                    else
                    {
                        int currComb = ene.IdentifyComb();
                        position = ene.MoveBlock(currComb);
                        Console.WriteLine(ene.currComb);
                        ene.grid[position - 1] = 'O';
                        ene.XO.Add(position);
                        ene.possible.Remove(position);
                    }
                    */
                    Board(ene);
                    if (!isOver(ene))
                    {
                        Console.WriteLine("Enter position: ");
                        position = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                }
            }
        }
    }
}