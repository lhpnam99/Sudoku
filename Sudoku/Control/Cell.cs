using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Control
{
    public class Cell
    {
        private int col;
        private int row;
        private int box;
        private String tag;
        private int value;
        private bool readOnly;
        private List<int> possible = new List<int>();

        public int Col { get => col; set => col = value; }
        public int Row { get => row; set => row = value; }
        public int Box { get => box; set => box = value; }
        public int Value { get => value; set => this.value = value; }
        public String Tag { get => tag; set => tag = value; }
        public List<int> Possible { get => possible; set => possible = value; }
        public bool ReadOnly { get => readOnly; set => readOnly = value; }

        public Cell(Cell source)
        {
            CopyCell(source);
        }
        public Cell()
        {
            for (int i = 1; i <= 9; i++)
            {
                this.Possible.Add(i);
            }
        }
        public void CopyCell(Cell source)
        {
            Possible = new List<int>(source.Possible);
            this.Row = source.Row;
            this.Col = source.Col;
            this.Box = source.Box;
            this.Tag = source.Tag;
            this.Value = source.Value;
        }
    }
}
