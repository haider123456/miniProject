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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand exe = new SqlCommand("INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) values('" + Convert.ToInt32(cmbRubricId.SelectedValue) + "','" + txtDetail.Text + "','" + Convert.ToInt32(cmbSelctMeausrementLvl.SelectedItem) + "')", con);
            exe.ExecuteNonQuery();
            MessageBox.Show("Added!");
            Form21 form = new Form21();
            this.Hide();
            form.Show();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Id FROM Rubric", con);
            SqlDataReader read;

            read = com.ExecuteReader();


            DataTable Table = new DataTable();


            Table.Columns.Add("Id", typeof(string));
            Table.Load(read);


            cmbRubricId.ValueMember = "Id";
            cmbRubricId.DisplayMember = "Id";
            cmbRubricId.DataSource = Table;


            cmbRubricId.Text = "Select";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form16 form = new Form16();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
