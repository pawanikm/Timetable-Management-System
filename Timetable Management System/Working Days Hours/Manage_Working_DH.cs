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

namespace Time_Table_Management_System
{
    public partial class ManageWorkingdayshours : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int idWorking_dayshours;
        string days, day1, day2, day3, day4, day5, day6, day7 = "";
      

        public ManageWorkingdayshours()
        {
            InitializeComponent();
        }

        private void ManageWorkingdayshours_Load(object sender, EventArgs e)
        {

            GridFill();
        }


        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("View_Workingdayshours", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Location = new DataTable();
                mysqlDataAdapt.Fill(data_table_Location);
                dataGridView1.DataSource = data_table_Location;
                dataGridView1.Columns[0].Visible = false;

            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Update_workingdayshours", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                days = day1 + day2 + day3 + day4 + day5 + day6 + day7;

                mysqlCmd.Parameters.AddWithValue("_idWorking_dayshours", idWorking_dayshours);
                mysqlCmd.Parameters.AddWithValue("_noWorking_days", numericUpDown1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Working_days", days);
                mysqlCmd.Parameters.AddWithValue("_Working_hours", numericUpDown2.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Working_minutes", numericUpDown3.Text.Trim());
                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!!");
            }
            Clear();
            GridFill();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("DeleteworkingdayshoursByid", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_idWorking_dayshours", idWorking_dayshours);

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!!");
            }
            Clear();
            GridFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clear();
        }
        void Clear()
        {
            numericUpDown1.Text = numericUpDown2.Text = numericUpDown3.Text = "";

            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = checkBox5.Checked = checkBox6.Checked = checkBox7.Checked = false;

            idWorking_dayshours = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            day1 = "Monday";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            day2 = "Tuesday";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            day3 = "Wednesday";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            day4 = "Thursday";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            day5 = "Friday";
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            day6 = "saturday";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            day7 = "Sunday";
        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                numericUpDown2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                numericUpDown3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                idWorking_dayshours = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                string day_ = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                if (day_ == "Monday")
                {
                    checkBox1.Checked = true;
                }
                else if (day_ == "Tuesday")
                {
                    checkBox2.Checked = true;
                }
                else if (day_ == "Wednesday")
                {
                    checkBox3.Checked = true;
                }
                else if (day_ == "Thursday")
                {
                    checkBox4.Checked = true;
                }
                else if (day_ == "Friday")
                {
                    checkBox5.Checked = true;
                }
                else if (day_ == "Saturday")
                {
                    checkBox6.Checked = true;
                }
                else if (day_ == "Sunday")
                {
                    checkBox7.Checked = true;
                }
               
            }
            

          


        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            day1 = "Tuesday";
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            day2 = "Monday";
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            day3 = "Wednesday";
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            day4 = "Thursday";
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            day5 = "Friday";
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            day6 = "Saturday";
        }

        private void checkBox7_CheckedChanged_1(object sender, EventArgs e)
        {
            day7 = "Sunday";
        }
    }
}







