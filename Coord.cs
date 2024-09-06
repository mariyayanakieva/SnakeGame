using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Coord
    {
        private int x;
        private int y;


        public int X { get{ return x; }}
        public int Y { get { return y; }  }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)//sravnqvaneto na dva obekta chrez equal
        {
           if (obj == null|| !GetType().Equals(obj.GetType()))
            {
                return false;
            }
           Coord other= (Coord)obj;
            return x == other.x && y == other.y;
        }

        public void ApplyingDirections(Direction direction) //zadavame dvijeniqta na gouemata zmiq
        {
            switch (direction)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
            }
        }
    }
}
