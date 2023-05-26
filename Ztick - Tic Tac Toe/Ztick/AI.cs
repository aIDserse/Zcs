using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ztick
{
    public class AI
    {
        public static Space GetBestMove(Board gb, Player p)
        {
            Space? bestSpace = null;
            List<Space> openSpaces = gb.OpenSquares;
            Board newBoard;

            for (int i = 0; i < openSpaces.Count; i++)
            {
                newBoard = gb.Clone();
                Space newSpace = openSpaces[i];

                newBoard[newSpace.X, newSpace.Y] = p;

                if (newBoard.Winner == Player.Open && newBoard.OpenSquares.Count > 0)
                {
                    Space tempMove = GetBestMove(newBoard, ((Player)(-(int)p)));
                    newSpace.Rank = tempMove.Rank;
                }
                else
                {
                    if (newBoard.Winner == Player.Open)
                        newSpace.Rank = 0;
                    else if (newBoard.Winner == Player.X)
                        newSpace.Rank = -1;
                    else if (newBoard.Winner == Player.O)
                        newSpace.Rank = 1;
                }
                if (bestSpace == null ||
                   (p == Player.X && newSpace.Rank < ((Space)bestSpace).Rank) ||
                   (p == Player.O && newSpace.Rank > ((Space)bestSpace).Rank))
                {
                    bestSpace = newSpace;
                }
            }
            return (Space)bestSpace;
        }
    }
}
