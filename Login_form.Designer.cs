namespace Projektinis_darbas_akademine_is
{
    partial class Login_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            Vardas = new TextBox();
            Slaptazodis = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(35, 158);
            button1.Name = "button1";
            button1.Size = new Size(100, 25);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Vardas
            // 
            Vardas.Location = new Point(35, 57);
            Vardas.Name = "Vardas";
            Vardas.RightToLeft = RightToLeft.No;
            Vardas.Size = new Size(100, 23);
            Vardas.TabIndex = 1;
            // 
            // Slaptazodis
            // 
            Slaptazodis.Location = new Point(35, 104);
            Slaptazodis.Name = "Slaptazodis";
            Slaptazodis.RightToLeft = RightToLeft.No;
            Slaptazodis.Size = new Size(100, 23);
            Slaptazodis.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 86);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(174, 223);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Slaptazodis);
            Controls.Add(Vardas);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox Vardas;
        private TextBox Slaptazodis;
        private Label label1;
        private Label label2;
    }
}