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

namespace Crud
{
    public partial class Crud : Form
    {
        public Crud()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=mytestDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into usertable values (@id,@name,@age)", con); 
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=mytestDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("update usertable set name=@name, age=@age, id=@id ", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=mytestDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete usertable where id=@id ", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JAYED;Initial Catalog=mytestDB;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from usertable ", con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
