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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string connectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            
            SqlCommand execute = new SqlCommand("select * from Student where Status = '" + 5 + "'", connection);




            SqlDataAdapter data = new SqlDataAdapter(execute);



            DataTable gridview = new DataTable(execute.ToString());

            data.Fill(gridview);



            dataGridView1.DataSource = gridview;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            if (e.ColumnIndex == dataGridView1.Columns["del"].Index)
            {
                
                    int rownum = e.RowIndex;
                    int sel = Convert.ToInt32(dataGridView1.Rows[rownum].Cells["Id"].Value);
                    SqlCommand exe = new SqlCommand("DELETE FROM Student WHERE Id = '" + sel + "'", con);
                    exe.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.Show();

            }
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index)
            {

                int rownumber = e.RowIndex;
                int selling = Convert.ToInt32(dataGridView1.Rows[rownumber].Cells["Id"].Value);
                
                this.Hide();



                Form8 form8 = new Form8(selling);



                form8.Show();

            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
