using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testapp
{
    public interface IMainForm
    {
        string login { get; }
        string passwd { get; }
        event EventHandler auth;
    }
    public partial class Form1 : Form, IMainForm
    {
        public Form1()
        {
            InitializeComponent();
            authBtn.Click += AuthBtn_Click;
        }

        private void AuthBtn_Click(object sender, EventArgs e)
        {
            if (auth != null) auth(this, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public string login
        {
            get { return loginBox.Text; }
        }

        public string passwd
        {
            get { return passwordBox.Text; }
        }
        public event EventHandler auth;
    }
}
