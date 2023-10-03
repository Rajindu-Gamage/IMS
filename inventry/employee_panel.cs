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
    public partial class employee_panel : Form
    {

        public employee_panel()
        {
            InitializeComponent();
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form5_checkin_inventry());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form6_checkout_inventry());
        }

        private void employee_panel_Load(object sender, EventArgs e)
        {
            string Connectionstring = "Data Source=LAPTOP-3U7D7BCS\\SQLEXPRESS;Initial Catalog=inventry;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1_registration form1_Registration = new Form1_registration();
            form1_Registration.Show();
            this.Hide();
        }
    }
}
