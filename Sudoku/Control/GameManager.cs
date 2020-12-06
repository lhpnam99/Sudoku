using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku.Control
{
    public class GameManager
    {
        public List<List<Button>> Matrix;
        public Sudoku sudoku;
        GameBoard gameBoard;
        private Model.DataManager dataManager;

        public GameManager(GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            sudoku = new Sudoku(this);
            CreateGameButton(this.gameBoard);
            dataManager = new Model.DataManager();
        }
        public void LoadFile(string inputPath)
        {
            dataManager.UpLoad(this, inputPath);
            ClearGameBoard();
            sudoku.SetReadOnly();
            ShowCells();
            sudoku.ResetTimePlay();
            gameBoard.timerPlaying.Start();
        }
        public void TimeIsTick()
        {
            if (Convert.ToInt32(gameBoard.lbSeconds.Text) == 59)
            {
                sudoku.Minutes += 1;
                gameBoard.lbMinutes.Text = sudoku.Minutes.ToString();
                sudoku.Seconds = -1;
            }
            if (Convert.ToInt32(gameBoard.lbMinutes.Text) == 60)
            {
                sudoku.Hours += 1;
                gameBoard.lbHours.Text = sudoku.Hours.ToString();
                sudoku.Minutes = 0;
                gameBoard.lbMinutes.Text = sudoku.Minutes.ToString();
            }
            sudoku.Seconds += 1;
            gameBoard.lbSeconds.Text = sudoku.Seconds.ToString();
        }
        public void NewGame(int level)
        {
            ClearGameBoard();
            sudoku.NewGame(level);
            ShowCells();
        }
        private void ShowCells()
        {
            for (int i = 0; i < View.Constant.MAX_ROW; i++)
            {
                for (int j = 0; j < View.Constant.MAX_COL; j++)
                {
                    ShowCellValue(sudoku.Cells[i, j], Matrix[i].ElementAt(j));
                }
            }
        }
        private void ShowCellValue(Cell cell, Button btn)
        {
            if (cell.Value == 0)
                btn.Text = "";
            else
                btn.Text = cell.Value.ToString();
        }
        public void CreateGameButton(GameBoard gameBoard)
        {
            Matrix = new List<List<Button>>();
            int count = 1;
            Button oldButton = new Button()
            {
                Width = View.Constant.CHESS_WIDTH,
                Height = View.Constant.CHESS_HEIGHT,
                Location = new Point(0 - View.Constant.CHESS_WIDTH + View.Constant.MARGIN, View.Constant.MARGIN)
            };
            for (int i = 0; i < 9; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button()
                    {
                        Width = View.Constant.CHESS_WIDTH,
                        Height = View.Constant.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width + View.Constant.MARGIN, oldButton.Location.Y),
                        Tag = sudoku.Cells[i, j]
                    };
                    sudoku.Cells[i, j].Tag = count.ToString();
                    count++;

                    gameBoard.pnlGameBoard.Controls.Add(btn);

                    btn.GotFocus += new System.EventHandler(this.btnGotFocus);

                    Matrix[i].Add(btn);

                    oldButton.Location = btn.Location;
                }
                oldButton.Location = new Point(0 - View.Constant.CHESS_WIDTH + View.Constant.MARGIN, oldButton.Location.Y + View.Constant.CHESS_HEIGHT + View.Constant.MARGIN);
                
            }
        }

        private void btnGotFocus(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnKeyPress);
            btn.LostFocus += new System.EventHandler(this.btnLostFocus);
            Cell cell = btn.Tag as Cell;
            ShowSuggestions(cell);
        }
        private void ShowSuggestions(Cell cell)
        {
            foreach(int number in cell.Possible)
            {
                if (number == 0) continue;
                gameBoard.lbSuggestions.Text += number + " ";
            }
        }
        private void btnLostFocus(object sender, EventArgs e)
        {
            gameBoard.lbSuggestions.Text = "Suggestions: ";
        }
        private void btnKeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 49; i <= 57; i++)
            {
                if (e.KeyChar == i)
                {
                    Button btn = sender as Button;
                    btn.Text = (i - 48).ToString();
                    GetValueFromButton(btn);
                    
                    if (IsEndGame())
                        EndGame();
                    
                    break;
                }
            }
        }
        public void GetValueFromButton(Button btn)
        {
            Cell cell = btn.Tag as Cell;
            if (btn.Text != "")
            {
                cell.Value = Convert.ToInt32(btn.Text);
                sudoku.UpdatePossible();
            }
            else
                cell.Value = 0;
        }
        public Boolean IsEndGame()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sudoku.Cells[i, j].Value == 0)
                        return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (!(sudoku.boxs[i].Check() && sudoku.colums[i].Check() && sudoku.rows[i].Check()))
                    return false;
            }

            return true;
        }
        public void EndGame()
        {
            gameBoard.timerPlaying.Stop();
            MessageBox.Show("Your achievements is: " + sudoku.Hours + ":" + sudoku.Minutes + ":" + sudoku.Seconds);
        }
        public void SolveGame()
        {
            ClearGamePlay();
            sudoku.SolveGame();
            ShowCells();
        }
        public void ClearGamePlay()
        {
            for (int i = 0; i < 9; i ++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Matrix[i].ElementAt(j).Enabled == true)
                    {
                        Matrix[i].ElementAt(j).Enabled = true;
                        Matrix[i].ElementAt(j).BackColor = System.Drawing.SystemColors.Control;
                        Matrix[i].ElementAt(j).Text = "";
                        GetValueFromButton(Matrix[i].ElementAt(j));
                    }
                }
            }
        }
        public void ClearGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Matrix[i].ElementAt(j).Enabled = true;
                    Matrix[i].ElementAt(j).BackColor = System.Drawing.SystemColors.Control;
                    Matrix[i].ElementAt(j).Text = "";
                }
            }
        }

        public static Boolean IsDoubleValue(Cell a, Cell b)
        {
            return ((a.Value != 0 && b.Value != 0) && (a.Value == b.Value)) ? true : false;
        }
        /*public String ReadFile*/
    }
}
