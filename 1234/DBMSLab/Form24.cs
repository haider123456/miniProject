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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form24_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Id FROM student", con);
            SqlDataReader read;

            read = com.ExecuteReader();


            DataTable Table = new DataTable();


            Table.Columns.Add("Id", typeof(string));
            Table.Load(read);


            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Id";
            comboBox1.DataSource = Table;


            comboBox1.Text = "Select";


             SqlConnection connn = new SqlConnection(ConnectionString);
            connn.Open();
            SqlCommand comm = new SqlCommand("SELECT Id FROM AssessmentComponent", connn);
            SqlDataReader r;

            r = comm.ExecuteReader();


            DataTable T = new DataTable();


            T.Columns.Add("Id", typeof(string));
            T.Load(r);


            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Id";
            comboBox2.DataSource = T;


            comboBox2.Text = "Select";

            SqlConnection connnn = new SqlConnection(ConnectionString);
            connnn.Open();
            SqlCommand commm = new SqlCommand("SELECT Id FROM AssessmentComponent", connnn);
            SqlDataReader rr;

            rr = commm.ExecuteReader();


            DataTable Tbl = new DataTable();


            Tbl.Columns.Add("Id", typeof(string));
            Tbl.Load(rr);


            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Id";
            comboBox3.DataSource = Tbl;


            comboBox3.Text = "Select";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) values('" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added!");

            Form24 frm5 = new Form24();
            this.Hide();
            frm5.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm5 = new Form1();
            this.Hide();
            frm5.Show();
        }
    }
}
