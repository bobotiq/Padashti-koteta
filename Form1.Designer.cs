namespace Padashti_Koteta
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kittensCaughtLabel = new System.Windows.Forms.Label();
            this.chancesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kittensCaughtLabel
            // 
            this.kittensCaughtLabel.AutoSize = true;
            this.kittensCaughtLabel.BackColor = System.Drawing.Color.Transparent;
            this.kittensCaughtLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kittensCaughtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kittensCaughtLabel.Location = new System.Drawing.Point(944, 482);
            this.kittensCaughtLabel.Name = "kittensCaughtLabel";
            this.kittensCaughtLabel.Size = new System.Drawing.Size(42, 44);
            this.kittensCaughtLabel.TabIndex = 0;
            this.kittensCaughtLabel.Text = "2";
            this.kittensCaughtLabel.Click += new System.EventHandler(this.kittensCaughtLabel_Click);
            // 
            // chancesLabel
            // 
            this.chancesLabel.AutoSize = true;
            this.chancesLabel.BackColor = System.Drawing.Color.Transparent;
            this.chancesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chancesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chancesLabel.Location = new System.Drawing.Point(944, 526);
            this.chancesLabel.Name = "chancesLabel";
            this.chancesLabel.Size = new System.Drawing.Size(42, 44);
            this.chancesLabel.TabIndex = 1;
            this.chancesLabel.Text = "1";
            this.chancesLabel.Click += new System.EventHandler(this.chancesLabel_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.chancesLabel);
            this.Controls.Add(this.kittensCaughtLabel);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox basket;
        private System.Windows.Forms.Button Starter;
        public System.Windows.Forms.PictureBox kitten;
        public System.Windows.Forms.Label kittensCaughtLabel;
        public System.Windows.Forms.Label chancesLabel;
    }
}

