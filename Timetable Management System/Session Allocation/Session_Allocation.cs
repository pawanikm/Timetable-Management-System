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

namespace WindowsFormsApp1.Student
{
    public partial class Session_Allocation : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int cs_ID;
        int ps_ID;
        int nos_ID;
        int NAT_GID;
        int NAT_TID;

        public Session_Allocation()
        {
            InitializeComponent();
            DropDown();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

            
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Session_Allocation_Load(object sender, EventArgs e)
        {
            GridFill_Consecutive();
            GridFill_Parallel();
            GridFill_Non_Overlapping();
            GridFill__Not_Available_Times_G();
            GridFill__Not_Available_Times_L();
            Clear();
        }

  
        //Retrieve table to grid (consecutive)
        void GridFill_Consecutive()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_consecutive_s", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblcsession = new DataTable();
                sqlDa.Fill(dtblcsession);
                dataGridView1.DataSource = dtblcsession;
            }
        }


        //add button (consecutive)
        private void button13_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Consecutive_Session", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cs_ID", cs_ID);
                mySqlCmd.Parameters.AddWithValue("_Session1_ID", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Session2_ID", comboBox2.Text.Trim());

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }

                GridFill_Consecutive();
            }
        }

        //delete button (consecutive)
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_Consecutive_SeesionByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cs_ID", cs_ID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill_Consecutive();
            }
        }

        //clear button (consecutive)
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //clear function
        void Clear()
        {
            comboBox1.Text = comboBox2.Text = "";
            cs_ID = 0;

            comboBox4.Text = comboBox3.Text = "";
            ps_ID = 0;

            comboBox6.Text = comboBox5.Text = "";
            nos_ID = 0;

            comboBox10.Text = textBox8.Text = textBox6.Text = comboBox9.Text = "";
            NAT_GID = 0;

            comboBox7.Text = textBox1.Text = textBox3.Text = comboBox8.Text = "";
            NAT_TID = 0;


        }


        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Retrieve table to grid (parallel)
        void GridFill_Parallel()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_parallel_s", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblpsession = new DataTable();
                sqlDa.Fill(dtblpsession);
                dataGridView2.DataSource = dtblpsession;
            }
        }

        

        //delete button (parallel)
        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_Parallel_SessionsByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_ps_ID", ps_ID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill_Parallel();
            }
        }

        //add button (parallel)
        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Parallel_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_ps_ID", ps_ID);
                mySqlCmd.Parameters.AddWithValue("_pSession1_ID", comboBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_pSession2_ID", comboBox3.Text.Trim());

                if (comboBox4.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }

                GridFill_Parallel();
            }
        }

        //clear button (parallel)
        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Retrieve table to grid (non overlapping)
        void GridFill_Non_Overlapping()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("View_NonOverlapping_Sessions", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblnosession = new DataTable();
                sqlDa.Fill(dtblnosession);
                dataGridView3.DataSource = dtblnosession;
            }
        }

        //add button (non overlapping)
        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_NonOverlapping_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_nos_ID", ps_ID);
                mySqlCmd.Parameters.AddWithValue("_noSession1_ID", comboBox6.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_noSession2_ID", comboBox5.Text.Trim());

                if (comboBox6.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else if (comboBox5.Text == "")
                {
                    MessageBox.Show("Please select session");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }

                GridFill_Non_Overlapping();
            }
        }

        //delete button (non overlapping)
        private void button7_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_NonOverlapping_SessionByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_nos_ID", nos_ID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill_Non_Overlapping();
            }
        }

        //clear button (non overlapping)
        private void button8_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //retrieve details to the dropdown lists 
        private void DropDown()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["session_id"].ToString());
                    comboBox1.DisplayMember = (dr["session_id"].ToString());
                    comboBox1.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["session_id"].ToString());
                    comboBox2.DisplayMember = (dr["session_id"].ToString());
                    comboBox2.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["session_id"].ToString());
                    comboBox4.DisplayMember = (dr["session_id"].ToString());
                    comboBox4.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["session_id"].ToString());
                    comboBox3.DisplayMember = (dr["session_id"].ToString());
                    comboBox3.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["session_id"].ToString());
                    comboBox5.DisplayMember = (dr["session_id"].ToString());
                    comboBox5.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Sessions", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox6.Items.Add(dr["session_id"].ToString());
                    comboBox6.DisplayMember = (dr["session_id"].ToString());
                    comboBox6.ValueMember = (dr["session_id"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("ViewAll_StdGroups", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox10.Items.Add(dr["SubGroup_ID"].ToString());
                    comboBox10.DisplayMember = (dr["SubGroup_ID"].ToString());
                    comboBox10.ValueMember = (dr["id_SG"].ToString());
                }
                mysqlCon.Close();
            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("View_Lecturers", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr = mySqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox7.Items.Add(dr["lec_name"].ToString());
                    comboBox7.DisplayMember = (dr["lec_name"].ToString());
                    comboBox7.ValueMember = (dr["lec_id"].ToString());
                }
                mysqlCon.Close();
            }
        }




        //not available times tab


        void GridFill__Not_Available_Times_G()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewNotAvailableTimeGroup", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dtbnonag = new DataTable();
                sqlDa.Fill(dtbnonag);
                dataGridView5.DataSource = dtbnonag;
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Not_Available_Time_Group", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_GID", NAT_GID);
                mySqlCmd.Parameters.AddWithValue("_Sub_Group", comboBox10.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Start_Time", textBox8.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_End_Time", textBox6.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Aday", comboBox9.Text.Trim());

                if (comboBox10.Text == "")
                {
                    MessageBox.Show("Please select sub group");
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Please enter start time");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Please enter end time");
                }
                else if (comboBox9.Text == "")
                {
                    MessageBox.Show("Please select day");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }

                GridFill__Not_Available_Times_G();
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_NotAvailableTimeGroup", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_GID", NAT_GID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill__Not_Available_Times_G();
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        void GridFill__Not_Available_Times_L()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewNotAvailableTimeLecturer", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbnonal = new DataTable();
                sqlDa.Fill(dtbnonal);
                dataGridView4.DataSource = dtbnonal;
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Not_Available_Time_Lecturers", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_TID", NAT_TID);
                mySqlCmd.Parameters.AddWithValue("_Lecturer", comboBox7.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Start_Time", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_End_Time", textBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Aday", comboBox8.Text.Trim());

                if (comboBox7.Text == "")
                {
                    MessageBox.Show("Please select lecture");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter start time");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter end time");
                }
                else if (comboBox8.Text == "")
                {
                    MessageBox.Show("Please select day");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                    GridFill__Not_Available_Times_L();
                }


            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_NotAvailableTimeLecturer", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_TID", NAT_TID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill__Not_Available_Times_L();
            }

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
