using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventry
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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
            panel_main_middle.Controls.Add(childForm);
            panel_main_middle.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void bt_home_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3_home());
        }

        private void bt_addmember_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4_addmember());
        }

        private void bt_checkin_Click(object sender, EventArgs e)
        {
            openChildForm(new Form5_checkin_inventry());
        }

        private void bt_checkout_Click(object sender, EventArgs e)
        {
            openChildForm(new Form6_checkout_inventry());
        }

        private void panel_main_middle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashbord_Load(object sender, EventArgs e)
        {

        }

        private void bt_stock_Click(object sender, EventArgs e)
        {
            openChildForm(new stock());
        }

        private void bt_logout_Click(object sender, EventArgs e)
        {
            Form1_registration form1_Registration = new Form1_registration();
            form1_Registration.Show();
            this.Hide();
        }
    }
}
