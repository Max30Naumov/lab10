namespace lab7
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btAdd = new Button();
            btRemove = new Button();
            btShow = new Button();
            label5 = new Label();
            TBId = new TextBox();
            TBFirstName = new TextBox();
            TBLastName = new TextBox();
            TBAge = new TextBox();
            listBoxQuque = new ListBox();
            SerializeToJsonBtn = new Button();
            DeserializeFromJsonBtn = new Button();
            SerializeToBinaryBtn = new Button();
            DeserializeFromBin = new Button();
            SortAgeDelegate = new Button();
            SortIDLambda = new Button();
            SearchByLastNameLamda = new Button();
            SearchByNameDelegat = new Button();
            lab10Btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(65, 159);
            label1.Name = "label1";
            label1.Size = new Size(51, 28);
            label1.TabIndex = 0;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 233);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 1;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(65, 309);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 2;
            label3.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(248, 9);
            label4.Name = "label4";
            label4.Size = new Size(324, 28);
            label4.TabIndex = 3;
            label4.Text = "Управление очередью пациентов";
            // 
            // btAdd
            // 
            btAdd.FlatStyle = FlatStyle.Flat;
            btAdd.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btAdd.Location = new Point(248, 160);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(198, 39);
            btAdd.TabIndex = 4;
            btAdd.Text = "Добавить пациента";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btRemove
            // 
            btRemove.FlatStyle = FlatStyle.Flat;
            btRemove.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btRemove.Location = new Point(248, 108);
            btRemove.Name = "btRemove";
            btRemove.Size = new Size(198, 39);
            btRemove.TabIndex = 5;
            btRemove.Text = "Удалить пациента";
            btRemove.UseVisualStyleBackColor = true;
            btRemove.Click += btRemove_Click;
            // 
            // btShow
            // 
            btShow.FlatStyle = FlatStyle.Flat;
            btShow.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            btShow.Location = new Point(248, 58);
            btShow.Name = "btShow";
            btShow.Size = new Size(198, 39);
            btShow.TabIndex = 6;
            btShow.Text = "Показать очередь";
            btShow.UseVisualStyleBackColor = true;
            btShow.Click += btShow_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(65, 84);
            label5.Name = "label5";
            label5.Size = new Size(29, 28);
            label5.TabIndex = 7;
            label5.Text = "Id";
            // 
            // TBId
            // 
            TBId.Location = new Point(63, 126);
            TBId.Name = "TBId";
            TBId.Size = new Size(125, 27);
            TBId.TabIndex = 8;
            // 
            // TBFirstName
            // 
            TBFirstName.Location = new Point(63, 203);
            TBFirstName.Name = "TBFirstName";
            TBFirstName.Size = new Size(125, 27);
            TBFirstName.TabIndex = 9;
            // 
            // TBLastName
            // 
            TBLastName.Location = new Point(65, 279);
            TBLastName.Name = "TBLastName";
            TBLastName.Size = new Size(125, 27);
            TBLastName.TabIndex = 10;
            // 
            // TBAge
            // 
            TBAge.Location = new Point(63, 355);
            TBAge.Name = "TBAge";
            TBAge.Size = new Size(125, 27);
            TBAge.TabIndex = 11;
            // 
            // listBoxQuque
            // 
            listBoxQuque.FormattingEnabled = true;
            listBoxQuque.ItemHeight = 20;
            listBoxQuque.Location = new Point(483, 58);
            listBoxQuque.Name = "listBoxQuque";
            listBoxQuque.Size = new Size(361, 544);
            listBoxQuque.TabIndex = 12;
            // 
            // SerializeToJsonBtn
            // 
            SerializeToJsonBtn.FlatStyle = FlatStyle.Flat;
            SerializeToJsonBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SerializeToJsonBtn.Location = new Point(248, 208);
            SerializeToJsonBtn.Name = "SerializeToJsonBtn";
            SerializeToJsonBtn.Size = new Size(198, 39);
            SerializeToJsonBtn.TabIndex = 17;
            SerializeToJsonBtn.Text = "Сохранить в JSON";
            SerializeToJsonBtn.UseVisualStyleBackColor = true;
            SerializeToJsonBtn.Click += SerializeToJsonBtn_Click;
            // 
            // DeserializeFromJsonBtn
            // 
            DeserializeFromJsonBtn.FlatStyle = FlatStyle.Flat;
            DeserializeFromJsonBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            DeserializeFromJsonBtn.Location = new Point(248, 253);
            DeserializeFromJsonBtn.Name = "DeserializeFromJsonBtn";
            DeserializeFromJsonBtn.Size = new Size(198, 39);
            DeserializeFromJsonBtn.TabIndex = 18;
            DeserializeFromJsonBtn.Text = "Прочитать из JSON";
            DeserializeFromJsonBtn.UseVisualStyleBackColor = true;
            DeserializeFromJsonBtn.Click += DeserializeFromJsonBtn_Click;
            // 
            // SerializeToBinaryBtn
            // 
            SerializeToBinaryBtn.FlatStyle = FlatStyle.Flat;
            SerializeToBinaryBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SerializeToBinaryBtn.Location = new Point(248, 302);
            SerializeToBinaryBtn.Name = "SerializeToBinaryBtn";
            SerializeToBinaryBtn.Size = new Size(198, 39);
            SerializeToBinaryBtn.TabIndex = 19;
            SerializeToBinaryBtn.Text = "Сохранить в BIN";
            SerializeToBinaryBtn.UseVisualStyleBackColor = true;
            SerializeToBinaryBtn.Click += SerializeToBinaryBtn_Click;
            // 
            // DeserializeFromBin
            // 
            DeserializeFromBin.FlatStyle = FlatStyle.Flat;
            DeserializeFromBin.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            DeserializeFromBin.Location = new Point(248, 350);
            DeserializeFromBin.Name = "DeserializeFromBin";
            DeserializeFromBin.Size = new Size(198, 39);
            DeserializeFromBin.TabIndex = 20;
            DeserializeFromBin.Text = "Прочитать из BIN";
            DeserializeFromBin.UseVisualStyleBackColor = true;
            DeserializeFromBin.Click += DeserializeFromBin_Click;
            // 
            // SortAgeDelegate
            // 
            SortAgeDelegate.FlatStyle = FlatStyle.Flat;
            SortAgeDelegate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SortAgeDelegate.Location = new Point(248, 396);
            SortAgeDelegate.Name = "SortAgeDelegate";
            SortAgeDelegate.Size = new Size(198, 66);
            SortAgeDelegate.TabIndex = 21;
            SortAgeDelegate.Text = "Сортировка по возрасту";
            SortAgeDelegate.UseVisualStyleBackColor = true;
            SortAgeDelegate.Click += SortAgeDelegate_Click;
            // 
            // SortIDLambda
            // 
            SortIDLambda.FlatStyle = FlatStyle.Flat;
            SortIDLambda.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SortIDLambda.Location = new Point(248, 468);
            SortIDLambda.Name = "SortIDLambda";
            SortIDLambda.Size = new Size(198, 41);
            SortIDLambda.TabIndex = 22;
            SortIDLambda.Text = "Сортировка по ID";
            SortIDLambda.UseVisualStyleBackColor = true;
            SortIDLambda.Click += SortIDLambda_Click;
            // 
            // SearchByLastNameLamda
            // 
            SearchByLastNameLamda.FlatStyle = FlatStyle.Flat;
            SearchByLastNameLamda.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SearchByLastNameLamda.Location = new Point(248, 515);
            SearchByLastNameLamda.Name = "SearchByLastNameLamda";
            SearchByLastNameLamda.Size = new Size(198, 40);
            SearchByLastNameLamda.TabIndex = 23;
            SearchByLastNameLamda.Text = "Поиск по фамилии";
            SearchByLastNameLamda.UseVisualStyleBackColor = true;
            SearchByLastNameLamda.Click += SearchByLastNameLamda_Click;
            // 
            // SearchByNameDelegat
            // 
            SearchByNameDelegat.FlatStyle = FlatStyle.Flat;
            SearchByNameDelegat.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            SearchByNameDelegat.Location = new Point(248, 561);
            SearchByNameDelegat.Name = "SearchByNameDelegat";
            SearchByNameDelegat.Size = new Size(198, 40);
            SearchByNameDelegat.TabIndex = 24;
            SearchByNameDelegat.Text = "Поиск по имени";
            SearchByNameDelegat.UseVisualStyleBackColor = true;
            SearchByNameDelegat.Click += SearchByNameDelegat_Click;
            // 
            // lab10Btn
            // 
            lab10Btn.FlatStyle = FlatStyle.Flat;
            lab10Btn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            lab10Btn.Location = new Point(35, 433);
            lab10Btn.Name = "lab10Btn";
            lab10Btn.Size = new Size(178, 62);
            lab10Btn.TabIndex = 25;
            lab10Btn.Text = "Практическая  №10";
            lab10Btn.UseVisualStyleBackColor = true;
            lab10Btn.Click += lab10Btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 624);
            Controls.Add(lab10Btn);
            Controls.Add(SearchByNameDelegat);
            Controls.Add(SearchByLastNameLamda);
            Controls.Add(SortIDLambda);
            Controls.Add(SortAgeDelegate);
            Controls.Add(DeserializeFromBin);
            Controls.Add(SerializeToBinaryBtn);
            Controls.Add(DeserializeFromJsonBtn);
            Controls.Add(SerializeToJsonBtn);
            Controls.Add(listBoxQuque);
            Controls.Add(TBAge);
            Controls.Add(TBLastName);
            Controls.Add(TBFirstName);
            Controls.Add(TBId);
            Controls.Add(label5);
            Controls.Add(btShow);
            Controls.Add(btRemove);
            Controls.Add(btAdd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btAdd;
        private Button btRemove;
        private Button btShow;
        private Label label5;
        private TextBox TBId;
        private TextBox TBFirstName;
        private TextBox TBLastName;
        private TextBox TBAge;
        private ListBox listBoxQuque;
        private Button SerializeToJsonBtn;
        private Button DeserializeFromJsonBtn;
        private Button SerializeToBinaryBtn;
        private Button DeserializeFromBin;
        private Button SortAgeDelegate;
        private Button SortIDLambda;
        private Button SearchByLastNameLamda;
        private Button SearchByNameDelegat;
        private Button lab10Btn;
    }
}