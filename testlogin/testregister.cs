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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

namespace testlogin
{
    public partial class testregister : Form
    {
        public testregister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            if (pass.Text == cpassword.Text && id.Text != "" && name.Text != "" && age.Text != "" && pass.Text != "" && cpassword.Text != "" && gender.Text != "" && phone.Text != "" ) 
                
            { 
            

            SqlCommand cmd = new SqlCommand("insert into crudtable2 values (@username,@name,@age,@password,@gender,@phone)", con);
                cmd.Parameters.AddWithValue("@username", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(age.Text));
                cmd.Parameters.AddWithValue("@password", pass.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);

                cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Registered");
            Login1 form1 = new Login1();
            form1.Show();
            this.Hide();
        }
            else
            {
                MessageBox.Show("Password Did Not Match or Missing some data ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
