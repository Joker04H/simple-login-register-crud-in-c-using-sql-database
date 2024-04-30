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

namespace testlogin
{
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            string query = "SELECT COUNT(*) FROM crudtable2 WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@username",txt_username.Text);
            cmd.Parameters.AddWithValue("@password", txt_userpassword.Text);
            int count= (int)cmd.ExecuteScalar();
            conn.Close();

            if(count > 0)
            {
                MessageBox.Show("login Success","info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                Crudtest form2 = new Crudtest();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error In login");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testregister form3 = new testregister();
            form3.Show();
            this.Hide();
        }
    }
}
