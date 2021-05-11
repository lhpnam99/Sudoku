using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sudoku.Control
{
    public class Sudoku
    {
        public Cell[,] Cells = new Cell[9, 9];
        public Cell[,] CellsRoot = new Cell[9, 9];
        public Cell[,] Result = new Cell[9, 9];
        public Cell SelectedCell = new Cell();
        public Box[] boxs = new Box[9];
        public Colum[] colums = new Colum[View.Constant.MAX_COL];
        public Row[] rows = new Row[View.Constant.MAX_ROW];

        public Sudoku solution;
        public Sudoku nextSudoku;
        private GameManager gameManager;

        public bool Completed = false;
        private int countCells;
        private int hours;
        private int minutes;
        private int seconds;
        int Level = 30;
        int countResult = 0;
        public bool Creating = false;

        public int CountCells { get => countCells; set => countCells = value; }
        public int Hours { get => hours; set => hours = value; }
        public int Minutes { get => minutes; set => minutes = value; }
        public int Seconds { get => seconds; set => seconds = value; }

        public Sudoku(GameManager gameManager)
        {
            CreateCellsContainer();
            ClearResult();
            ClearCellsRoot();
            this.gameManager = gameManager;
        }

        public Sudoku(Sudoku source)
        {
            CopyCells(source);
        }

        private void CreateCellsContainer()
        {
            Clear();
            for (int i = 0; i < 9; i++)
            {
                this.rows[i] = new Row();
                this.boxs[i] = new Box();
                this.colums[i] = new Colum();
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    rows[Cells[i, j].Row].AddCell(Cells[i, j]);
                    colums[Cells[i, j].Col].AddCell(Cells[i, j]);
                    boxs[Cells[i, j].Box].AddCell(Cells[i, j]);
                }
            }
        }
        private void CopyCells(Sudoku source)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Cells[i, j] == null)
                    {
                        Cells[i, j] = new Cell();
                    }
                    Cells[i, j].CopyCell(source.Cells[i, j]);
                }
            }
        }

        public void Reset()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].CopyCell(CellsRoot[i, j]);
                }
            }
        }

        //New sudoku
        public void NewGame(int level)
        {
            Level = level;
            CreateSudoku();

            UpdatePossible();
            SetReadOnly();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    CellsRoot[i, j].CopyCell(Cells[i, j]);
                }
            }
            ResetTimePlay();
        }

        public void ResetTimePlay()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        public void SetReadOnly()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].ReadOnly = (Cells[i, j].Value != 0);
                    if (Cells[i, j].ReadOnly)
                    {
                        gameManager.Matrix[i].ElementAt(j).Enabled = false;
                        gameManager.Matrix[i].ElementAt(j).BackColor = System.Drawing.Color.LightBlue;
                    }
                }
            }
        }

        public void CreateSudoku()
        {
            Clear();
            Completed = false;
            Creating = true;

            CreateRandom();

            solution = new Sudoku(this);
        }

        public bool IsValidPossibles(int row)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Cells[row, j].Possible.Count == 0 && Cells[row, j].Value == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void UpdatePossible()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].Possible = GetFullList();
                    for (int v = 1; v <= 9; v++)
                    {
                        if (!IsFeasible(Cells, i, j, v))
                        {
                            Cells[i, j].Possible.Remove(v);
                        }
                    }
                }
            }
        }

        public void Clear()
        {

            Completed = false;
            CountCells = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Cells[i, j] == null)
                    {
                        Cells[i, j] = new Cell();
                    }
                    Cells[i, j].Row = i;
                    Cells[i, j].Col = j;
                    Cells[i, j].Box = GetBoxNum(i, j);
                    Cells[i, j].Value = 0;
                    Cells[i, j].ReadOnly = false;
                    Cells[i, j].Possible = GetFullList();
                }
            }
        }
        public void ClearCellsRoot()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (CellsRoot[i, j] == null)
                    {
                        CellsRoot[i, j] = new Cell();
                    }
                    CellsRoot[i, j].Row = i;
                    CellsRoot[i, j].Col = j;
                    CellsRoot[i, j].Box = GetBoxNum(i, j);
                    CellsRoot[i, j].Value = 0;
                    CellsRoot[i, j].ReadOnly = false;
                    CellsRoot[i, j].Possible = GetFullList();
                }
            }
        }

        public void ClearResult()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Result[i, j] == null)
                    {
                        Result[i, j] = new Cell();
                    }
                    Result[i, j] = new Cell();
                    Result[i, j].Box = GetBoxNum(i, j);
                    Result[i, j].Col = j;
                    Result[i, j].Row = i;
                    Result[i, j].Value = 0;
                    Result[i, j].ReadOnly = false;
                    Result[i, j].Possible = GetFullList();
                }
            }
        }

        public void CreateRandom()
        {
            countResult = 0;

            FillDiagonal();

            ClearResult();
            SolveSudoku(Cells, 0, 0);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].CopyCell(Result[i, j]);
                }
            }

            CountCells = 0;

            while (CountCells <= Level)
            {
                Random ranRow = new Random();
                Random ranCol = new Random();
                int indexRow = ranRow.Next(0, 9);
                int indexCol = ranCol.Next(0, 9);
                if (Cells[indexRow, indexCol].Value != 0)
                {
                    CountCells++;
                    Cells[indexRow, indexCol].Value = 0;
                    UpdatePossible();
                }
            }

            Completed = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    CellsRoot[i, j].CopyCell(Cells[i, j]);
                }
            }

        }

        public void FillDiagonal()
        {
            Clear();

            for (int k = 0; k < 9; k = k + 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //do
                        //{
                            if (Cells[k + i, k + j].Possible.Count > 0)
                            {
                                Random rand = new Random();
                                int index = rand.Next(0, Cells[k + i, k + j].Possible.Count);
                                Cells[k + i, k + j].Value = Cells[k + i, k + j].Possible[index];
                                UpdatePossible();
                            }

                        //}
                        //while (IsFeasible(Cells, k + i, k + j, Cells[k + i, k + j].Value));
                    }
                }
            }
        }
        //List of 1 - 9 
        private List<int> GetFullList()
        {
            return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        //Này quan trọng nè: giải thuật giải sudoku

        public void SolveGame()
        {
            countResult = 0;

            ClearResult();
            SolveSudoku(Cells, 0, 0);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Cells[i, j].CopyCell(Result[i, j]);

                }
            }
        }


        public void SolveSudoku(Cell[,] SolvedCells, int r, int c)
        {
            //Nếu có 1 đáp án rồi thì dừng 
            if (countResult > 0)
            {
                return;
            }
            else 
                if (c == 9)
                {
                    if (r == 8)
                    {
                        //Return đáp án
                        countResult++;
                        for (int i = 0; i < 9; i++)
                        {
                            for (int j = 0; j < 9; j++)
                            {
                                Result[i, j].Value = SolvedCells[i, j].Value;
                            }
                        }
                        return;
                    }
                    else
                    {
                        SolveSudoku(SolvedCells, r + 1, 0);
                    }
                }
                else 
                    if (SolvedCells[r, c].Value == 0)
                    {
                        for (int v = 1; v <= 9; v++)
                        {
                            if (IsFeasible(SolvedCells, r, c, v))
                            {
                                SolvedCells[r, c].Value = v;
                                SolveSudoku(SolvedCells, r, c + 1);
                                SolvedCells[r, c].Value = 0;
                            }
                        }
                    }
                    else
                    {
                        SolveSudoku(SolvedCells, r, c + 1);
                    }
        }

        public Boolean IsFeasible(Cell[,] cells, int r, int c, int v)
        {
            return (IsFeasible_W(cells, r, v) && IsFeasible_H(cells, c, v) && IsFeasible_B(cells, r, c, v));
        }
        public Boolean IsFeasible_W(Cell[,] CellsSolve, int r, int v)
        {
            for (int i = 0; i < 9; i++)
            {
                if (CellsSolve[r, i].Value == v) return false;
            }
            return true;
        }

        public Boolean IsFeasible_H(Cell[,] CellsSolve, int c, int v)
        {
            for (int i = 0; i < 9; i++)
            {
                if (CellsSolve[i, c].Value == v) return false;
            }
            return true;
        }

        public Boolean IsFeasible_B(Cell[,] CellsSolve, int r, int c, int v)
        {
            int a = r / 3, b = c / 3;
            for (int i = 3 * a; i < 3 * a + 3; i++)
            {
                for (int j = 3 * b; j < 3 * b + 3; j++)
                {
                    if (CellsSolve[i, j].Value == v) return false;
                }
            }
            return true;
        }
        //Get box num
        private int GetBoxNum(int r, int c)
        {
            return 3 * (r / 3) + (c / 3);
        }

    }
}
