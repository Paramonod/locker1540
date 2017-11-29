namespace testapp.UsersPage
{
    partial class addUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StChange = new System.Windows.Forms.Button();
            this.StOk = new System.Windows.Forms.Button();
            this.StName = new System.Windows.Forms.TextBox();
            this.StSur = new System.Windows.Forms.TextBox();
            this.StSecName = new System.Windows.Forms.TextBox();
            this.StPos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Должность:";
            // 
            // StChange
            // 
            this.StChange.Location = new System.Drawing.Point(12, 161);
            this.StChange.Name = "StChange";
            this.StChange.Size = new System.Drawing.Size(170, 40);
            this.StChange.TabIndex = 4;
            this.StChange.Text = "Изменить карту";
            this.StChange.UseVisualStyleBackColor = true;
            this.StChange.Click += new System.EventHandler(this.button1_Click);
            // 
            // StOk
            // 
            this.StOk.Location = new System.Drawing.Point(295, 177);
            this.StOk.Name = "StOk";
            this.StOk.Size = new System.Drawing.Size(60, 60);
            this.StOk.TabIndex = 5;
            this.StOk.Text = "ОК";
            this.StOk.UseVisualStyleBackColor = true;
            // 
            // StName
            // 
            this.StName.Location = new System.Drawing.Point(152, 9);
            this.StName.Name = "StName";
            this.StName.Size = new System.Drawing.Size(206, 26);
            this.StName.TabIndex = 6;
            // 
            // StSur
            // 
            this.StSur.Location = new System.Drawing.Point(152, 49);
            this.StSur.Name = "StSur";
            this.StSur.Size = new System.Drawing.Size(206, 26);
            this.StSur.TabIndex = 7;
            // 
            // StSecName
            // 
            this.StSecName.Location = new System.Drawing.Point(152, 89);
            this.StSecName.Name = "StSecName";
            this.StSecName.Size = new System.Drawing.Size(206, 26);
            this.StSecName.TabIndex = 8;
            // 
            // StPos
            // 
            this.StPos.Location = new System.Drawing.Point(152, 129);
            this.StPos.Name = "StPos";
            this.StPos.Size = new System.Drawing.Size(206, 26);
            this.StPos.TabIndex = 9;
            // 
            // addUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 244);
            this.Controls.Add(this.StPos);
            this.Controls.Add(this.StSecName);
            this.Controls.Add(this.StSur);
            this.Controls.Add(this.StName);
            this.Controls.Add(this.StOk);
            this.Controls.Add(this.StChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addUserForm";
            this.Text = "addUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StChange;
        private System.Windows.Forms.Button StOk;
        private System.Windows.Forms.TextBox StName;
        private System.Windows.Forms.TextBox StSur;
        private System.Windows.Forms.TextBox StSecName;
        private System.Windows.Forms.TextBox StPos;
    }
}