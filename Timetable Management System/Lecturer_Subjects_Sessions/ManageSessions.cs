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
    public partial class ManageSessions : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int session_id;

        public ManageSessions()

        {
            InitializeComponent();
            dropdown();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ManageSessions_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_Sessions", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblLec = new DataTable();
                sqlDa.Fill(dtblLec);
                dataGridView1.DataSource = dtblLec;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                session_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());



            }
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            comboBox7.Text = comboBox2.Text = comboBox3.Text = comboBox6.Text = comboBox5.Text = string.Empty;
            session_id = 0;

        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Update_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_session_id", session_id);
                mySqlCmd.Parameters.AddWithValue("_lec1", comboBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_lec2", comboBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_sub_name", comboBox5.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_sub_code", textBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_group_id", comboBox6.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_no_of_students", textBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_tag", comboBox7.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_duration", textBox2.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully...");

            }
            clear();
            GridFill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("DeleteSessionsById", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_session_id", session_id);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully...");
            }
            clear();
            GridFill();
        }

        private void dropdown()
        {
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
                MySqlCommand mysqlCmd = new MySqlCommand("View_Lecturers", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["lec_name"].ToString());
                    comboBox3.DisplayMember = (dr["lec_name"].ToString());
                    comboBox3.ValueMember = (dr["lec_id"].ToString());
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
                    comboBox5.Items.Add(dr["s_name"].ToString());
                    comboBox5.DisplayMember = (dr["s_name"].ToString());
                    comboBox5.ValueMember = (dr["sub_id"].ToString());
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
                    comboBox6.Items.Add(dr["SubGroup_ID"].ToString());
                    comboBox6.DisplayMember = (dr["SubGroup_ID"].ToString());
                    comboBox6.ValueMember = (dr["id_SG"].ToString());
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
                    comboBox7.Items.Add(dr["tag_name"].ToString());
                    comboBox7.DisplayMember = (dr["tag_name"].ToString());
                    comboBox7.ValueMember = (dr["id_MT"].ToString());
                }

            }

          


        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("SearchByValue", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_searchValue", textBox1.Text);
                DataTable dtblLec = new DataTable();
                sqlDa.Fill(dtblLec);
                dataGridView1.DataSource = dtblLec;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSessions v1 = new AddSessions();
            v1.Show();
        }
    }
}
