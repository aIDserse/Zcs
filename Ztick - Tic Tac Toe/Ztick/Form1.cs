using System.Numerics;

namespace Ztick
{
    public partial class Form1 : Form
    {
        Game gb;
        public Form1()
        {
            InitializeComponent();
            gb = new Game();
            LoadBoard();
            label1.Visible = false;
        }
        private void LoadBoard()
        {
            if (gb[0, 0] == Player.Open)
                button00.Text = "N";
            else
            {
                button00.Text = gb[0, 0].ToString();
                button00.Enabled = false;
            }

            if (gb[0, 1] == Player.Open)
                button01.Text = "N";
            else
            {
                button01.Text = gb[0, 1].ToString();
                button01.Enabled = false;
            }

            if (gb[0, 2] == Player.Open)
                button02.Text = "N";
            else
            {
                button02.Text = gb[0, 2].ToString();
                button02.Enabled = false;
            }

            if (gb[1, 0] == Player.Open)
                button10.Text = "N";
            else
            {
                button10.Text = gb[1, 0].ToString();
                button10.Enabled = false;
            }

            if (gb[1, 1] == Player.Open)
                button11.Text = "N";
            else
            {
                button11.Text = gb[1, 1].ToString();
                button11.Enabled = false;
            }

            if (gb[1, 2] == Player.Open)
                button12.Text = "N";
            else
            {
                button12.Text = gb[1, 2].ToString();
                button12.Enabled = false;
            }

            if (gb[2, 0] == Player.Open)
                button20.Text = "N";
            else
            {
                button20.Text = gb[2, 0].ToString();
                button20.Enabled = false;
            }

            if (gb[2, 1] == Player.Open)
                button21.Text = "N";
            else
            {
                button21.Text = gb[2, 1].ToString();
                button21.Enabled = false;
            }

            if (gb[2, 2] == Player.Open)
                button22.Text = "N";
            else
            {
                button22.Text = gb[2, 2].ToString();
                button22.Enabled = false;
            }
            label1.Visible = false;
        }
        private void BlockBoard()
        {
            button00.Enabled = false;
            button01.Enabled = false;
            button02.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
        }
        private void unBlockBoard()
        {
            button00.Enabled = true;
            button01.Enabled = true;
            button02.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
        }
        public bool CheckForWinners()
        {
            Player? p = gb.Winner;
            if (p == Player.X)
            {
                label1.Text = "Computer Wins"; 
                label1.Visible = true;
                return true;
            }
            else if (p == Player.O)
            {
                label1.Text = "You won";
                label1.Visible = true;
                return true;
            }
            return false;
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            unBlockBoard();
            Game ng = new Game();
            gb = ng;
            LoadBoard();
            label1.Visible = false;
        }
        private void placeAI()
        {
            Space s;
            if (gb.OpenSquares.Count == gb.Size)
            {
                Random r = new Random();
                s = new Space(r.Next(0, 3), r.Next(0, 3));
            }
            else
            {
                if (!gb.IsFull)
                {
                    s = AI.GetBestMove(gb, Player.X);
                    gb[s.X, s.Y] = Player.X;
                    LoadBoard();
                    if (CheckForWinners())
                    {
                        BlockBoard();
                    }
                }
                else
                {
                    label1.Text = "Draw";
                    label1.Visible = true;
                }
            }
        }

        private void button00_Click(object sender, EventArgs e)
        {
            gb[0, 0] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button01_Click(object sender, EventArgs e)
        {
            gb[0, 1] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button02_Click(object sender, EventArgs e)
        {
            gb[0, 2] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gb[1, 0] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gb[1, 1] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            gb[1, 2] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            gb[2, 0] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            gb[2, 1] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            gb[2, 2] = Player.O;
            LoadBoard();
            if (CheckForWinners())
            {
                BlockBoard();
            }
            placeAI();
        }
    }
}