using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_game
{
    public partial class Form1 : Form
    {
        private List<circle> snake = new List<circle>();
        private circle food = new circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;


        public Form1()
        {
            InitializeComponent();

            new settings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && settings.direction != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && settings.direction != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && settings.direction != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && settings.direction != "up")
            {
                goDown = true;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {

        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                settings.direction = "left";
            }
            if (goRight)
            {
                settings.direction="right";
            }
            if (goUp)
            {
                settings.direction = "up";
            }
            if (goDown)
            {
                settings.direction = "down";
            }

            for(int i = snake.Count-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (settings.direction)
                    {
                        case "left":
                            snake[i].X--;
                            break;
                        case "right":
                            snake[i].X++;
                            break;
                        case "up":
                            snake[i].Y--;
                            break;
                        case "down":
                            snake[i].Y++;
                            break;
                    }

                    if (snake[i].X < 0)
                    {
                        snake[i].X = maxWidth;
                    }
                    if (snake[i].X > maxWidth)
                    {
                        snake[i].X = 0;
                    }
                    if (snake[i].Y < 0)
                    {
                        snake[i].Y = maxHeight;
                    }
                    if (snake[i].Y > maxHeight)
                    {
                        snake[i].Y = 0;
                    }

                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for(int j=1; j<snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    snake[i].X = snake[i-1].X;
                    snake[i].Y = snake[i-1].Y;

                }
            }
            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;

            for(int i=0; i<snake.Count; i++)
            {
                if(i == 0)
                {
                    snakeColour = Brushes.Black; 
                }
                else
                {
                    snakeColour= Brushes.Green;
                }
               
                canvas.FillRectangle(snakeColour, new Rectangle(
                    snake[i].X * settings.width,
                    snake[i].Y * settings.height,
                    settings.width, settings.height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle(
                    food.X * settings.width,
                    food.Y * settings.height,
                    settings.width, settings.height
                    ));

        }

        private void gmOver_Click(object sender, EventArgs e)
        {

        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / settings.width - 1;
            maxHeight = picCanvas.Height / settings.height - 1;

            snake.Clear();
            gmOver.Visible = false;

            startButton.Enabled = false;
            snapButton.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;

            circle head = new circle { X = 10, Y = 5 };
            snake.Add(head);

            for(int i = 0; i < 2; i++)
            {
                circle body = new circle();
                snake.Add(body);
            }

            food = new circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimmer.Start();

        }

        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;

            circle body = new circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(body );

            food = new circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            gameTimmer.Stop();
            startButton.Enabled=true;
            snapButton.Enabled=true;

            if (score > highScore)
            {
                highScore = score;

                txtHighScore.Text = "High Score: " + highScore;
            }
            gmOver.Visible=true;
            gmOver.Text = "Game Over";
            gmOver.BackColor = Color.LightGray;
           
        }


    }
}
