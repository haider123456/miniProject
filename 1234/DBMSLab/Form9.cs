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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public Form9(int id)
        {
            ID = id;
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();


            

            SqlCommand exe = new SqlCommand("UPDATE dbo.Clo SET Name = '" + cloName.Text + "', DateCreated = '" + Convert.ToDateTime(cloCreatedDateTIme.Text) + "', DateUpdated = '" + Convert.ToDateTime(cloCreatedDateTIme.Text) + "' WHERE Id = '"+ID+"' ", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");
           
            Form5 frm = new Form5();
            this.Hide();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form5 frm = new Form5();
            frm.Show();
        }
    }
}
