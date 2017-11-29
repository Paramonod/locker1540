using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using testapp.BL;

namespace testapp.UsersPage
{
    public interface IAddCard
    {
        byte[] Card { get; }
        string label { set; }
    }
    public partial class addCardForm : Form, IAddCard
    {
        public addCardForm()
        {
            InitializeComponent();
            CloseButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string label
        {
            set { NeedT.Text = value; }
        }
        public byte[] Card
        {
            get
            {
                ComReader _reader = new ComReader();
                IReader reader = _reader;
                return  reader.readFrom("COM3");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
