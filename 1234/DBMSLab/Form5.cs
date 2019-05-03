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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public string ConnectionString = "Data Source=HAIER-PC;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            
                SqlCommand exe = new SqlCommand("SELECT * FROM Clo", con);

                SqlDataAdapter data = new SqlDataAdapter(exe);



                DataTable gridview = new DataTable(exe.ToString());

                data.Fill(gridview);
                dataGridView1.DataSource = gridview;
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 form4 = new Form4();

            this.Hide();


            form4.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            if (e.ColumnIndex == dataGridView1.Columns["del"].Index)
            {
                int selling = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[selling].Cells["Id"].Value);


                SqlCommand exe = new SqlCommand("DELETE FROM Clo WHERE Id = '" + id + "'", con);



                exe.ExecuteNonQuery();

                MessageBox.Show("Deleted successfully!");
                this.Hide();


                Form5 form5 = new Form5();

                form5.Show();
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index)
            {
                int selling = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[selling].Cells["Id"].Value);

                
                this.Hide();


                Form9 form9 = new Form9(id);

                form9.Show();
            }
        }
    }
}
