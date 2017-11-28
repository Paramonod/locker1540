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
        string name { get; }
        string surname { get; }
        string secName { get; }
        string pos { get; }
        string num { get; }
    }
    public partial class addUserForm : Form,IAddUser
    {
        private string name1 = "";
        private string surname1 = "";
        private string SecName1 = "";
        private string pos1 = "";
        object ctx;
        public void con(object ctx1)
        {
            ctx = ctx1;
        }
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
            /*ListViewItem lvi = new ListViewItem(StName.Text);
            lvi.SubItems.Add(StSur.Text);
            lvi.SubItems.Add(StSecName.Text);
            lvi.SubItems.Add(StPos.Text);
            lvi.SubItems.Add("123450");
            
            Close();*/
            OK?.Invoke(this, EventArgs.Empty);
        }

        private void StChange_Click(object sender, EventArgs e)
        {
            MessageService service = new MessageService();
            StSecName.Text = SecName1;
            service.ShowMessage("Жду карту");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
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
        public string num
        {
            get { return "12345"; }
        }
        public event EventHandler OK;
    }
}
