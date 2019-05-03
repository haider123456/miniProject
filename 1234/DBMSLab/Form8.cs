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

namespace DBMSLab
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public Form8(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();


            int status = 0;
            if (scmb.Text == "Inactive")
            {
                status = 6;
            }
            else if (scmb.Text == "Active")
            {
                status = 5;
            }


            SqlCommand exe = new SqlCommand("UPDATE Student set FirstName = '" + sfName.Text + "', LastName = '" + slName.Text + "',Contact = '" + sContact.Text + "',Email = '" + sEmail.Text + "',RegistrationNumber='" + sRegNo.Text + "',Status = '" + status + "' where Id = '"+ID+"'", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");
            
            Form3 frm = new Form3();
            this.Hide();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
