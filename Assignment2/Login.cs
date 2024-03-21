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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Getsubjects();
        }

        //Sql Connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");

        //Getting subjects from the database
        private void Getsubjects()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Subject from SubjectTable", Con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Subject", typeof(String));
            dt.Load(dr);
            comboBox_subjectslogin.ValueMember = "Subject";
            comboBox_subjectslogin.DataSource = dt;
            Con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void comboBox_subjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static string StdName = "" , SubName = "";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Tutor login button
        private void label6_Click(object sender, EventArgs e)
        {
            if(textBox_username.Text == "Tutor01" && textBox_password.Text == "Test1234")
            {
                Questions Qs = new Questions();
                Qs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //Student login button
        private void button_login_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from StudentsTable where Password = '" + textBox_password.Text + "' and Name = '" + textBox_username.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    StdName = textBox_username.Text;
                    SubName = comboBox_subjectslogin.SelectedValue.ToString();
                    Quiz nq= new Quiz();
                    nq.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                Con.Close();
            }
        }
    }
}
