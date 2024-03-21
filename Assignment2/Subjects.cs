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

namespace Assignment2
{
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
            Display();
        }

        //Reset button
        int Key = 0;
        private void Reset()
        {
            textBox_subject.Text = "";
            Key = 0;
        }

        //Displaying subjects
        private void Display()
        {
            Con.Open();
            String query = "select * from SubjectTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            Con.Close();
        }

        //Sql connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");

        //Save button
        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_subject.Text == "")
            {
                MessageBox.Show("Missing Subject");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SubjectTable (Subject) values (@Sb)", Con);
                    cmd.Parameters.AddWithValue("@Sb", textBox_subject.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject Added");
                    Con.Close();
                    Reset();
                    Display();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        //Reset button
        private void button_reset_Click(object sender, EventArgs e)
        {
            Reset();    
        }

        //Navigation buttons
        private void label7_Click(object sender, EventArgs e)
        {
            Student Stu = new Student();
            Stu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student Stu = new Student();
            Stu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Questions Que = new Questions();
            Que.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Questions Que = new Questions();
            Que.Show();
            this.Hide();
        }

        private void Subjects_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Results rs = new Results();
            rs.Show();
            this.Hide();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }
    }
}
