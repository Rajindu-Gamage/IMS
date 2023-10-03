using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inventry
{
    public partial class Form3_home : Form
    {
        public Form3_home()
        {
            InitializeComponent();
        }

        private void Form3_home_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "select * from Tb_checkout_inventry";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                dataGridView2.Rows.Add(reader["Item_Code"], reader["Item_Name"], reader["Number_of_Box"], reader["Quantity"]);
            }

            /*DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;*/
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "select * from Tb_checkin_inventry";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Item_Code"], reader["Item_Name"], reader["Number_of_Box"], reader["Quantity"]);
            }

            /*DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;*/
            con.Close();
        }
    }
}
