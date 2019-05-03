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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }
        public int ID;
        public Form23(int id)
        {
            ID = id;
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form23_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Details,Id FROM Rubric", con);
            SqlDataReader r;

            r = com.ExecuteReader();
            DataTable Table = new DataTable();
            Table.Columns.Add("Details", typeof(string));
            Table.Columns.Add("Id", typeof(string));
            Table.Load(r);
            txtrubricId.ValueMember = "Id";
            txtrubricId.DisplayMember = "Details";
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
            cmbassessmentId.DisplayMember = "Details";
            cmbassessmentId.DataSource = Table2;
            txtrubricId.Text = "Select";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();



            SqlCommand exe = new SqlCommand("UPDATE AssessmentComponent SET Name = '" + txtname.Text.ToString() + "', RubricId = '" + txtrubricId.Text.ToString() + "', TotalMarks = '" + txtTotalMarks.Text.ToString() + "',AssessmentId='"+cmbassessmentId.Text.ToString()+"' WHERE Id = '" + ID + "' ", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");

            Form19 frm = new Form19();
            this.Hide();
            frm.Show();
        }
    }
}
