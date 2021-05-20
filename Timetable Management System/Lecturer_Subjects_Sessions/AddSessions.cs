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
    public partial class AddSessions : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int session_id;
        String lecturers;

        public AddSessions()
        {
            InitializeComponent();
            dropdown();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void AddSessions_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            lecturers = lecturers + comboBox5.Text + ",";
            textBox1.Text = lecturers;
        }

        private void dropdown()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand ("View_Lecturers", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read()){
                    comboBox5.Items.Add(dr["lec_name"].ToString());
                    comboBox5.DisplayMember = (dr["lec_name"].ToString());
                    comboBox5.ValueMember=(dr["lec_id"].ToString());
                }

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("View_Lecturers", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["lec_name"].ToString());
                    comboBox2.DisplayMember = (dr["lec_name"].ToString());
                    comboBox2.ValueMember = (dr["lec_id"].ToString());
                }

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("View_Subject", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["s_name"].ToString());
                    comboBox1.DisplayMember = (dr["s_name"].ToString());
                    comboBox1.ValueMember = (dr["sub_id"].ToString());
                }

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("ViewAll_StdGroups", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["SubGroup_ID"].ToString());
                    comboBox4.DisplayMember = (dr["SubGroup_ID"].ToString());
                    comboBox4.ValueMember = (dr["id_SG"].ToString());
                }

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("ViewAll_mTags", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["tag_name"].ToString());
                    comboBox3.DisplayMember = (dr["tag_name"].ToString());
                    comboBox3.ValueMember = (dr["id_MT"].ToString());
                }

            }

         
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = string.Empty;
           

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lecturers = lecturers + comboBox2.Text ;
            textBox1.Text = lecturers;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_session_id", session_id);
                mySqlCmd.Parameters.AddWithValue("_lec1", comboBox5.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_lec2", comboBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_sub_name", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_sub_code", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_group_id", comboBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_students", textBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_tag", comboBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_duration", textBox4.Text.Trim());

                if (comboBox5.Text == "")
                {
                    MessageBox.Show("Please fill the Lecturer Name Field!!!");
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Lecturer Name Field!!!");
                }
                
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Subject Name Field!!!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Subject Code Field!!!");
                }
                else if (comboBox4.Text == "")
                {
                    MessageBox.Show("Please fill the Group ID Field!!!");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please fill the No of Students Field!!!");
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Please fill the Tag Field!!!");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Please fill the Duration Field!!!");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully...");
                }

            }

            clear();
        }
    }
}
