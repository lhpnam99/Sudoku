using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Control
{
    public class Box
    {
        private Cell[] cells;
        private int index = 0;

        public Cell[] Cells { get => cells; set => cells = value; }
        public int Index { get => index; set => index = value; }

        public Box()
        {
            cells = new Cell[9];
        }
        public Boolean Check()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == j) continue;
                    if (GameManager.IsDoubleValue(Cells[i], Cells[j]))
                        return false;
                }
            }
            return true;
        }
        public void AddCell(Cell cell)
        {
            Cells[index] = cell;
            Index++;
        }
    }
}
