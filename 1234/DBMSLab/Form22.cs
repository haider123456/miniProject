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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }
        public int ID;
        public Form22(int id)
        {
            ID = id;
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form22_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();



            
            SqlCommand exe = new SqlCommand("UPDATE Assessment SET Title = '" + txttitle.Text.ToString() + "', TotalMarks = '" + txtTotalMarks.Text.ToString() + "', TotalWeightage = '" + txtwieght.Text.ToString() + "' WHERE Id = '" + ID + "' ", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");

            Form17 frm = new Form17();
            this.Hide();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
