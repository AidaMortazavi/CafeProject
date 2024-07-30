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
    public partial class ItemsForm : Form
    {
        public ItemsForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-GMDGTVP\SQL2019;Initial Catalog=cafedb;Integrated Security=True");
        void populate()
        {
            Con.Open();
            string query = "select * from ItemTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemsGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userItem = new UserForm();
            userItem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder orderItem =new UserOrder();
            orderItem.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_ItemNum.Text=="" || txt_ItemName.Text=="" || txt_ItemPrice.Text=="")
            {
                MessageBox.Show("Fill All The Data");
            }
            else
            {
                Con.Open();
                string query = "insert into ItemTb1 values('" +txt_ItemNum.Text+ "', '"+txt_ItemName.Text+"', '"+CatCb.SelectedItem.ToString()+"' , '"+txt_ItemPrice.Text+"') ";
                SqlCommand cmd = new SqlCommand(query ,Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item successfuly created");
                Con.Close();
                populate();
            }
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void ItemsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ItemNum.Text = ItemsGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ItemName.Text = ItemsGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            CatCb.SelectedItem = ItemsGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_ItemPrice.Text = ItemsGV.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_ItemNum.Text=="")
            {
                MessageBox.Show("Select the item to be deleted");
            }
            else
            {
                Con.Open();
                string query = "delete from ItemTb1 where ItemNum = '" + txt_ItemNum.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item successfully deleted");
                Con.Close();
                populate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txt_ItemNum.Text=="" || txt_ItemName.Text=="" || txt_ItemPrice.Text=="")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                Con.Open();
                string query = "update ItemTb1 set ItemName ='"+txt_ItemName.Text+"', ItemCat ='"+CatCb.SelectedItem.ToString()+"'where ItemPrice ='"+txt_ItemPrice.Text+"'";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item successfully updated");
                Con.Close();
                populate();
            }
        }
    }
}
