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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        public int ID;
        public Form15(int id)
        {
            ID = id;
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form15_Load(object sender, EventArgs e)
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

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();



            
            SqlCommand exe = new SqlCommand("UPDATE RubricLevel SET RubricId = '" + cmbRubricId.Text.ToString() + "', MeasurementLevel = '" + cmbSelctMeausrementLvl.Text.ToString() + "', Details = '" +txtDetail.Text.ToString() + "' WHERE Id = '" + ID + "' ", con);
            exe.ExecuteNonQuery();

            MessageBox.Show("Edit Successfully!");

            Form21 frm = new Form21();
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
