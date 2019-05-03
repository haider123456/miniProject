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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string connectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            
            
                int status=0;
                if (sStatus.Text == "Inactive")
                {
                    status = 6;
                }
                else
                {
                    status = 5;
                }

            
                SqlCommand execute = new SqlCommand("INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values('"+sfName.Text+"','" + slName.Text + "','" + sContact.Text + "','" + sEmail.Text + "','" + sRegNo.Text + "','" + status + "')", con);
                execute.ExecuteNonQuery();

                MessageBox.Show("student Data Inserted Successfully!");
                
                Form3 frm = new Form3();
            this.Hide();
            frm.Show();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void First_TextChanged(object sender, EventArgs e)
        {

        }

        private void Last_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
