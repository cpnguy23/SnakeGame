﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameState
    {
        /* game state: we need the num of rows and columns on grid, the grid itself, the direction of the snake, score, and game over boolean */

        public int Rows { get; }                            /**/
        public int Cols { get; }
        public GridValue[,] Grid { get; }                   /* two dimensional array of grid values */
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }
        
        /* lines 20 - 32 MAKING THE GRID */


        /* using linked lists so that we can add and delete freely */
        private readonly LinkedList<Position> snakePosition = new LinkedList<Position>();  /* position snake is occupying */
        private readonly Random random = new Random();                                     /* where food will spawn (random) */

        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[rows, cols];
            Dir = Direction.Right;                                                        /* snake will starting on the right right*/
        }

        /* MAKING THE SNAKE */

        private void AddSnake()
        {
            int r = Rows / 2;                                                             /* putting it in middle row */

            for (int  c= 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
            }
        }
    }                                                                                           
}