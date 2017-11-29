using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testapp.UsersPage
{
    public interface IAddUser
    {
        event EventHandler OK;
        //event EventHandler Change;
        string name { get; }
        string surname { get; }
        string secName { get; }
        string pos { get; }
        byte[] num { get; }
        string numstr { get; }
        string getCard();
    }
    public partial class addUserForm : Form,IAddUser
    {
        private string name1 = "";
        private string surname1 = "";
        private string SecName1 = "";
        private byte[] num1;
        private string pos1 = "";
        object ctx;
        public void init(string _name, string _surname, string _SecName, string _pos)
        {
            name1 = _name;
            surname1 = _surname;
            SecName1 = _SecName;
            pos1 = _pos;
            StName.Text = name1;
            StSur.Text = surname1;
            StSecName.Text = SecName1;
            StPos.Text = pos1;
            StChange.Click += StChange_Click;
            StOk.Click += StOk_Click;
        }
        public addUserForm()
        {
            InitializeComponent();
            StName.Text = name1;
            StSur.Text = surname1;
            StSecName.Text = SecName1;
            StPos.Text = pos1;
            StChange.Click += StChange_Click;
            StOk.Click += StOk_Click;
        }

        private void StOk_Click(object sender, EventArgs e)
        {
            OK?.Invoke(this, EventArgs.Empty);
        }

        private void StChange_Click(object sender, EventArgs e)
        {
            addCardForm addCard = new addCardForm();
            IAddCard read = addCard;
            addCard.Show();
            read.label = "Жду карту...";
            num1 = read.Card;
            read.label = numstr;
        }
        public string getCard()
        {
            addCardForm addCard = new addCardForm();
            IAddCard read = addCard;
            addCard.Show();
            return "q";
        }
        public string numstr
        {
            get
            {
                string res = "";
                for (int i = 0; i < num.Count(); i++)
                {
                    res += num[i].ToString();
                    res += " ";
                }
                return res;
            }
        }

        #region notneed
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        public string name
        {
            get { return StName.Text; }
        }
        public string surname
        {
            get { return StSur.Text; }
        }
        public string secName
        {
            get { return StSecName.Text; }
        }
        public string pos
        {
            get { return StPos.Text; }
        }
        public byte[] num
        {
            get { return num1; }
        }
        public event EventHandler OK;
        //public event EventHandler Change;
    }
}
