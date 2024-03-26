using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace MyAssignment.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBooks viewBooks = new ViewBooks();
            viewBooks.ShowDialog();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ManageBooks manageBooks = new ManageBooks();
            manageBooks.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transactions transactions = new Transactions();
            transactions.ShowDialog();
        }
    }
}
