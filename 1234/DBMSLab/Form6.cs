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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Name,Id FROM Clo", con);
            SqlDataReader read;

            read = com.ExecuteReader();


            DataTable Table = new DataTable();
            Table.Columns.Add("Name", typeof(string));


            Table.Columns.Add("Id", typeof(string));
            Table.Load(read);


            clocmb.ValueMember = "Id";
            clocmb.DisplayMember = "Name";
            clocmb.DataSource = Table;


            clocmb.Text = "Select";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 form7 = new Form7();
            this.Hide();
            form7.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();


            this.Hide();

            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand execute = new SqlCommand("INSERT INTO Rubric(Details,CloId) values('" + CloDetails.Text + "','" + clocmb.SelectedValue + "')", con);
            execute.ExecuteNonQuery();
            MessageBox.Show("Added successfully!");
           


            Form7 frm7 = new Form7();
            this.Hide();
            frm7.Show();
        }

        private void clocmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
