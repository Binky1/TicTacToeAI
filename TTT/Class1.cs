using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    public class Enemy
    {
        public char[] grid = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public List<int> winningComb = new List<int>() { 123, 456, 789, 147, 258, 369, 159, 357 };
        public List<int> winningComb3 = new List<int>() { 123, 456, 789, 147, 258, 369, 159, 357 };
        public List<int> winningComb2 = new List<int>() { 123, 456, 789, 147, 258, 369, 159, 357 };
        public List<int> X = new List<int>() { };
        public List<int> OM = new List<int>() { };
        public List<int> XO = new List<int>() { }; // the positions where X and O stored
        public List<int> O = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // the positions where O stored
        public List<int> Identify = new List<int>() { 123, 456, 789, 147, 258, 369, 159, 357 };
        public List<int> Win = new List<int>() { 123, 456, 789, 147, 258, 369, 159, 357 };
        public List<int> possible = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> possible2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public int currComb = 0;
        string winComb = "";
        public Enemy()
        {
            RemoveComb();
        }

        public void IdentifyComb()
        {
            for (int i = 0; i < winningComb.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < X.Count; j++)
                {
                    if (winningComb[i].ToString().Contains(X[j].ToString()))
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    Identify[0] = winningComb[i];
                    winningComb.Remove(winningComb[i]);
                }
            }
        }

        public void RemoveComb() //Removing combinations for O
        {
            for (int i = 0; i < winningComb2.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < possible2.Count; j++)
                {
                    if (winningComb2[i].ToString().Contains(possible2[j].ToString()))
                    {
                        count++;
                    }
                }
                if (count != 3)
                {
                    winningComb2.Remove(winningComb2[i]);
                }
            }
            
        }

        public void MoveWin()
        {
            try
            {
                char[] mov = winningComb2[0].ToString().ToArray();

                int mov2 = 0;
                int count = 0;

                for (int i = 0; i < mov.Length; i++)
                {
                    for (int j = 0; j < O.Count; j++)
                    {
                        if (mov[i] == O[j] + 48)
                        {
                            mov2 = mov[i] - 48;
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }


                grid[mov2 - 1] = 'O';
                XO.Add(mov2);
                X.Remove(mov2);
                possible.Remove(mov2);
                O.Remove(mov2);
                OM.Add(mov2);
            }
            catch
            {
                MoveBlock();
            }

        }


        public void MoveBlock()
        {
            try
            {
                char[] mov = Identify[0].ToString().ToArray();
                int mov2 = 0;
                int count = 0;

                for (int i = 0; i < mov.Length; i++)
                {
                    for (int j = 0; j < possible.Count; j++)
                    {
                        if (mov[i] == possible[j] + 48)
                        {
                            mov2 = mov[i] - 48;
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }


                if (Identify[0] != 0)
                {
                    grid[mov2 - 1] = 'O';
                    XO.Add(mov2);
                    O.Remove(mov2);
                    X.Remove(mov2);
                    OM.Add(mov2);
                    possible.Remove(mov2);
                }
            }
            catch
            {
                MoveWin();
            }
        }


        public bool InArr(int value)
        {
            bool inArr = false;
            for (int i = 0; i < XO.Count; i++)
            {
                if (XO[i] == value)
                {
                    inArr = true;
                }
            }
            return inArr;
        }

        public bool InPossible(string str)
        {
            bool inPoss = false;
            for (int j = 0; j < str.Length; j++)
            {
                int count = 0;
                for (int i = 0; i < possible.Count; i++)
                {
                    if (possible[i].ToString().Equals(str.ToString()))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    inPoss = true;
                    break;
                }
            }
            return inPoss;
        }

        public bool isWin()
        {
            bool isWin = false;
            for (int i = 0; i < winningComb3.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < OM.Count; j++)
                {
                    if (winningComb3[i].ToString().Contains(OM[j].ToString()))
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    isWin = true;
                    break;
                }
            }
            return isWin;
        }


        public bool isIdentify()
        {
            bool isIdentify = false;
            for (int i = 0; i < winningComb3.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < X.Count; j++)
                {
                    if (winningComb3[i].ToString().Contains(X[j].ToString()) || InPossible(winningComb3[i].ToString()))
                    {
                        count++;
                    }
                }
                if (count == 2)
                {
                    isIdentify = true;
                    break;
                }
            }
            return isIdentify;
        }


    }
}
