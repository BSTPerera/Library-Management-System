using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAssignment.Forms
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            try
            {
                string connectionstring = "Data Source=ASUSTUF\\MSSQLSERVER01;Initial Catalog=Library;Integrated Security=True; Encrypt=False";
                SqlConnection connection = new SqlConnection(connectionstring);

                connection.Open();

                using SqlCommand command = new SqlCommand("SELECT * FROM Books", connection);
                SqlDataAdapter view = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                view.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Databse error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Dashboard frm = new Dashboard();
            frm.ShowDialog();
            this.Hide();
        }
    }
}
