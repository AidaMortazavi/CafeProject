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
    public partial class UserOrder : Form
    {
        public UserOrder()
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
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm Items = new ItemsForm();
            Items.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserForm userF = new UserForm();
            userF.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int num = 0;
        string price, qty, total;
        string item, cat;

        private void UserOrder_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void ItemsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name= ItemsGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            cat= ItemsGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            price = ItemsGV.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
    }
}
