﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
    public class DataManager
    {
        public void UpLoad(Control.GameManager gameManager, String inputPath)
        {
            gameManager.sudoku.Clear();

            char[] unwanted = new char[] { ' ' };
            try
            {

                // Open the text file using a stream reader
                using (var reader = new StreamReader(inputPath))
                {
                    int row = 0;

                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        int column = 0;
                        string[] numbersString = line.Split(unwanted);
                        foreach (string a in numbersString)
                        {
                            if (Int32.Parse(a) != 0)
                            {
                                gameManager.sudoku.Cells[row, column].Value = Int32.Parse(a);
                                gameManager.sudoku.Cells[row, column].ReadOnly = true;
                            }
                            column++;
                        }
                        line = reader.ReadLine();
                        row++;
                    }
                }
                gameManager.sudoku.UpdatePossible();
            }
            catch (IOException e)
            {
                Console.WriteLine("Không thể đọc file này :");
                Console.WriteLine(e.Message);
            }

            gameManager.sudoku.SetReadOnly();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    gameManager.sudoku.CellsRoot[i, j].CopyCell(gameManager.sudoku.Cells[i, j]);
                }
            }
        }
        public Boolean DownLoad(Control.GameManager gameManager, String outputPath)
        {
            return false;
        }
        /*public String ReadFile(F)*/
    }
}
