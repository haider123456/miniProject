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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public Form10(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form7 frm = new Form7();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            
            SqlCommand exe = new SqlCommand("UPDATE dbo.Rubric SET Details = '" + CloDetails.Text + "' WHERE Id = '" + ID + "' ", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");
           
            Form7 frm = new Form7();
            this.Hide();
            frm.Show();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            

        }
    }
}
