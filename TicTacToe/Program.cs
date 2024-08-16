using System;

namespace TicTacToe
{
    class Program
    {
        static char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1; // 1 - игрок номер 1, 2 - игрок номер 2

        static void Main(string[] args)
        {
            int playerChoice;
            bool gameOver = false;

            do
            {
                Console.Clear();
                DrawField();
                Console.WriteLine($"\nХод игрока номер {currentPlayer}:");
                playerChoice = int.Parse(Console.ReadLine()) - 1;

                if (IsValidMove(playerChoice))
                {
                    field[playerChoice] = (currentPlayer == 1) ? 'X' : 'O';

                    if (CheckForWin())
                    {
                        Console.Clear();
                        DrawField();
                        Console.WriteLine($"\nИгрок {currentPlayer} победил!");
                        gameOver = true;
                    }
                    else if (CheckForDraw())
                    {
                        Console.Clear();
                        DrawField();
                        Console.WriteLine("\nНичья!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 1) ? 2 : 1;
                    }
                }
                else
                {
                    Console.WriteLine("\nНекорректный ход!.");
                }

            } while (!gameOver);

            Console.WriteLine("\nИгра окончена.");
        }

        static void DrawField()
        {
            Console.WriteLine($" {field[0]} | {field[1]} | {field[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {field[3]} | {field[4]} | {field[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {field[6]} | {field[7]} | {field[8]} ");
        }


        static bool IsValidMove(int move)
        {
            return (move >= 0 && move <= 8 && field[move] != 'X' && field[move] != 'O');
        }

        static bool CheckForWin()
        {
            if ((field[0] == field[1] && field[1] == field[2]) ||
                (field[3] == field[4] && field[4] == field[5]) ||
                (field[6] == field[7] && field[7] == field[8]) ||
                (field[0] == field[3] && field[3] == field[6]) ||
                (field[1] == field[4] && field[4] == field[7]) ||
                (field[2] == field[5] && field[5] == field[8]) ||
                (field[0] == field[4] && field[4] == field[8]) ||
                (field[2] == field[4] && field[4] == field[6]))
            {
                return true;
            }
            return false;
        }

        static bool CheckForDraw()
        {
            foreach (var cell in field)
            {
                if (cell != 'X' && cell != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
