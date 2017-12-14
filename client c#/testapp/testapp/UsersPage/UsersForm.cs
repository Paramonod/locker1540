using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using testapp.BL;

namespace testapp.UsersPage
{
    public interface IUsersForm
    {
        string name { set; }
        string surname { set; }
        string secName { set; }
        string pos { set; }
        string num { set; }
        event EventHandler addUser;
        event EventHandler changeUser;
    }
    public partial class UsersForm : Form, IUsersForm

    {
        private IAddUser UserOk;
        private addUserForm addUserForm1;
        private string numstr;

        public UsersForm()
        {
            InitializeComponent();
            authTest get = new authTest();
            IAuth DB = get;
            List<List<string>> allusers =  get.GetDB();
            for (int i = 0; i < allusers.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(allusers[i][0]);
                for (int j = 1; j < allusers[i].Count; j++)
                {
                    lvi.SubItems.Add(allusers[i][j]);
                }
                listView1.Items.Add(lvi);
            }
            AddUserBtn.Click += AddUserBtn_Click;
            ChangeBtn.Click += ChangeBtn_Click;
            //listView1.ColumnClick += ListView1_ColumnClick;
            listView1.ItemSelectionChanged += ListView1_ColumnClick;
        }

        private void ListView1_ColumnClick(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string name = listView1.SelectedItems[0].SubItems[0].Text;
                string surname = listView1.SelectedItems[0].SubItems[1].Text;
                string SecName = listView1.SelectedItems[0].SubItems[2].Text;
                string pos = listView1.SelectedItems[0].SubItems[3].Text;
                string num = listView1.SelectedItems[0].SubItems[4].Text;
                string id = listView1.SelectedItems[0].SubItems[5].Text;
                NameT.Text = name;
                SurnT.Text = surname;
                SecNameT.Text = SecName;
                PosT.Text = pos;
                NumT.Text = num;
                idT.Text = id;
            } else
            {
                NameT.Text = "";
                SurnT.Text = "";
                SecNameT.Text = "";
                PosT.Text = "";
                NumT.Text = "";
                idT.Text = "";
            }
        }
        #region allneed
        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            addUserForm1 = new addUserForm();
            string name = listView1.SelectedItems[0].SubItems[0].Text;
            string surname = listView1.SelectedItems[0].SubItems[1].Text;
            string SecName = listView1.SelectedItems[0].SubItems[2].Text;
            string pos = listView1.SelectedItems[0].SubItems[3].Text;
            string id = listView1.SelectedItems[0].SubItems[4].Text;
            addUserForm1.init(name, surname, SecName, pos, id);
            addUserForm1.OK += AddUserForm1_OK1;
            //addUserForm1.Change += AddUserForm1_Change;
            //addUserForm1.StName.Text;
            addUserForm1.Show();
           
        }

        private void AddUserForm1_OK(object sender, EventArgs e)
        {
            string _name = UserOk.name;
            string _surname = UserOk.surname;
            string _secName = UserOk.secName;
            string _pos = UserOk.pos;
            string _card = UserOk.numstr;
            addUserForm1.Close();
            authTest addC = new authTest();
            IAuth addCard = addC;
            addCard.addCard(_card, _name, _surname, _secName, _pos);
            listView1.Items.Clear();
            authTest get = new authTest();
            IAuth DB = get;
            List<List<string>> allusers = get.GetDB();
            for (int i = 0; i < allusers.Count-1; i++)
            {
                ListViewItem lvi = new ListViewItem(allusers[i][0]);
                for (int j = 1; j < allusers[i].Count; j++)
                {
                    lvi.SubItems.Add(allusers[i][j]);
                }
                listView1.Items.Add(lvi);
            }

        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            addUserForm1 = new addUserForm();
            /*string name = listView1.SelectedItems[0].SubItems[0].Text;
            string surname = listView1.SelectedItems[0].SubItems[1].Text;
            string SecName = listView1.SelectedItems[0].SubItems[2].Text;
            string pos = listView1.SelectedItems[0].SubItems[3].Text;
            addUserForm1.init(name, surname, SecName, pos);*/
            UserOk = addUserForm1;
            addUserForm1.OK += AddUserForm1_OK;
            //addUserForm1.Change += AddUserForm1_Change;
            addUserForm1.Show();
            
        }

        private void AddUserForm1_OK1(object sender, EventArgs e)
        {
            string _name = UserOk.name;
            string _surname = UserOk.surname;
            string _secName = UserOk.secName;
            string _pos = UserOk.pos;
            string _card = UserOk.numstr;
            string _id = UserOk.id;
            addUserForm1.Close();
            authTest addC = new authTest();
            IAuth addCard = addC;
            addCard.changeCard(_id,_card, _name, _surname, _secName, _pos);
            UserOk = addUserForm1;
            listView1.Clear();
            authTest get = new authTest();
            IAuth DB = get;
            List<List<string>> allusers = get.GetDB();
            for (int i = 0; i < allusers.Count; i++)
            {
                ListViewItem lvi1 = new ListViewItem(allusers[i][0]);
                for (int j = 1; j < allusers[i].Count; j++)
                {
                    lvi1.SubItems.Add(allusers[i][j]);
                }
                listView1.Items.Add(lvi1);
            }
            addUserForm1.Close();

        }

        public string name
        {
            set { NameT.Text = value; }
        }
        public string surname
        {
            set { SurnT.Text = value; }
        }
        public string secName
        {
            set { SecNameT.Text = value; }
        }
        public string pos
        {
            set { PosT.Text = value; }
        }
        public string num
        {
            set { NumT.Text = value; }
        }
        public event EventHandler addUser;
        public event EventHandler changeUser;
        #endregion
        #region notNeed
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
#endregion
}
