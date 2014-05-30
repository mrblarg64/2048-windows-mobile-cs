using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _8402_cs
{
    public partial class Form1 : Form
    {
        //
        //Its my first time using C#/.net i usually use C on linux, forgive the rushed crap
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        int[,] grid;
        bool shouldAdd;

        public Form1()
        {
            InitializeComponent();
            grid = new int[4,4] { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} };
            shouldAdd = true;
            addRandomToGrid();
            shouldAdd = true;
            addRandomToGrid();
            updateGrid();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
                moveUp();
                addRandomToGrid();
                updateGrid();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
                moveDown();
                addRandomToGrid();
                updateGrid();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
                moveLeft();
                addRandomToGrid();
                updateGrid();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
                moveRight();
                addRandomToGrid();
                updateGrid();
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void moveLeft()
        {
            slideLeft();
            combineLeft();
            slideLeft();
        }

        private void moveRight()
        {
            slideRight();
            combineRight();
            slideRight();
        }

        private void moveUp()
        {
            slideUp();
            combineUp();
            slideUp();
        }

        private void moveDown()
        {
            slideDown();
            combineDown();
            slideDown();
        }

        private void slideLeft()
        {
            int x=0;
            int y=0;
            int availSpace=0;
            int usedSpace=0;
            
            while (y != 4)
            {
                availSpace=0;
                while (x != 4)
                {
                    if (grid[x, y] == 0)
                    {
                        availSpace++;
                    }
                    x++;
                }
                x=0;
                if (availSpace != 0)
                {
                    usedSpace=0;
                    while (x != 4)
                    {
                        if (grid[x, y] != 0)
                        {
                            grid[usedSpace, y] = grid[x, y];
                            if (x != usedSpace)
                            {
                                grid[x, y] = 0;
                                shouldAdd = true;
                            }
                            usedSpace++;
                        }
                        x++;
                    }
                }
                y++;
                x = 0;
            }
        }

        private void combineLeft()
        {
            int x = 0;
            int y = 0;

            while (y != 4)
            {
                while (x != 3)
                {
                    if ((grid[x,y]!=0)&&(grid[x, y] == grid[x + 1, y]))
                    {
                        grid[x, y] = 2 * grid[x,y];
                        grid[x + 1, y] = 0;
                        shouldAdd = true;
                    }
                    x++;
                }
                y++;
                x = 0;
            }
        }

        private void slideRight()
        {
            int x = 3;
            int y = 0;
            int availSpace = 0;
            int usedSpace = 0;
            
            while (y != 4)
            {
                availSpace = 0;
                while (x != -1)
                {
                    if (grid[x, y] == 0)
                    {
                        availSpace++;
                    }
                    x--;
                }
                x = 3;
                if (availSpace != 0)
                {
                    usedSpace = 0;
                    while (x != -1)
                    {
                        if (grid[x, y] != 0)
                        {
                            grid[3-usedSpace, y] = grid[x, y];
                            if (x != 3-usedSpace)
                            {
                                grid[x, y] = 0;
                                shouldAdd = true;
                            }
                            usedSpace++;
                        }
                        x--;
                    }
                }
                y++;
                x = 3;
            }
        }

        private void combineRight()
        {
            int x = 3;
            int y = 0;

            while (y != 4)
            {
                while (x != 0)
                {
                    if ((grid[x, y] != 0) && (grid[x, y] == grid[x - 1, y]))
                    {
                        grid[x, y] = 2 * grid[x, y];
                        grid[x - 1, y] = 0;
                        shouldAdd = true;
                    }
                    x--;
                }
                y++;
                x = 3;
            }
        }

        private void slideUp()
        {
            int x = 0;
            int y = 0;
            int availSpace = 0;
            int usedSpace = 0;

            while (x != 4)
            {
                availSpace = 0;
                while (y != 4)
                {
                    if (grid[x, y] == 0)
                    {
                        availSpace++;
                    }
                    y++;
                }
                y = 0;
                if (availSpace != 0)
                {
                    usedSpace = 0;
                    while (y != 4)
                    {
                        if (grid[x, y] != 0)
                        {
                            grid[x, usedSpace] = grid[x, y];
                            if (y != usedSpace)
                            {
                                grid[x, y] = 0;
                                shouldAdd = true;
                            }
                            usedSpace++;
                        }
                        y++;
                    }
                }
                x++;
                y = 0;
            }
        }

        private void combineUp()
        {
            int x = 0;
            int y = 0;

            while (x != 4)
            {
                while (y != 3)
                {
                    if ((grid[x, y] != 0) && (grid[x, y] == grid[x, y + 1]))
                    {
                        grid[x, y] = 2 * grid[x, y];
                        grid[x, y+1] = 0;
                        shouldAdd = true;
                    }
                    y++;
                }
                x++;
                y = 0;
            }
        }

        private void slideDown()
        {
            int x = 0;
            int y = 3;
            int availSpace = 0;
            int usedSpace = 0;

            while (x != 4)
            {
                availSpace = 0;
                while (y != -1)
                {
                    if (grid[x, y] == 0)
                    {
                        availSpace++;
                    }
                    y--;
                }
                y = 3;
                if (availSpace != 0)
                {
                    usedSpace = 0;
                    while (y != -1)
                    {
                        if (grid[x, y] != 0)
                        {
                            grid[x, 3-usedSpace] = grid[x, y];
                            if (y != 3-usedSpace)
                            {
                                grid[x, y] = 0;
                                shouldAdd = true;
                            }
                            usedSpace++;
                        }
                        y--;
                    }
                }
                x++;
                y = 3;
            }
        }

        private void combineDown()
        {
            int x = 0;
            int y = 3;

            while (x != 4)
            {
                while (y != 0)
                {
                    if ((grid[x, y] != 0) && (grid[x, y] == grid[x, y - 1]))
                    {
                        grid[x, y] = 2 * grid[x, y];
                        grid[x, y - 1] = 0;
                        shouldAdd = true;
                    }
                    y--;
                }
                x++;
                y = 3;
            }
        }

        private void addRandomToGrid()
        {
            int x=0;
            int y=0;
            int freeAmount=0;
            int selectedRnd;
            int[] freePositions=new int[32];
            Random rnd = new Random();

            //find how many are free
            //(i know it is innefficient, its written in fucking .net who the fuck cares)
            if (!shouldAdd)
            {
                return;
            }
            shouldAdd = false;
            while (y != 4)
            {
                while (x != 4)
                {
                    if (grid[x, y] == 0)
                    {
                        freePositions[freeAmount*2] = x;
                        freePositions[(freeAmount*2) + 1] = y;
                        freeAmount++;
                    }
                    x++;
                }
                x=0;
                y++;
            }
            //quit if no free
            if (freeAmount == 0)
            {
                return;
            }
            //insert the random number
            selectedRnd=rnd.Next(0, freeAmount);
            grid[freePositions[selectedRnd * 2], freePositions[(selectedRnd * 2) + 1]] = (rnd.Next(1, 3) * 2);
        }

        private void updateGrid()
        {
            if (grid[0, 0] != 0)
            {
                label1.Text = Convert.ToString(grid[0, 0]);
                label1.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label1.Text = "";
                label1.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[1, 0] != 0)
            {
                label2.Text = Convert.ToString( grid[1, 0]);
                label2.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label2.Text = "";
                label2.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[2, 0] != 0)
            {
                label3.Text = Convert.ToString(grid[2, 0]);
                label3.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label3.Text = "";
                label3.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[3, 0] != 0)
            {
                label4.Text = Convert.ToString( grid[3, 0]);
                label4.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label4.Text = "";
                label4.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[0, 1] != 0)
            {
                label5.Text = Convert.ToString( grid[0, 1]);
                label5.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label5.Text = "";
                label5.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[1, 1] != 0)
            {
                label6.Text = Convert.ToString( grid[1, 1]);
                label6.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label6.Text = "";
                label6.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[2, 1] != 0)
            {
                label7.Text = Convert.ToString( grid[2, 1]);
                label7.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label7.Text = "";
                label7.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[3, 1] != 0)
            {
                label8.Text = Convert.ToString( grid[3, 1]);
                label8.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label8.Text = "";
                label8.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[0, 2] != 0)
            {
                label9.Text = Convert.ToString( grid[0, 2]);
                label9.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label9.Text = "";
                label9.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[1, 2] != 0)
            {
                label10.Text = Convert.ToString( grid[1, 2]);
                label10.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label10.Text = "";
                label10.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[2, 2] != 0)
            {
                label11.Text = Convert.ToString( grid[2, 2]);
                label11.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label11.Text = "";
                label11.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[3, 2] != 0)
            {
                label12.Text = Convert.ToString( grid[3, 2]);
                label12.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label12.Text = "";
                label12.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[0, 3] != 0)
            {
                label13.Text = Convert.ToString( grid[0, 3]);
                label13.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label13.Text = "";
                label13.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[1, 3] != 0)
            {
                label14.Text = Convert.ToString( grid[1, 3]);
                label14.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label14.Text = "";
                label14.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[2, 3] != 0)
            {
                label15.Text = Convert.ToString( grid[2, 3]);
                label15.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label15.Text = "";
                label15.BackColor = System.Drawing.Color.Silver;
            }




            if (grid[3, 3] != 0)
            {
                label16.Text = Convert.ToString( grid[3, 3]);
                label16.BackColor = System.Drawing.Color.Magenta;
            }
            else
            {
                label16.Text = "";
                label16.BackColor = System.Drawing.Color.Silver;
            }

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            grid = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            shouldAdd = true;
            addRandomToGrid();
            shouldAdd = true;
            addRandomToGrid();
            updateGrid();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2048 .net Edition\nFor Windows Mobile\nBy Brian Denton\nVersion 1.1\n5-30-2014\nhttp://www.bernmern.net", "2048 .net Edition");
        }
    }
}