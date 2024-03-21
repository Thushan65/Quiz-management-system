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

namespace Assignment2
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            Display();
        }

        //Reset button
        private void Reset()
        {
            textBox_name.Text = "";
            textBox_age.Text = "";
            textBox_address.Text = "";
            textBox_password.Text = "";
            textBox_phone.Text = "";
        }

        //Displaying students
        private void Display()
        {
            Con.Open();
            String query = "select * from StudentsTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
            Con.Close();
        }

        //Sql Connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");
       
        //Save button
        private void button_save_Click(object sender, EventArgs e)
        {
            if(textBox_name.Text == "" || textBox_age.Text == "" || textBox_password.Text == "" || textBox_phone.Text == "" || textBox_address.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    int score = 0;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into StudentsTable (Name,Age,Password,Score,Address,Phone) values (@Cn,@Ca,@Cp,@Cs,@Cad,@Cph)", Con);
                    cmd.Parameters.AddWithValue("@Cn",textBox_name.Text);
                    cmd.Parameters.AddWithValue("@Ca",textBox_age.Text);
                    cmd.Parameters.AddWithValue("@Cp",textBox_password.Text);
                    cmd.Parameters.AddWithValue("@Cs",score);
                    cmd.Parameters.AddWithValue("@Cad",textBox_address.Text);
                    cmd.Parameters.AddWithValue("@Cph",textBox_phone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added");
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
        private void button1_Click(object sender, EventArgs e)
        {
            Questions Que = new Questions();
            Que.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Questions Que = new Questions();
            Que.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
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

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
