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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO Assessment(Title,DateCreated,TotalMarks,TotalWeightage) values('" + txttitle.Text + "','" + DateTime.Now + "','" + Convert.ToInt32(txtTotalMarks.Text) + "','" + Convert.ToInt32(txtwieght.Text) + "')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            
            Form17 frm = new Form17();
            this.Hide();
            frm.Show();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form1 form = new Form1();

            this.Hide();


            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form18 form4 = new Form18();

            this.Hide();


            form4.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalMarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtwieght_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txttitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
