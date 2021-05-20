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
    public partial class ManageLecturers : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int lec_id;
        float rank;

        public ManageLecturers()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Update_Lecturers", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_lec_id", lec_id);
                mySqlCmd.Parameters.AddWithValue("_lec_name", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_emp_id", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_faculty", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_department", comboBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_center", comboBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_building", comboBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_level", comboBox5.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_rank", textBox3.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully...");
                
            }
            clear();
            GridFill();
        }

        private void ManageLecturers_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_Lecturers", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblLec = new DataTable();
                sqlDa.Fill(dtblLec);
                dataGridView1.DataSource = dtblLec;
                dataGridView1.Columns[0].Visible = false;

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("DeleteLecturersById", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_lec_id", lec_id);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully...");
            }
            clear();
            GridFill();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                comboBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                lec_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = string.Empty;
            lec_id = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> items = new List<String>();
            comboBox2.Items.Clear();

            switch (comboBox1.SelectedItem)
            {
                case "Computing":
                    items.Add("Information Technology");
                    items.Add("Software Engineering");
                    items.Add("Cyber Security");
                    items.Add("Data Science");
                    items.Add("Information System engineering");
                    items.Add("Computer Systems and Network");
                    items.Add("Interactive Media");
                    break;
                case "Engineering":
                    items.Add("Civil Engineering");
                    items.Add("Electrical & Electronic Engineering");
                    items.Add("Mechanical Engineering");
                    items.Add("Mechatronic");
                    items.Add("Materials Engineering");
                    items.Add("Architecture");
                    items.Add("Quantity Surveying");
                    break;
                case "Business":
                    items.Add("Accounting & Finance");
                    items.Add("Business Analytics");
                    items.Add("Human Capital Management");
                    items.Add("Marketing Management");
                    items.Add("Logistics & Supply Chain Management");
                    break;
                case "Humanities & Sciences":
                    items.Add("Biotechnology");
                    items.Add("Education");
                    items.Add("Law");
                    items.Add("Mathematics");
                    items.Add("Nursing");
                    items.Add("Psychology");
                    break;
                case "Architecture":
                    items.Add("Architecture");
                    break;
                case "Hospitality & Culinary":
                    items.Add("Hospitality Management");
                    items.Add("Commercial Cookery");
                    items.Add("Event Management");
                    items.Add("Patisserie Programme");
                    break;
            }
            comboBox2.Items.AddRange(items.ToArray());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.Equals("Professor"))
            {
                rank = 1;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Assistant Professor"))
            {
                rank = 2;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Senior Lecturer(HG)"))
            {
                rank = 3;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Senior Lecturer"))
            {
                rank = 4;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Lecturer"))
            {
                rank = 5;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Assistant Lecturer"))
            {
                rank = 6;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else
            {
                rank = 7;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
        }
    }
}
