using MyAssignment.Classes;
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
    public partial class ManageBooks : Form
    {
        public ManageBooks()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int bookId = int.Parse(bId.Text);
                string title = bTitle.Text;
                string author = bAuthor.Text;
                int isbn = int.Parse(bIsbn.Text);
                bool availability = true;


                Book book = new Book(bookId, title, author, isbn, availability);
                Library library = new Library();
                library.AddBook(book);
            }
            catch
            {
                MessageBox.Show("Invalid Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int bookId = int.Parse(bId.Text);
                string title = bTitle.Text;

                Book book = new Book(bookId);
                Library library = new Library();
                library.RemoveBook(book);
            }
            catch
            {
                MessageBox.Show("Invalid Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
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

                bId.Text = "";
                bTitle.Text = "";
                bAuthor.Text = "";
                bIsbn.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Databse error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dashboard forum = new Dashboard();
            forum.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
