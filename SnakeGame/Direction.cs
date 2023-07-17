using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Direction
    {
        /* rows and columns, direction in terms of up, down, right, left will be written as static variables, their values do NOT change */
        /* readonly = declares a member value constant, but the value can be calculated during runtime */

        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);

        public int RowOffSet { get; }
        public int ColOffSet { get; }

        private Direction (int rowOffSet, int colOffSet)
        {
            RowOffSet = rowOffSet;
            ColOffSet = colOffSet;
        }

        public Direction Opposite()                         /* returning new direction with opposite row and column offsets */
        {
            return new Direction(-RowOffSet, -ColOffSet);
        }

        public override bool Equals(object obj)             /* lines 33 to 54 compares directions */
        {
            return obj is Direction direction &&
                   RowOffSet == direction.RowOffSet &&
                   ColOffSet == direction.ColOffSet;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowOffSet, ColOffSet);
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return EqualityComparer<Direction>.Default.Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }
    }
}
