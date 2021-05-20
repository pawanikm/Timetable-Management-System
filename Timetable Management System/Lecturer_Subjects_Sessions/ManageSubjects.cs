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
    public partial class ManageSubjects : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int sub_id;
        string semester;

        public ManageSubjects()
        {
            InitializeComponent();
        }

        private void ManageSubjects_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_Subject", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblSubject = new DataTable();
                sqlDa.Fill(dtblSubject);
                dataGridView1.DataSource = dtblSubject;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1) {
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                semester = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (semester == "1st semester")
                {
                    radioButton1.Checked = true;
                }
                else if (semester == "2nd semester")
                {
                    radioButton2.Checked = true;
                }
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                numericUpDown2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                numericUpDown3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                numericUpDown4.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                sub_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
               


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Update_Subject", mysqlCon);
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

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully...");
            }
            clear();
            GridFill();
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            numericUpDown1.Text = numericUpDown2.Text = numericUpDown3.Text = numericUpDown4.Text = "";
            comboBox1.Text = string.Empty;
            sub_id = 0;
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("DeleteSubjectById", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_sub_id", sub_id);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully...");
            }
            clear();
            GridFill();

        }
    }
}
