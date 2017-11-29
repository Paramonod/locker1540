namespace testapp.UsersPage
{
    partial class UsersForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSurn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSecName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddUserBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ChangeBtn = new System.Windows.Forms.Button();
            this.NameT = new System.Windows.Forms.TextBox();
            this.SurnT = new System.Windows.Forms.TextBox();
            this.SecNameT = new System.Windows.Forms.TextBox();
            this.PosT = new System.Windows.Forms.TextBox();
            this.NumT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColName,
            this.ColSurn,
            this.ColSecName,
            this.ColPos,
            this.ColNum});
            this.listView1.Location = new System.Drawing.Point(21, 85);
            this.listView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(777, 892);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ColName
            // 
            this.ColName.Text = "Имя";
            this.ColName.Width = 184;
            // 
            // ColSurn
            // 
            this.ColSurn.Text = "Фамилия";
            this.ColSurn.Width = 244;
            // 
            // ColSecName
            // 
            this.ColSecName.Text = "Отчество";
            this.ColSecName.Width = 179;
            // 
            // ColPos
            // 
            this.ColPos.Text = "Должность";
            this.ColPos.Width = 177;
            // 
            // ColNum
            // 
            this.ColNum.Text = "Номер карты";
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.Location = new System.Drawing.Point(57, 20);
            this.AddUserBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(521, 56);
            this.AddUserBtn.TabIndex = 1;
            this.AddUserBtn.Text = "Добавить пользователя";
            this.AddUserBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(871, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(871, 163);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фамилия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(871, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(871, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "Должность:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(871, 395);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 39);
            this.label5.TabIndex = 6;
            this.label5.Text = "Номер карты:";
            // 
            // ChangeBtn
            // 
            this.ChangeBtn.Location = new System.Drawing.Point(880, 476);
            this.ChangeBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ChangeBtn.Name = "ChangeBtn";
            this.ChangeBtn.Size = new System.Drawing.Size(311, 56);
            this.ChangeBtn.TabIndex = 7;
            this.ChangeBtn.Text = "Изменить данные";
            this.ChangeBtn.UseVisualStyleBackColor = true;
            // 
            // NameT
            // 
            this.NameT.Location = new System.Drawing.Point(1218, 87);
            this.NameT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.NameT.Name = "NameT";
            this.NameT.ReadOnly = true;
            this.NameT.Size = new System.Drawing.Size(601, 38);
            this.NameT.TabIndex = 8;
            this.NameT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SurnT
            // 
            this.SurnT.Location = new System.Drawing.Point(1218, 161);
            this.SurnT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SurnT.Name = "SurnT";
            this.SurnT.ReadOnly = true;
            this.SurnT.Size = new System.Drawing.Size(601, 38);
            this.SurnT.TabIndex = 9;
            this.SurnT.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // SecNameT
            // 
            this.SecNameT.Location = new System.Drawing.Point(1218, 239);
            this.SecNameT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SecNameT.Name = "SecNameT";
            this.SecNameT.ReadOnly = true;
            this.SecNameT.Size = new System.Drawing.Size(601, 38);
            this.SecNameT.TabIndex = 10;
            this.SecNameT.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // PosT
            // 
            this.PosT.Location = new System.Drawing.Point(1218, 316);
            this.PosT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PosT.Name = "PosT";
            this.PosT.ReadOnly = true;
            this.PosT.Size = new System.Drawing.Size(601, 38);
            this.PosT.TabIndex = 11;
            this.PosT.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // NumT
            // 
            this.NumT.Location = new System.Drawing.Point(1218, 394);
            this.NumT.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.NumT.Name = "NumT";
            this.NumT.ReadOnly = true;
            this.NumT.Size = new System.Drawing.Size(601, 38);
            this.NumT.TabIndex = 12;
            this.NumT.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 998);
            this.Controls.Add(this.NumT);
            this.Controls.Add(this.PosT);
            this.Controls.Add(this.SecNameT);
            this.Controls.Add(this.SurnT);
            this.Controls.Add(this.NameT);
            this.Controls.Add(this.ChangeBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddUserBtn);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button AddUserBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ChangeBtn;
        private System.Windows.Forms.TextBox NameT;
        private System.Windows.Forms.TextBox SurnT;
        private System.Windows.Forms.TextBox SecNameT;
        private System.Windows.Forms.TextBox PosT;
        private System.Windows.Forms.TextBox NumT;
        private System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader ColSurn;
        private System.Windows.Forms.ColumnHeader ColSecName;
        private System.Windows.Forms.ColumnHeader ColPos;
        private System.Windows.Forms.ColumnHeader ColNum;
    }
}