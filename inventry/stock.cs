using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventry
{
    public partial class stock : Form
    {
        
        public stock()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "select * from Tb_stock";
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

        private void stock_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        private void BindDataGridView()
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "SELECT * FROM [View_Tb_totalstock];";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
