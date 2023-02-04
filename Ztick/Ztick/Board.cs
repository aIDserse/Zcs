using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ztick
{
    public enum Player
    {
        X = 1,
        O = -1,
        Open = 0,
    }

    public abstract class Board
    {
        public Player[,] squares;
        public abstract Player this[int x, int y] { get; set; }
        public abstract bool IsFull { get; }
        public abstract int Size { get; }
        public abstract List<Space> OpenSquares { get; }
        public abstract Player Winner { get; }
        public abstract Board Clone();
    }
    public struct Space
    {
        public int X;
        public int Y;
        public double Rank;

        public Space(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Rank = 0;
        }
    }
}
