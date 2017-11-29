namespace testapp.UsersPage
{
    partial class addCardForm
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
            this.NeedT = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NeedT
            // 
            this.NeedT.AutoSize = true;
            this.NeedT.Location = new System.Drawing.Point(101, 60);
            this.NeedT.Name = "NeedT";
            this.NeedT.Size = new System.Drawing.Size(98, 20);
            this.NeedT.TabIndex = 0;
            this.NeedT.Text = "Жду карту...";
            this.NeedT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NeedT.Click += new System.EventHandler(this.label1_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(100, 100);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // addCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 144);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.NeedT);
            this.Name = "addCardForm";
            this.Text = "addCardForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NeedT;
        private System.Windows.Forms.Button CloseButton;
    }
}