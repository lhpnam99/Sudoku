using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class GameBoard : Form
    {
        private Control.GameManager gameManager;
        
        public GameBoard()
        {
            InitializeComponent();
            gameManager = new Control.GameManager(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rBtnEasy.Checked)
                gameManager.NewGame(View.Constant.MAX_COL * View.Constant.MAX_ROW - Convert.ToInt32((String)rBtnEasy.Tag));
            else
                if (rBtnNormal.Checked)
                    gameManager.NewGame(View.Constant.MAX_COL * View.Constant.MAX_ROW - Convert.ToInt32((String)rBtnNormal.Tag));
                else
                    if (rBtnHard.Checked)
                        gameManager.NewGame(View.Constant.MAX_COL * View.Constant.MAX_ROW - Convert.ToInt32((String)rBtnHard.Tag));
            timerPlaying.Start();
        }

        private void timerPlaying_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbSeconds.Text) == 59)
            {
                gameManager.sudoku.Minutes += 1;
                lbMinutes.Text = gameManager.sudoku.Minutes.ToString();
                gameManager.sudoku.Seconds = -1;
            }
            if (Convert.ToInt32(lbMinutes.Text) == 60)
            {
                gameManager.sudoku.Hours += 1;
                lbHours.Text = gameManager.sudoku.Hours.ToString();
                gameManager.sudoku.Minutes = 0;
                lbMinutes.Text = gameManager.sudoku.Minutes.ToString();
            }
            gameManager.sudoku.Seconds += 1;
            lbSeconds.Text = gameManager.sudoku.Seconds.ToString();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            gameManager.SolveGame();
            gameManager.EndGame();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sudoku is played on a grid of 9 x 9 spaces. " +
                "Within the rows and columns are 9 “squares” (made up of 3 x 3 spaces). " +
                "Each row, column and square (9 spaces each) needs to be filled out with the numbers 1-9," +
                " without repeating any numbers within the row, column or square. " +
                "The more spaces filled in, the easier the game – the more " +
                "difficult Sudoku puzzles have very few spaces that are already filled in.");
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            lbFolderPath.Text = openFileDialog1.FileName.ToString();
        }
    }
}
