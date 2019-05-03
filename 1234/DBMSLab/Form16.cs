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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";
        private void Form16_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand execute = new SqlCommand("select * from RubricLevel", connection);




            SqlDataAdapter data = new SqlDataAdapter(execute);



            DataTable gridview = new DataTable(execute.ToString());

            data.Fill(gridview);



            dataGridView1.DataSource = gridview;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form21 form = new Form21();
            this.Hide();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            if (e.ColumnIndex == dataGridView1.Columns["btndel"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                SqlCommand exe = new SqlCommand("DELETE FROM RubricLevel WHERE Id = '" + sel + "'", con);
                exe.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                this.Hide();
                Form16 form = new Form16();
                form.Show();
            }
            if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index)
            {
                int row = e.RowIndex;
                int sel = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);

                this.Hide();
                Form15 form = new Form15(sel);
                form.Show();
            }
        }
    }
}
