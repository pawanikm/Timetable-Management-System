using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TimeTableManagementSystem
{
    public partial class AddSubject : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int sub_id;
        string semester;

        public AddSubject()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddSubject_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semester = "1st semester" ;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            semester = "2nd semester";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Subject", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_sub_id", sub_id);
                mySqlCmd.Parameters.AddWithValue("_year", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_semester", semester);
                mySqlCmd.Parameters.AddWithValue("_s_name", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_s_code", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_lecHrs", numericUpDown1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_labHrs", numericUpDown2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_tuteHrs", numericUpDown3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_evaHrs", numericUpDown4.Text.Trim());

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Offered Year Field!!!");
                }
                else if (semester != "1st semester" && semester != "2nd semester")
                {
                    MessageBox.Show("Please fill the Offerd Semester Field!!!");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Subject Name Field!!!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Subject Code Field!!!");
                }
                else if (numericUpDown1.Text == "")
                {
                    MessageBox.Show("Please fill the Number of Lecture Hours Field!!!");
                }
                else if (numericUpDown2.Text == "")
                {
                    MessageBox.Show("Please fill the Number of Lab Hours Field!!!");
                }
                else if (numericUpDown3.Text == "")
                {
                    MessageBox.Show("Please fill the Number of Tutorial Hours Field!!!");
                }
                else if (numericUpDown4.Text == "")
                {
                    MessageBox.Show("Please fill the Number of Evalution Hours Field!!!");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully...");
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear() {
            textBox1.Text = textBox2.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            numericUpDown1.Text = numericUpDown2.Text = numericUpDown3.Text = numericUpDown4.Text = "";
            comboBox1.Text = string.Empty;
            sub_id = 0;
           
        }
    }
}
