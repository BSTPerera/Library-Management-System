using MyAssignment.Forms;

namespace MyAssignment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;


            if (username.Equals("Admin") && password.Equals("1234"))
            {
                this.Hide();
                MessageBox.Show("Login Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();

            }
            else 
            { 
                MessageBox.Show("Invalid username or password. Please try again."); 
            }
        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}