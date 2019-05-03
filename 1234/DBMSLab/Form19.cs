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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form1 form = new Form1();

            this.Hide();


            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form20 form = new Form20();

            this.Hide();


            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) values('" + txtname.Text + "','" + txtrubricId.Text.ToString() + "','" + txtTotalMarks.Text + "','" + DateTime.Now + "','" + DateTime.Now + "','" +cmbassessmentId.Text.ToString() + "')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            
            Form19 frm = new Form19();
            this.Hide();
            frm.Show();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Details,Id FROM Rubric", con);
            SqlDataReader r;

            r = com.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Columns.Add("Id", typeof(string));
            Table.Load(r);
            txtrubricId.ValueMember = "Id";
            txtrubricId.DisplayMember = "Id";
            txtrubricId.DataSource = Table;
            txtrubricId.Text = "Select";


            r.Close();

            SqlCommand com2 = new SqlCommand("SELECT Title,Id FROM Assessment", con);
            SqlDataReader r2;

            r2 = com.ExecuteReader();
            DataTable Table2 = new DataTable();
            Table2.Columns.Add("Details", typeof(string));
            Table2.Columns.Add("Id", typeof(string));
            Table2.Load(r2);
            cmbassessmentId.ValueMember = "Id";
            cmbassessmentId.DisplayMember = "Id";
            cmbassessmentId.DataSource = Table2;
            txtrubricId.Text = "Select";
        }
    }
}
