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

namespace testlogin
{
    public partial class Crudtest : Form
    {
        public Crudtest()
        {
            InitializeComponent();
        }
        //INSERT
        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            if (id.Text != "" && name.Text != "" && age.Text != "" && pass.Text != "" && gender.Text != "" && phone.Text != "")
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
                MessageBox.Show("Successfully Saved");
                id.Clear();
                name.Clear();
                gender.Clear();
                phone.Clear();
                age.Clear();
                pass.Clear();
            }
            else
            {
                MessageBox.Show("Some Field may have not been filled");
            }
        }
        //UPDATE
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            if (id.Text != "" && name.Text != "" && age.Text != "" && pass.Text != "" && gender.Text != "" && phone.Text != "")
            {
                SqlCommand cmd = new SqlCommand("update crudtable2  set name=@name, age=@age, password=@password , gender=@gender, phone=@phone where username=@username ", con);
                cmd.Parameters.AddWithValue("@username", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@age", int.Parse(age.Text));
                cmd.Parameters.AddWithValue("@password", pass.Text);
                cmd.Parameters.AddWithValue("@gender", gender.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated");
                id.Clear();
                name.Clear();
                gender.Clear();
                phone.Clear();
                age.Clear();
                pass.Clear();
            }
            else
            {
                MessageBox.Show("Some Field may have not been filled");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        //DELETE
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            
                SqlCommand cmd = new SqlCommand("delete crudtable2 where username=@username ", con);
                cmd.Parameters.AddWithValue("@username", id.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted");
                id.Clear();
                name.Clear();
                gender.Clear();
                phone.Clear();
                age.Clear();
                pass.Clear();
            }
            
        
        //SEARCH
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from crudtable2 ", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Crudtest_Load(object sender, EventArgs e)
        {

        }
    }
}
