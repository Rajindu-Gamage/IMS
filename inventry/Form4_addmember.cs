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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace inventry
{
    public partial class Form4_addmember : Form

    {
        string Gender;
        public Form4_addmember()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();

            string User_Id = textBox1.Text;
            string First_Name = textBox2.Text;
            string Second_Name = textBox3.Text;
            string Username = textBox4.Text;
            string Password = textBox5.Text;
            string Query = "insert into Tb_add_member ( User_Id, First_Name, Second_Name, Gender, Username, Password)" +
                " values('"+ User_Id + "','"+ First_Name + "','"+ Second_Name + "','"+Gender+"','"+ Username + "','"+ Password + "');";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Member has been ADD");
        }

        private void Form4_addmember_Load(object sender, EventArgs e)
        {
            BindDataGridView();
        }
        private void BindDataGridView()
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "SELECT * FROM [View_Tb_member];";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string Query = "SELECT * FROM [View_Tb_checkout];";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            dataGridView1.DataBind();

            /*var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["User_Id"], reader["First_Name"], reader["Second_Name"], reader["Gender"], reader["Username"], reader["Password"]);
            }

            /*DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();



            string User_Id = textBox1.Text;
            string First_Name = textBox2.Text;
            string Second_Name = textBox3.Text;
            string Username = textBox4.Text;
            string Password = textBox5.Text;
            string Query = "Update Tb_add_member set User_Id = '" + User_Id + "' , First_Name = '" + First_Name + "' , Second_Name = '" + Second_Name + "', Username = '"+Username+ "', Password = '" + Password + "' where User_Id = '" + User_Id + "';";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been Updated");

        }
    }
}
