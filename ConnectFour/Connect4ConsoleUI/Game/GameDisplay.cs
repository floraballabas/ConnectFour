﻿using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4ConsoleUI.Game
{
    public class GameDisplay
    {
        private IPlayer player1;
        private IPlayer player2;

        public GameDisplay(IPlayer p1, IPlayer p2)
        {
            player1 = p1;
            player2 = p2;
        }
        public void ShowStartMessage()
        {
            Console.WriteLine("Welcome to Connect Four.");
        }

        public void ShowBoard(char[,] gameData)
        {

            int rows = gameData.GetLength(0);
            int columns = gameData.GetLength(1);
            
            Console.WriteLine("  0 1 2 3 4 5 6");
            for (int i = 0; i < rows; ++i)
            {
                Console.Write(i);
                for(int j = 0; j < columns; ++j)
                {
                    Console.Write("|");
                    if (gameData[i, j] == player1.PlayerID)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    if (gameData[i, j] == player2.PlayerID)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write( gameData[i, j]);

                    Console.ResetColor();
                }
                Console.WriteLine("|");
            }
            
            
        }

        public void AskForMove(IPlayer player)
        {
            Console.WriteLine(string.Format("Player {0} enter a move, enter 'q' to quit", player.PlayerID));
            Console.Write(">> ");
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DelcareWinner(IMoveResult result)
        {
            Console.WriteLine(string.Format("Player {0} has won the game in {1} moves!", result.Moves[0].Player.PlayerID, result.Moves[0].SequenceNumber));
            
        }

        public void DelcareTie()
        {
            Console.WriteLine(string.Format("The game is a tie, well fought players!"));

        }

        public void WaitToQuit()
        {
            Console.WriteLine(string.Format("Hit any key to exit game"));
            Console.Read();
        }
    }
}
