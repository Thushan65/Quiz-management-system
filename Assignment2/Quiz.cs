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
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
            label_quizname.Text = Login.StdName;
            label_subject.Text = Login.SubName;
            multirandom();
            // Qn = QuestionAmount();
            DisplayQUestions();
            
        }

        int Qn;

        //Creating an Sql Connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");
        String a1, a2, a3, a4, a5, a6, a7, a8, a9, a10;

        private void Quiz_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private int QuestionAmount()
        {
            int Qnum;
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from QuestionTable where Subject = '"+Login.SubName+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Qnum = Convert.ToInt32(dt.Rows[0][0]);
            Con.Close();
            return Qnum;
        }
        

        //timer
        int Chrono =1000;
        int count =1000;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Chrono -= 1;
            count -= 1;
            progressBar_timing.Value = Chrono;
            label_timing.Text ="" +count;

            if(progressBar_timing.Value == 0)
            {
                Score1();
                Score2();
                Score3();
                Score4();
                Score5();
                Score6();
                Score7();
                Score8();
                Score9();
                Score10();
                progressBar_timing.Value = 1000;
                timer1.Stop();
                results();
                MessageBox.Show("Time Over \n Your score is "+score);
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Picking questions randomly
        int[] Keys = new int[10];
        private void multirandom()
        {
            HashSet<int> numbers = new HashSet<int>();
            var rnd = new Random();
            while (numbers.Count < 10)
            {
                numbers.Add(rnd.Next(1, 40));
            }
            for(int i = 0; i < 10; i++)
            {
                Keys[i] = numbers.ElementAt(i);
            }
        }

        //Displaying questions
        private void DisplayQUestions()
        {
            try
            {
                Con.Open();
                string query = "select * from QuestionTable where QuestionId="+ Keys[0] +"";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q1.Text = dr["Question"].ToString();
                    q1o1.Text = dr["Guess01"].ToString();
                    q1o2.Text = dr["Guess02"].ToString();
                    q1o3.Text = dr["Guess03"].ToString();
                    q1o4.Text = dr["Guess04"].ToString();
                    a1 = dr["Answer"].ToString();
                }
               
                string query1 = "select * from QuestionTable where QuestionId=" + Keys[1] + "";
                cmd = new SqlCommand(query1, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q2.Text = dr["Question"].ToString();
                    q2o1.Text = dr["Guess01"].ToString();
                    q2o2.Text = dr["Guess02"].ToString();
                    q2o3.Text = dr["Guess03"].ToString();
                    q2o4.Text = dr["Guess04"].ToString();
                    a2 = dr["Answer"].ToString();
                }

                string query2 = "select * from QuestionTable where QuestionId=" + Keys[2] + "";
                cmd = new SqlCommand(query2, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q3.Text = dr["Question"].ToString();
                    q3o1.Text = dr["Guess01"].ToString();
                    q3o2.Text = dr["Guess02"].ToString();
                    q3o3.Text = dr["Guess03"].ToString();
                    q3o4.Text = dr["Guess04"].ToString();
                    a3 = dr["Answer"].ToString();
                }

                string query3 = "select * from QuestionTable where QuestionId=" + Keys[3] + "";
                cmd = new SqlCommand(query3, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q4.Text = dr["Question"].ToString();
                    q4o1.Text = dr["Guess01"].ToString();
                    q4o2.Text = dr["Guess02"].ToString();
                    q4o3.Text = dr["Guess03"].ToString();
                    q4o4.Text = dr["Guess04"].ToString();
                    a4 = dr["Answer"].ToString();
                }

                string query4 = "select * from QuestionTable where QuestionId=" + Keys[4] + "";
                cmd = new SqlCommand(query4, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q5.Text = dr["Question"].ToString();
                    q5o1.Text = dr["Guess01"].ToString();
                    q5o2.Text = dr["Guess02"].ToString();
                    q5o3.Text = dr["Guess03"].ToString();
                    q5o4.Text = dr["Guess04"].ToString();
                    a5 = dr["Answer"].ToString();
                }

                string query5 = "select * from QuestionTable where QuestionId=" + Keys[5] + "";
                cmd = new SqlCommand(query5, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q6.Text = dr["Question"].ToString();
                    q6o1.Text = dr["Guess01"].ToString();
                    q6o2.Text = dr["Guess02"].ToString();
                    q6o3.Text = dr["Guess03"].ToString();
                    q6o4.Text = dr["Guess04"].ToString();
                    a6 = dr["Answer"].ToString();
                }

                string query6 = "select * from QuestionTable where QuestionId=" + Keys[6] + "";
                cmd = new SqlCommand(query6, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q7.Text = dr["Question"].ToString();
                    q7o1.Text = dr["Guess01"].ToString();
                    q7o2.Text = dr["Guess02"].ToString();
                    q7o3.Text = dr["Guess03"].ToString();
                    q7o4.Text = dr["Guess04"].ToString();
                    a7 = dr["Answer"].ToString();
                }

                string query7 = "select * from QuestionTable where QuestionId=" + Keys[7] + "";
                cmd = new SqlCommand(query7, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q8.Text = dr["Question"].ToString();
                    q8o1.Text = dr["Guess01"].ToString();
                    q8o2.Text = dr["Guess02"].ToString();
                    q8o3.Text = dr["Guess03"].ToString();
                    q8o4.Text = dr["Guess04"].ToString();
                    a8 = dr["Answer"].ToString();
                }

                string query8 = "select * from QuestionTable where QuestionId=" + Keys[8] + "";
                cmd = new SqlCommand(query8, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q9.Text = dr["Question"].ToString();
                    q9o1.Text = dr["Guess01"].ToString();
                    q9o2.Text = dr["Guess02"].ToString();
                    q9o3.Text = dr["Guess03"].ToString();
                    q9o4.Text = dr["Guess04"].ToString();
                    a9 = dr["Answer"].ToString();
                }

                string query9 = "select * from QuestionTable where QuestionId=" + Keys[9] + "";
                cmd = new SqlCommand(query9, Con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    groupBox_q10.Text = dr["Question"].ToString();
                    q10o1.Text = dr["Guess01"].ToString();
                    q10o2.Text = dr["Guess02"].ToString();
                    q10o3.Text = dr["Guess03"].ToString();
                    q10o4.Text = dr["Guess04"].ToString();
                    a10 = dr["Answer"].ToString();
                } 
                Con.Close();    
            }
            catch (Exception Ex)
            {

            }
        }

        //Calculating results
        int score;
        string[] ca = new string[10];

        private void Score1()
        {
            if (q1o1.Checked)
            {
                ca[0] = "";
                ca[0] = q1o1.Text;
            }
            else if (q1o2.Checked)
            {
                ca[0] = "";
                ca[0] = q1o2.Text;
            }
            else if(q1o3.Checked)
            {
                ca[0] = "";
                ca[0] = q1o3.Text;
            }
            else if(q1o4.Checked)
            {
                ca[0] = "";
                ca[0] = q1o4.Text;
            }

            if (ca[0] == a1)
            {
                score= score + 1;
            }
            else
            {
                score = score;            }
        }

        private void Score2()
        {
            if (q2o1.Checked)
            {
                ca[1] = "";
                ca[1] = q2o1.Text;
            }
            else if (q2o2.Checked)
            {
                ca[1] = "";
                ca[1] = q2o2.Text;
            }
            else if (q2o3.Checked)
            {
                ca[1] = "";
                ca[1] = q2o3.Text;
            }
            else if (q2o4.Checked)
            {
                ca[1] = "";
                ca[1] = q2o4.Text;
            }

            if (ca[1] == a2)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score3()
        {
            if (q3o1.Checked)
            {
                ca[2] = "";
                ca[2] = q3o1.Text;
            }
            else if (q3o2.Checked)
            {
                ca[2] = "";
                ca[2] = q3o2.Text;
            }
            else if (q3o3.Checked)
            {
                ca[2] = "";
                ca[2] = q3o3.Text;
            }
            else if (q3o4.Checked)
            {
                ca[2] = "";
                ca[2] = q3o4.Text;
            }

            if (ca[2] == a3)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        //Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry! \n Feature will be available soon");
        }

        private void Score4()
        {
            if (q4o1.Checked)
            {
                ca[3] = "";
                ca[3] = q4o1.Text;
            }
            else if (q4o2.Checked)
            {
                ca[3] = "";
                ca[3] = q4o2.Text;
            }
            else if (q4o3.Checked)
            {
                ca[3] = "";
                ca[3] = q4o3.Text;
            }
            else if (q4o4.Checked)
            {
                ca[3] = "";
                ca[3] = q4o4.Text;
            }

            if (ca[3] == a4)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score5()
        {
            if (q5o1.Checked)
            {
                ca[4] = "";
                ca[4] = q5o1.Text;
            }
            else if (q5o2.Checked)
            {
                ca[4] = "";
                ca[4] = q5o2.Text;
            }
            else if (q5o3.Checked)
            {
                ca[4] = "";
                ca[4] = q5o3.Text;
            }
            else if (q5o4.Checked)
            {
                ca[4] = "";
                ca[4] = q5o4.Text;
            }

            if (ca[4] == a5)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score6()
        {
            if (q6o1.Checked)
            {
                ca[5] = "";
                ca[5] = q6o1.Text;
            }
            else if (q6o2.Checked)
            {
                ca[5] = "";
                ca[5] = q6o2.Text;
            }
            else if (q6o3.Checked)
            {
                ca[5] = "";
                ca[5] = q6o3.Text;
            }
            else if (q6o4.Checked)
            {
                ca[5] = "";
                ca[5] = q6o4.Text;
            }

            if (ca[5] == a6)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score7()
        {
            if (q7o1.Checked)
            {
                ca[6] = "";
                ca[6] = q7o1.Text;
            }
            else if (q7o2.Checked)
            {
                ca[6] = "";
                ca[6] = q7o2.Text;
            }
            else if (q7o3.Checked)
            {
                ca[6] = "";
                ca[6] = q7o3.Text;
            }
            else if (q7o4.Checked)
            {
                ca[6] = "";
                ca[6] = q7o4.Text;
            }

            if (ca[6] == a7)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score8()
        {
            if (q8o1.Checked)
            {
                ca[7] = "";
                ca[7] = q8o1.Text;
            }
            else if (q8o2.Checked)
            {
                ca[7] = "";
                ca[7] = q8o2.Text;
            }
            else if (q8o3.Checked)
            {
                ca[7] = "";
                ca[7] = q8o3.Text;
            }
            else if (q8o4.Checked)
            {
                ca[7] = "";
                ca[7] = q8o4.Text;
            }

            if (ca[7] == a8)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score9()
        {
            if (q9o1.Checked)
            {
                ca[8] = "";
                ca[8] = q9o1.Text;
            }
            else if (q9o2.Checked)
            {
                ca[8] = "";
                ca[8] = q9o2.Text;
            }
            else if (q9o3.Checked)
            {
                ca[8] = "";
                ca[8] = q9o3.Text;
            }
            else if (q9o4.Checked)
            {
                ca[8] = "";
                ca[8] = q9o4.Text;
            }

            if (ca[8] == a9)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        private void Score10()
        {
            if (q10o1.Checked)
            {
                ca[9] = "";
                ca[9] = q10o1.Text;
            }
            else if (q10o2.Checked)
            {
                ca[9] = "";
                ca[9] = q10o2.Text;
            }
            else if (q10o3.Checked)
            {
                ca[9] = "";
                ca[9] = q10o3.Text;
            }
            else if (q10o4.Checked)
            {
                ca[9] = "";
                ca[9] = q10o4.Text;
            }

            if (ca[9] == a10)
            {
                score = score + 1;
            }
            else
            {
                score = score;
            }
        }

        //saving results in the database
        private void results()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into ResultsTable (Subject,Student,Score) values (@rsbj,@rstd,@rsc)", Con);
                cmd.Parameters.AddWithValue("@rsbj", label_subject.Text);
                cmd.Parameters.AddWithValue("@rstd", label_quizname.Text);
                cmd.Parameters.AddWithValue("@rsc", score);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        //submit button
        private void button_submit_Click(object sender, EventArgs e)
        {
            score = 0;
            Score1();
            Score2();
            Score3();
            Score4();
            Score5();
            Score6();
            Score7();
            Score8();
            Score9();
            Score10();
            results();
            MessageBox.Show("Congratulations! \n Your score is "+score );
            Login lg= new Login();
            lg.Show();
            this.Hide();
        }
    }
}

