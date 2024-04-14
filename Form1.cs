using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Timer = System.Windows.Forms.Timer;

namespace Padashti_Koteta
{
    public partial class Form1 : Form
    {
        Button starterr;
        Label highScoreLabel;
        bool isMovingLeft = false;
        bool isMovingRight = false;
        Timer timer;
        Random random;
        List<PictureBox> kittens = new List<PictureBox>();
        List<PictureBox> dogs = new List<PictureBox>();
        int chances = 3;
        int highScore = 0;
        PictureBox failPictureBox;
        int kittensCaught = 0;
        Button easyButton;
        Button mediumButton;
        Button hardButton;
        int difficultyLevel = 1;          
        int kittenSpeed = 3;   

        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            Focus();
            this.TransparencyKey = Color.Transparent;
            this.Load += Form1_Load;
            InitializeComponent();
            InitializeStartButton();
            InitializeHighScoreLabel();
            InitializeDifficultyButtons();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = Properties.Resources.FallingKittens;

        }
        private void InitializeGame()
        {

            basket = new PictureBox();
            basket.BackColor = Color.Transparent;
            basket.Size = new Size(150, 100);
            basket.Image = Properties.Resources.basket;
            basket.SizeMode = PictureBoxSizeMode.StretchImage;
            basket.Location = new Point((this.ClientSize.Width - basket.Width) / 2, this.ClientSize.Height - basket.Height - 20);
            this.Controls.Add(basket);

            chancesLabel = new Label();
            chancesLabel.BackColor = Color.Transparent;
            this.chancesLabel.BackColor = System.Drawing.Color.Transparent;
            chancesLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            chancesLabel.Location = new Point(180, 20);
            chancesLabel.Size = new Size(150, 30);
            chancesLabel.Text = "Lives: " + chances;
            this.Controls.Add(chancesLabel);

            failPictureBox = new PictureBox();
            failPictureBox.BackColor = Color.Transparent;
            failPictureBox.Image = Properties.Resources.fail_image;
            failPictureBox.Size = new Size(50, 50);
            failPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            failPictureBox.Visible = false;
            this.Controls.Add(failPictureBox);

            kittensCaughtLabel = new Label();
            kittensCaughtLabel.BackColor = Color.Transparent;
            this.kittensCaughtLabel.BackColor = System.Drawing.Color.Transparent;
            kittensCaughtLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            kittensCaughtLabel.Location = new Point(580, 430);
            kittensCaughtLabel.Size = new Size(200, 30);
            kittensCaughtLabel.Text = "Kittens Caught: " + kittensCaught;
            this.Controls.Add(kittensCaughtLabel);

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;

            random = new Random();

            timer.Start();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                    isMovingLeft = true;
                
            }
            else if (e.KeyCode == Keys.D)
            {
                isMovingRight = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                isMovingLeft = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                isMovingRight = false;
            }
        }

        private void Basket()
        {
            int basketSpeed = 10;
            if (isMovingLeft)
            {
                basket.Left -= basketSpeed;
            }
            else if (isMovingRight)
            {
                basket.Left += basketSpeed;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        public void Timer_Tick(object sender, EventArgs e)
        { 
            Basket();
            foreach (PictureBox kitten in new List<PictureBox>(kittens))
            {

                kitten.Top += kittenSpeed;

                if (kitten.Bounds.IntersectsWith(basket.Bounds))
                {
                    this.Controls.Remove(kitten);
                    kittens.Remove(kitten);
                    kittensCaught++;

                    break;
                }

                if (kitten.Top >= this.ClientSize.Height)
                {
                    this.Controls.Remove(kitten);
                    kittens.Remove(kitten);
                    DecreaseChances();

                    DisplayFailPictureBox(kitten.Left, kitten.Top);
                }
            }

            foreach (PictureBox dog in new List<PictureBox>(dogs))
            {
                dog.Top += kittenSpeed;

                if (dog.Bounds.IntersectsWith(basket.Bounds))
                {
                    this.Controls.Remove(dog);
                    dogs.Remove(dog);
                    DecreaseChances();

                    DisplayFailPictureBox(dog.Left, dog.Top);

                }

                if (dog.Top >= this.ClientSize.Height)
                {
                    this.Controls.Remove(dog);
                    dogs.Remove(dog);

                    break;
                }
            }

            int x = (this.ClientSize.Width - failPictureBox.Width) / 2;

            int y = (this.ClientSize.Height - failPictureBox.Height) / 2;

            failPictureBox.Location = new Point(x, y);

            UpdateKittensCaughtLabel();
            UpdateHighScore();
        }
        private void InitializeDifficultyButtons()
        {
            easyButton = new Button();
            easyButton.Text = "Easy";
            easyButton.Size = new Size(100, 50);
            easyButton.Location = new Point((this.ClientSize.Width - 350) / 2, (this.ClientSize.Height - 250) / 2);
            easyButton.Click += (sender, e) => { kittenSpeed = 4; };
            this.Controls.Add(easyButton);

            mediumButton = new Button();
            mediumButton.Text = "Medium";
            mediumButton.Size = new Size(100, 50);
            mediumButton.Location = new Point((this.ClientSize.Width - 350) / 2 + 120, (this.ClientSize.Height - 250) / 2);
            mediumButton.Click += (sender, e) => { kittenSpeed = 6; };
            this.Controls.Add(mediumButton);

            hardButton = new Button();
            hardButton.Text = "Hard";
            hardButton.Size = new Size(100, 50);
            hardButton.Location = new Point((this.ClientSize.Width - 350) / 2 + 240, (this.ClientSize.Height - 250) / 2);
            hardButton.Click += (sender, e) => { kittenSpeed = 8;  };
            this.Controls.Add(hardButton);
        }
        private void AddKittenTimer_Tick(object sender, EventArgs e)
        {
            AddKitten();
        }
        private void AddDogTimer_Tick(object sender, EventArgs e)
        {
            AddDog();
        }
        private void AddKitten()
        {
            PictureBox kitten = new PictureBox();
            kitten.BackColor = Color.Transparent;
            kitten.Size = new Size(100, 100);
            kitten.Image = Properties.Resources.kitten;
            kitten.SizeMode = PictureBoxSizeMode.StretchImage;
            kitten.Location = new Point(random.Next(this.ClientSize.Width - kitten.Width), 0);
            while (IntersectsExistingKitten(kitten) || IntersectsExistingDog(kitten))
            {
                kitten.Location = new Point(random.Next(this.ClientSize.Width - kitten.Width), 0);
            }

            this.Controls.Add(kitten);
            kittens.Add(kitten);
        }
        private bool IntersectsExistingKitten(PictureBox newKitten)
        {
            foreach (PictureBox existingKitten in kittens)
            {
                if (newKitten.Bounds.IntersectsWith(existingKitten.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddDog()
        {
            PictureBox dog = new PictureBox();
            dog.BackColor = Color.Transparent;
            dog.Size = new Size(100, 100);
            dog.Image = Properties.Resources.dog;
            dog.SizeMode = PictureBoxSizeMode.StretchImage;
            dog.Location = new Point(random.Next(this.ClientSize.Width - dog.Width), 0);
            while (IntersectsExistingDog(dog) || IntersectsExistingKitten(dog))
            {
                dog.Location = new Point(random.Next(this.ClientSize.Width - dog.Width), 0);
            }
            this.Controls.Add(dog);
            dogs.Add(dog);
        }
        private bool IntersectsExistingDog(PictureBox newDog)
        {
            foreach (PictureBox existingDog in dogs)
            {
                if (newDog.Bounds.IntersectsWith(existingDog.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        private void InitializeHighScoreLabel()
        {
            highScoreLabel = new Label();
            highScoreLabel.Text = "High Score: " + highScore;
            highScoreLabel.Size = new Size(150, 30);
            highScoreLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            highScoreLabel.Location = new Point(20, 20);
            this.Controls.Add(highScoreLabel);
        }

        private void InitializeStartButton()
        {
            starterr = new Button();
            starterr.Text = "Start Game";
            starterr.Size = new Size(300, 100);
            starterr.Location = new Point((this.ClientSize.Width - starterr.Width) / 2, (this.ClientSize.Height - starterr.Height) / 2);
            starterr.Click += starterr_Click;    
            this.Controls.Add(starterr);
        }
        private void starterr_Click(object sender, EventArgs e)
        {
            InitializeGame();

            Timer addKittenTimer = new Timer();
            addKittenTimer.Interval = 1500;
            addKittenTimer.Tick += AddKittenTimer_Tick;
            addKittenTimer.Start();

            Timer addDogTimer = new Timer();
            addDogTimer.Interval = 4200;
            addDogTimer.Tick += AddDogTimer_Tick;
            addDogTimer.Start();

            this.Controls.Remove(starterr);
            this.Controls.Remove(easyButton);
            this.Controls.Remove(mediumButton);
            this.Controls.Remove(hardButton);
        }

        private void UpdateHighScore()
        {
            if (kittensCaught > highScore)
            {
                highScore = kittensCaught;
                highScoreLabel.Text = "High Score: " + highScore;
            }
        }
        private void ResetGame()
        {
            this.Controls.Remove(basket);
            basket.Dispose();       

            basket = new PictureBox();
            basket.BackColor = Color.Transparent;
            basket.Size = new Size(150, 100);
            basket.Image = Properties.Resources.basket;
            basket.SizeMode = PictureBoxSizeMode.StretchImage;
            basket.Location = new Point((this.ClientSize.Width - basket.Width) / 2, this.ClientSize.Height - basket.Height - 20);
            this.Controls.Add(basket);

            foreach (var kitten in kittens)
            {
                this.Controls.Remove(kitten);
                kitten.Dispose();       
            }
            kittens.Clear();    

            foreach (var dog in dogs)
            {
                this.Controls.Remove(dog);
                dog.Dispose();       
            }
            dogs.Clear();    
            chances = 3;
            kittensCaught = 0;
            UpdateChancesLabel();
            UpdateKittensCaughtLabel();
            UpdateLivesLabel();
            highScoreLabel.Text = "High Score: " + highScore;
        }

        private void UpdateKittensCaughtLabel()
        {
            kittensCaughtLabel.Text = "Kittens Caught: " + kittensCaught;
        }
        private void DecreaseChances()
        {
            chances--;
            UpdateLivesLabel();

            if (chances == 0)
            {
                GameOver();
            }
        }
        private void UpdateLivesLabel()
        {
            chancesLabel.Text = "Lives: " + chances;
        }
        private void UpdateChancesLabel()
        {
            chancesLabel.Text = "Lives: " + chances;
        }
        private void DisplayFailPictureBox(int x, int y)
        {
            failPictureBox.Location = new Point(x, y);
            failPictureBox.Visible = true;
            Timer failPictureBoxTimer = new Timer();
            failPictureBoxTimer.Interval = 800;
            failPictureBoxTimer.Tick += (sender, e) =>
            {
                failPictureBox.Visible = false;
                failPictureBoxTimer.Stop();
                failPictureBoxTimer.Dispose();
            };
            failPictureBoxTimer.Start();
        }

        private void GameOver()
        {
                ResetGame();
        }

        private void kittensCaughtLabel_Click(object sender, EventArgs e)
        {

        }

        private void chancesLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
