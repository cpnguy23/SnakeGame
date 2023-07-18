using System;
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

            AddSnake();
            AddFood();                                                                    
        }

        /* MAKING THE SNAKE */

        private void AddSnake()
        {
            int r = Rows / 2;                                                             /* putting it in middle row */

            for (int  c= 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePosition.AddFirst(new Position(r, c));                               /* we are adding snake first */

            }
        }

        private IEnumerable<Position> EmptyPosition()                                   /* looping through all rows and columns */
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);                                /* provides next value or signal end of                                                                       iteration*/
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPosition());

            if (empty.Count == 0)
            {
                return;
            }

            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.Food;
        }

        /* SNAKE WITH LINKED LISTS */
        public Position HeadPosition()
        {
            return snakePosition.First.Value;
        }

        public Position TailPosition()
        {
            return snakePosition.Last.Value;
        }

        public IEnumerable<Position> SnakePosition()
        {
            return snakePosition;
        }

        /* modifying snake */

        private void AddHead(Position pos)
        {
            snakePosition.AddFirst(pos);
            Grid[pos.Row, pos.Col] = GridValue.Snake;
        }

        private void RemoveTail()
        {
            Position tail = snakePosition.Last.Value;
            Grid[tail.Row, tail.Col] = GridValue.Empty;
            snakePosition.RemoveLast();
        }

        /* modifying game state */

        public void ChangeDir(Direction dir)
        {
            Dir = dir;
        }

        /* moving snake, which we are making only head and tail move */
        
        private bool OutsideGrid(Position pos)                                              /* determines if out of grid*/
        {
            return pos.Row < 0 || pos.Row >= Rows || pos.Col < 0 || pos.Col >= Cols;
        }

        private GridValue WillHit(Position newHeadPos)                                     /* determine if the head hits out of */
        {                                                                                  /* bounds */
            if (OutsideGrid(newHeadPos))
            {
                return GridValue.Outside;                                                  /* left off at  26:51*/
            }
            
             if (newHeadPos == TailPosition())                                             /* head moves, so tail has to move? */
            {                                                                              /* idk how to explain but i know */
                return GridValue.Empty;
            }

            return Grid[newHeadPos.Row, newHeadPos.Col];
        }

        public void Move()                                                                 /* moving snake in specific direction */
        {
            Position newHeadPos = HeadPosition().Translate(Dir);
            GridValue hit = WillHit(newHeadPos);                                           /* checks what will hit */

            if (hit == GridValue.Outside || hit == GridValue.Snake)
            {
                GameOver = true;
            }

            else if (hit == GridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }

            else if (hit  == GridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
            }

        }
    }                                                                                           
}
