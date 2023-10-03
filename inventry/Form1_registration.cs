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
using static inventry.Form1_registration;

namespace inventry
{
    public partial class Form1_registration : Form
    {
        public Form1_registration()
        {
            InitializeComponent();
        }
       
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;

            try 
            {
                string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
                SqlConnection con = new SqlConnection(Connectionstring);
                con.Open();
                String query = "Select * from Tb_add_member where username = '"+textBox1.Text+"' and password = '"+textBox2.Text+"'";

                SqlDataAdapter sda = new SqlDataAdapter(query,con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(username=="admin" && password == "12345")
                {
                    Dashbord form1 = new Dashbord();
                    form1.Show();
                    this.Hide();
                }
                else if(dt.Rows.Count > 0 ) 
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    employee_panel employee_Panel = new employee_panel();
                    employee_Panel.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("INVALID LOGIN");
                }
            }
            catch 
            {
                MessageBox.Show("Error");
            }


        }
    }
}
