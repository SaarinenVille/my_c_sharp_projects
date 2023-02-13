namespace YatzyDiceGame
{
    partial class AloitusForm
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
            this.OtsikkoLB = new System.Windows.Forms.Label();
            this.AloitaPeliBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OtsikkoLB
            // 
            this.OtsikkoLB.AutoSize = true;
            this.OtsikkoLB.BackColor = System.Drawing.Color.Transparent;
            this.OtsikkoLB.Font = new System.Drawing.Font("Bernard MT Condensed", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OtsikkoLB.Location = new System.Drawing.Point(93, 74);
            this.OtsikkoLB.Name = "OtsikkoLB";
            this.OtsikkoLB.Size = new System.Drawing.Size(655, 114);
            this.OtsikkoLB.TabIndex = 1;
            this.OtsikkoLB.Text = "Yatzy Dice Game";
            // 
            // AloitaPeliBT
            // 
            this.AloitaPeliBT.BackColor = System.Drawing.Color.MediumAquamarine;
            this.AloitaPeliBT.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AloitaPeliBT.Location = new System.Drawing.Point(305, 389);
            this.AloitaPeliBT.Name = "AloitaPeliBT";
            this.AloitaPeliBT.Size = new System.Drawing.Size(226, 88);
            this.AloitaPeliBT.TabIndex = 2;
            this.AloitaPeliBT.Text = "Aloita Peli";
            this.AloitaPeliBT.UseVisualStyleBackColor = false;
            this.AloitaPeliBT.Click += new System.EventHandler(this.ALoitaPeliBT_Click);
            // 
            // AloitusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::YatzyDiceGame.Properties.Resources.ryunosuke_kikuno_UsocPeObI3Y_unsplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(860, 852);
            this.Controls.Add(this.AloitaPeliBT);
            this.Controls.Add(this.OtsikkoLB);
            this.Name = "AloitusForm";
            this.Text = "Aloitus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label OtsikkoLB;
        private Button AloitaPeliBT;
    }
}