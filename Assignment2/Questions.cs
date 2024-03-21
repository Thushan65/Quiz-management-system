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
using System.Xml.Serialization;

namespace Assignment2
{
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
            Getsubjects();
            Display();
        }

        private void tutor_background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Reset button
        private void button_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //Update button
        private void button_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }

        //Sql connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");
        
        //Getting Subjects
        private void Getsubjects()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Subject from SubjectTable", Con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Subject",typeof(String));
            dt.Load(dr);
            comboBox_subjects.ValueMember= "Subject";
            comboBox_subjects.DataSource= dt;
            Con.Close();
        }

        //Reset function
        private void Reset()
        {
            textBox_answer.Text = "";
            textBox_o1.Text = "";
            textBox_o2.Text = "";
            textBox_o3.Text = "";
            textBox_o4.Text = "";
            textBox_question.Text = "";
            comboBox_subjects.SelectedIndex = 0;    
        }

        //Displaying questions
        private void Display()
        {
            Con.Open();
            String query = "select * from QuestionTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            Con.Close();
        }

        //Save button
        private void button_save_Click(object sender, EventArgs e)
        {
            if (textBox_question.Text == "" || textBox_o4.Text == "" || textBox_o3.Text == "" || textBox_o2.Text == "" || textBox_o1.Text == "" || textBox_answer.Text == "" || comboBox_subjects.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into QuestionTable (Question,Guess01,Guess02,Guess03,Guess04,Answer,Subject) values (@qq,@qo1,@qo2,@qo3,@qo4,@ans,@sub)", Con);
                    cmd.Parameters.AddWithValue("@qq", textBox_question.Text);
                    cmd.Parameters.AddWithValue("@qo1", textBox_o1.Text);
                    cmd.Parameters.AddWithValue("@qo2", textBox_o2.Text);
                    cmd.Parameters.AddWithValue("@qo3", textBox_o3.Text);
                    cmd.Parameters.AddWithValue("@qo4", textBox_o4.Text);
                    cmd.Parameters.AddWithValue("@ans", textBox_answer.Text);
                    cmd.Parameters.AddWithValue("@sub", comboBox_subjects.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question Added");
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

        private void comboBox_subjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_o4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_o1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_o3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_answer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_o2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_question_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Navigation buttons
        private void label8_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Student Stu = new Student();
            Stu.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Results rs = new Results();
            rs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student Stu = new Student();
            Stu.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \nFeature will be available soon");
        }

        private void Questions_Load(object sender, EventArgs e)
        {

        }
    }
}
