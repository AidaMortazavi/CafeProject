using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;



namespace cafeshop
{
    public partial class UserForm : Form

    {

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
        public UserForm()
        {
            InitializeComponent();
           
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
            string query = "insert into UsersTb1 values ('" + txt_Name.Text + "' , '" + txt_Phone.Text + "' , '" + txt_Pass.Text + "')";
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
        
            txt_Name.Text = UsersGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Phone.Text = UsersGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Pass.Text = UsersGV.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void  UsersGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_Phone.Text == "")
            {
                MessageBox.Show("Select The User Tobe Deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from UsersTb1 where Uphone= '" + txt_Phone.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_Phone.Text ==""||txt_Pass.Text ==""|| txt_Name.Text=="")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                Con.Open();
                string query = "update UsersTb1 set Uname='"+txt_Name.Text+"', Upass='"+txt_Pass.Text+ "'where Uphone='"+txt_Phone.Text+"'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");
                Con.Close();
                populate();
            }
        }
    }
}
