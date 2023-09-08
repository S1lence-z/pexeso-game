namespace Pexeso_DU
{
    partial class Form1
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
            smallest = new Button();
            middle = new Button();
            largest = new Button();
            start = new Button();
            label1 = new Label();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // smallest
            // 
            smallest.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            smallest.Location = new Point(140, 173);
            smallest.Name = "smallest";
            smallest.Size = new Size(179, 167);
            smallest.TabIndex = 0;
            smallest.Text = "6 x 4";
            smallest.UseVisualStyleBackColor = true;
            smallest.Click += button1_Click;
            // 
            // middle
            // 
            middle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            middle.Location = new Point(325, 173);
            middle.Name = "middle";
            middle.Size = new Size(179, 167);
            middle.TabIndex = 1;
            middle.Text = "6 x 5";
            middle.UseVisualStyleBackColor = true;
            middle.Click += button2_Click;
            // 
            // largest
            // 
            largest.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            largest.Location = new Point(510, 173);
            largest.Name = "largest";
            largest.Size = new Size(179, 167);
            largest.TabIndex = 2;
            largest.Text = "6 x 6";
            largest.UseVisualStyleBackColor = true;
            largest.Click += button3_Click;
            // 
            // start
            // 
            start.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            start.Location = new Point(140, 346);
            start.Name = "start";
            start.Size = new Size(549, 171);
            start.TabIndex = 3;
            start.Text = "START";
            start.UseVisualStyleBackColor = true;
            start.Click += button4_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(140, 57);
            label1.Name = "label1";
            label1.Size = new Size(549, 88);
            label1.TabIndex = 4;
            label1.Text = "Vybrané rozměry: 0 x 0";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(277, 173);
            button5.Name = "button5";
            button5.Size = new Size(279, 167);
            button5.TabIndex = 5;
            button5.Text = "Start Menu";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(277, 346);
            button6.Name = "button6";
            button6.Size = new Size(279, 171);
            button6.TabIndex = 6;
            button6.Text = "Restartovat Hru";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(784, 761);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(start);
            Controls.Add(largest);
            Controls.Add(middle);
            Controls.Add(smallest);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Pexeso - Zelenka";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button smallest;
        private Button middle;
        private Button largest;
        private Button start;
        private Label label1;
        private Button button5;
        private Button button6;
    }
}