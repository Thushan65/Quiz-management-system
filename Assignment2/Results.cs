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
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
            Display();
            Display2();
        }

        //Navigation buttons
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

        private void button4_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Subjects Sbj = new Subjects();
            Sbj.Show();
            this.Hide();
        }

        //Showing data in the grid
        private void Display()
        {
            Con.Open();
            String query = "select * from SubjectTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView_results.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Display2()
        {
            Con.Open();
            String query = "select * from ResultsTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView_results.DataSource = ds.Tables[0];
            Con.Close();
        }

        //Sql Connection
        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-6JT31SC8;Initial Catalog=Assignment2;Integrated Security=True");

        private void label10_Click(object sender, EventArgs e)
        {

        }

        //Logout button
        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login(); 
            lg.Show();
            this.Hide();
        }

        private void Results_Load(object sender, EventArgs e)
        {

        }
    }
}
