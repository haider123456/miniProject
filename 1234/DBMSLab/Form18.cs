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
    public partial class Form18 : Form
    {
        public Form18()
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
            Form17 form = new Form17();

            this.Hide();


            form.Show();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand execute = new SqlCommand("select * from Assessment", connection);




            SqlDataAdapter data = new SqlDataAdapter(execute);



            DataTable gridview = new DataTable(execute.ToString());

            data.Fill(gridview);



            dbGrid1.DataSource = gridview;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            if (e.ColumnIndex == dbGrid1.Columns["del"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dbGrid1.Rows[row].Cells["Id"].Value);
                SqlCommand exe = new SqlCommand("DELETE FROM Assessment WHERE Id = '" + sel + "'", con);
                exe.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                this.Hide();
                Form18 form = new Form18();
                form.Show();
            }
            if (e.ColumnIndex == dbGrid1.Columns["edit"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dbGrid1.Rows[row].Cells["Id"].Value);

                this.Hide();
                Form22 form = new Form22(sel);
                form.Show();
            }

        }
    }
}
