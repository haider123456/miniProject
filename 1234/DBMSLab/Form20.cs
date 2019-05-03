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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form20_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand execute = new SqlCommand("select * from AssessmentComponent", connection);




            SqlDataAdapter data = new SqlDataAdapter(execute);



            DataTable gridview = new DataTable(execute.ToString());

            data.Fill(gridview);



            dbGrid1.DataSource = gridview;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            Form19 form = new Form19();
            this.Hide();
            form.Show();
        }

        private void dbGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            if (e.ColumnIndex == dbGrid1.Columns["del"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dbGrid1.Rows[row].Cells["Id"].Value);
                SqlCommand exe = new SqlCommand("DELETE FROM AssessmentComponent WHERE Id = '" + sel + "'", con);
                exe.ExecuteNonQuery();
                MessageBox.Show("Deleted!");

                Form20 form = new Form20();
                this.Hide();
                form.Show();
            }
            if (e.ColumnIndex == dbGrid1.Columns["btnEdit"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dbGrid1.Rows[row].Cells["Id"].Value);

                this.Hide();
                Form23 form = new Form23(sel);
                form.Show();
            }
        }
    }
}
