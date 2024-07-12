using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cafeshop
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GMDGTVP\SQL2019;Initial Catalog=cafedb;Integrated Security=True");
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder uOrder = new UserOrder();
            uOrder.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm itemF = new ItemsForm();
            itemF.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into UsersTb1 values ('" +uNameTb.Text+"' , '" +uPhoneTb.Text+"' , '"+UPasswordTb.Text+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created");
            con.Close();
        }
    }
}
