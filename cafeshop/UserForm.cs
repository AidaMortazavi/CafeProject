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
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-GMDGTVP\SQL2019;Initial Catalog=cafedb;Integrated Security=True");
        void populate()
        {
            Con.Open();
            string query = "select * from UsersTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet("UsersTb1");
            sda.Fill(ds);
            UsersGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder OrderF = new UserOrder();
            OrderF.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm ItemF = new ItemsForm();
            ItemF.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into UsersTb1 values ('" + UNameTb.Text + "' , '" + UPhoneTb.Text + "' , '" + UPasswordTb.Text + "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully Created");
            Con.Close();
            populate();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //UNameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
           // UPhoneTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            //UPasswordTb.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UPhoneTb.Text == "")
            {

                MessageBox.Show("Select The User Tobe Deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from UsersTb1 where UPhone= ( '" + UPhoneTb.Text + "'  )";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                Con.Close();
                populate();
            }
        }
    }
}
