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
    public partial class Form6_checkout_inventry : Form
    {
        public Form6_checkout_inventry()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "select * from Tb_checkout_inventry";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            
            while(reader.Read())
            {
                dataGridView1.Rows.Add(reader["Item_Code"], reader["Item_Name"], reader["Number_of_Box"], reader["Quantity"]);
            }
         
            /*DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();*/

        }

        private void Form6_checkout_inventry_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        private void BindDataGridView()
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "SELECT * FROM [View_Tb_checkout];";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertDataIntoDatabase();

            /*string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();

            string Item_Code = textBox1.Text;
            string Item_Name = textBox2.Text;
            string Number_of_box = textBox3.Text;
            string Quantity = textBox4.Text;
            string Query = "insert into Tb_checkout_inventry(Item_Code, Item_Name, Number_of_box, Quantity) values('" + Item_Code + "', '" + Item_Name + "', '" + Number_of_box + "', '" + Quantity + "' );";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been saved");*/

        }
        private void InsertDataIntoDatabase()
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            using (SqlCommand command = new SqlCommand("AddProduct_check_out", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                
                command.Parameters.AddWithValue("@Item_Code", textBox1.Text);
                command.Parameters.AddWithValue("@Item_Name", textBox2.Text);
                command.Parameters.AddWithValue("@Number_of_Box", textBox3.Text);
                command.Parameters.AddWithValue("@Quantity", textBox4.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Data has been saved");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            
            

            string Item_Code = textBox1.Text;
            string Item_Name = textBox2.Text;
            string Number_of_box = textBox3.Text;
            string Quantity = textBox4.Text;
            string Query = "Update Tb_checkout_inventry set Item_Name = '"+Item_Name+"' , Number_of_Box = '"+Number_of_box+"' , Quantity = '"+Quantity+"' where Item_Code = '"+Item_Code+"';";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been Updated");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();



            string Item_Code = textBox1.Text;
            string Item_Name = textBox2.Text;
            string Number_of_box = textBox3.Text;
            string Quantity = textBox4.Text;
            string Query = "select * from Tb_stock where Item_Code = '" + Item_Code+"'";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            
            if(reader.Read())
            {
                textBox1.Text = reader["Item_Code"].ToString();
                textBox2.Text = reader["Item_Name"].ToString();
                textBox3.Text = reader["Number_of_Box"].ToString();
                textBox4.Text = reader["Quantity"].ToString();
            }
            else
            {
                MessageBox.Show("NO recoard found");
            }

            con.Close();
            

        }
    }
}
