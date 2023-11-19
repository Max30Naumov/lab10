namespace lab7
{
    partial class lab10
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
            GenerateBtn = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDownSum = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SortBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // GenerateBtn
            // 
            GenerateBtn.FlatStyle = FlatStyle.Flat;
            GenerateBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            GenerateBtn.Location = new Point(84, 226);
            GenerateBtn.Name = "GenerateBtn";
            GenerateBtn.Size = new Size(149, 42);
            GenerateBtn.TabIndex = 0;
            GenerateBtn.Text = "Генерировать";
            GenerateBtn.UseVisualStyleBackColor = true;
            GenerateBtn.Click += GenerateBtn_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(346, 64);
            numericUpDown1.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(138, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(346, 140);
            numericUpDown3.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(138, 27);
            numericUpDown3.TabIndex = 2;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(346, 181);
            numericUpDown4.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(138, 27);
            numericUpDown4.TabIndex = 3;
            // 
            // numericUpDownSum
            // 
            numericUpDownSum.Location = new Point(303, 22);
            numericUpDownSum.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownSum.Name = "numericUpDownSum";
            numericUpDownSum.Size = new Size(138, 27);
            numericUpDownSum.TabIndex = 4;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(346, 100);
            numericUpDown2.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(138, 27);
            numericUpDown2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 62);
            label1.Name = "label1";
            label1.Size = new Size(309, 25);
            label1.TabIndex = 6;
            label1.Text = "Количество елементов для потока 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(11, 102);
            label2.Name = "label2";
            label2.Size = new Size(309, 25);
            label2.TabIndex = 7;
            label2.Text = "Количество елементов для потока 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(11, 142);
            label3.Name = "label3";
            label3.Size = new Size(309, 25);
            label3.TabIndex = 7;
            label3.Text = "Количество елементов для потока 3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(11, 179);
            label4.Name = "label4";
            label4.Size = new Size(309, 25);
            label4.TabIndex = 7;
            label4.Text = "Количество елементов для потока 4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(37, 20);
            label5.Name = "label5";
            label5.Size = new Size(260, 25);
            label5.TabIndex = 7;
            label5.Text = "Общее количество елементов";
            // 
            // SortBtn
            // 
            SortBtn.FlatStyle = FlatStyle.Flat;
            SortBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SortBtn.Location = new Point(273, 226);
            SortBtn.Name = "SortBtn";
            SortBtn.Size = new Size(149, 42);
            SortBtn.TabIndex = 8;
            SortBtn.Text = "Сортировать";
            SortBtn.UseVisualStyleBackColor = true;
            SortBtn.Click += SortBtn_Click;
            // 
            // lab10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 309);
            Controls.Add(SortBtn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDownSum);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown1);
            Controls.Add(GenerateBtn);
            Name = "lab10";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "lab10";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSum).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenerateBtn;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDownSum;
        private NumericUpDown numericUpDown2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button SortBtn;
    }
}