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

namespace Timetable_Management_System
{
    public partial class Allocate_Suitable_Location : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int sm_id, s1_id, s2_id;
        int _Id_session_location, NAT_LID;
        
        public Allocate_Suitable_Location()
        {
            InitializeComponent();
            GridFill5();//table view of the sessions that are not allocated for consecutive / non-overlapping / parallel categories
            GridFill1();//table view of the sessions that are allocated for consecutive category
            GridFill3();//table view of the sessions that are allocated for parallel category
            GridFill4();//table view of the sessions that are allocated for non-overlapping category
            GridFill__Not_Available_Times_Location();//table view of the not available times of the locations

            dropdown();//calling dropdown 
        }


//Normal sessions tab-----------------------------------------------------------------------------------------------------------------------------------

        //table view of the sessions that are not allocated for consecutive / non-overlapping / parallel categories
        void GridFill5()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_normal_sessions", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView5.DataSource = data_table_Add_Room;
                dataGridView5.Columns[0].Visible = true;

            }
        }
        String sid;
        //cell content double click
        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.CurrentRow.Index != -1)
            {
                textBox13.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
                sid = dataGridView5.CurrentRow.Cells[0].Value.ToString();

                sm_id = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                
                               
            }
        }

        //specially requested rooms table for normal sessions
        
        private void button15_Click(object sender, EventArgs e)
        {
            Location.View_Requested_Rooms v1 = new Location.View_Requested_Rooms();
            v1.ShowDialog();
        }

        //save button
        private void button8_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("add_normal_s_room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_session_location", _Id_session_location);
                mysqlCmd.Parameters.AddWithValue("_Normal_Session_id", textBox13.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_id", sid);
                mysqlCmd.Parameters.AddWithValue("_Session1_Room", comboBox3.Text.Trim());

                if (textBox13.Text == "")
                {
                    MessageBox.Show("Please select a normal session!!!");
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }

                else
                {
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                }

                Clear();

            }
        }

        //view session rooms
        private void button3_Click(object sender, EventArgs e)
        {
            Location.View_Session_Room v1 = new Location.View_Session_Room();
            v1.ShowDialog();
        }

        //refresh table & form 
        private void button10_Click(object sender, EventArgs e)
        {
            GridFill5();
            Clear();
        }









//Consecutive sessions tab---------------------------------------------------------------------------------------------------------------------------------

        //table view of the sessions that are allocated for consecutive category
        void GridFill1()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_consecutive_s", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView1.DataSource = data_table_Add_Room;
                dataGridView1.Columns[0].Visible = true;

            }
        }

        //parallel sessions table doubleclick function
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                sm_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                s1_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                s2_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value.ToString());

                

            }
        }

        //specially requested rooms table for parallel sessions
        private void button16_Click(object sender, EventArgs e)
        {
            Location.View_Requested_Rooms v1 = new Location.View_Requested_Rooms();
            v1.ShowDialog();
        }


        //save button for consecutive sessions
        private void button7_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("add_consec_s_room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_session_location", _Id_session_location);
                mysqlCmd.Parameters.AddWithValue("_Consec_Session_id", textBox7.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_id", textBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_id", textBox5.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_Room", comboBox4.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_Room", comboBox9.Text.Trim());


                if (textBox7.Text == "")
                {
                    MessageBox.Show("Please select a consective session!!!");
                }
                else if(textBox6.Text == "")
                {
                    MessageBox.Show("Please select a consective session!!!");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Please select a consective session!!!");
                }
                else if (comboBox4.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                else if (comboBox9.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                else if (comboBox4.Text != comboBox9.Text)
                {
                    MessageBox.Show("Please select same room for both sessions!!!");
                }

                else
                {
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                }

                Clear();

            }
        }

        //view rooms - consecutive sessions 
        private void button2_Click(object sender, EventArgs e)
        {
            Consecutive_Sessions p = new Consecutive_Sessions();
            p.ShowDialog();
        }

        //Refresh Table & forms
        private void button4_Click(object sender, EventArgs e)
        {
            GridFill1();
            Clear();
        }









 //Parallel sessions tab---------------------------------------------------------------------------------------------------------------------------------

        //table view of the sessions that are allocated for parallel category
        void GridFill3()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_parallel_s", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView3.DataSource = data_table_Add_Room;
                dataGridView3.Columns[0].Visible = true;

            }
        }


        //parallel sessions table doubleclick function
        private void dataGridView3_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentRow.Index != -1)
            {
                textBox8.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                textBox11.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox12.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString();

                sm_id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                s1_id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                s2_id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[8].Value.ToString());

               
                
            }
        }


        //specially requested rooms table for parallel sessions
        private void button17_Click(object sender, EventArgs e)
        {
            Location.View_Requested_Rooms v1 = new Location.View_Requested_Rooms();
            v1.ShowDialog();
        }

        //Save parallel session location
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("add_para_session_room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_session_location", _Id_session_location);
                mysqlCmd.Parameters.AddWithValue("_Parallel_Session_id", textBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_id", textBox11.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_id", textBox12.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_Room", comboBox5.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_Room", comboBox7.Text.Trim());


                if (textBox8.Text == "")
                {
                    MessageBox.Show("Please select a parallel session!!!");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("Please select a parallel session!!!");
                }
                else if (textBox12.Text == "")
                {
                    MessageBox.Show("Please select a parallel session!!!");
                }
                else if (comboBox5.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                else if (comboBox7.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                else if (comboBox5.Text == comboBox7.Text)
                {
                    MessageBox.Show("Please select different rooms for the sessions!!!");
                }

                else
                {
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                }

                Clear();
            }

        }

        //view rooms - parallel sessions 
        private void button11_Click(object sender, EventArgs e)
        {
            Timetable_Management_System.Location.Parallel_Sessions_Rooms p = new Location.Parallel_Sessions_Rooms();
            p.ShowDialog();
        }

        //Refresh Table & forms
        private void button13_Click(object sender, EventArgs e)
        {
            GridFill3();
            Clear();
        }






//Non Overlapping sessions tab------------------------------------------------------------------------------------------------------------------------

        //table view of the sessions that are allocated for non-overlapping category
        void GridFill4()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("View_NonOverlapping_Sessions", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView4.DataSource = data_table_Add_Room;
                dataGridView4.Columns[0].Visible = false;

            }
        }

        //nonoverlapping sessions table doubleclick function
        private void dataGridView4_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentRow.Index != -1)
            {
                textBox14.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                textBox10.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView4.CurrentRow.Cells[8].Value.ToString();

                sm_id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                s1_id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[1].Value.ToString());
                s2_id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[8].Value.ToString());

                
            }
        }

        //Specially requested rooms table for non overlapping sessions
        private void button18_Click(object sender, EventArgs e)
        {
            Location.View_Requested_Rooms v1 = new Location.View_Requested_Rooms();
            v1.ShowDialog();
        }

        //Save non overlapping session location
        private void button9_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("add_NOlp_session_room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_session_location", _Id_session_location);
                mysqlCmd.Parameters.AddWithValue("_NOlp_Session_id", textBox14.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_id", textBox10.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_id", textBox9.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session1_Room", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Session2_Room", comboBox8.Text.Trim());


                if (textBox14.Text == "")
                {
                    MessageBox.Show("Please select a non overlapping session!!!");
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Please select a non overlapping session!!!");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Please select a non overlapping session!!!");
                }
                else if (comboBox6.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                else if (comboBox8.Text == "")
                {
                    MessageBox.Show("Please select a room for the session!!!");
                }
                
                else
                {
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                }

                Clear();

            }
        }


        //specially requested rooms table for non overlapping sessions  
        private void button12_Click(object sender, EventArgs e)
        {
            Timetable_Management_System.Location.Non_Overlapping_Session_Rooms p = new Location.Non_Overlapping_Session_Rooms();
            p.ShowDialog();
          
        }

        //Refresh       
        private void button14_Click(object sender, EventArgs e)
        {
            GridFill4();
            Clear();
        }










//Not available times for locations---------------------------------------------------------------------------------------------------------
        
        //Table view of Not available times forlocations
        void GridFill__Not_Available_Times_Location()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDAA = new MySqlDataAdapter("ViewNotAvailableTimeLocations", mysqlCon);
                sqlDAA.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbnonalo = new DataTable();
                sqlDAA.Fill(dtbnonalo);
                dataGridView2.DataSource = dtbnonalo;
            }
        }

        //save button 
        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Not_Available_Time_Locations", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_LID", NAT_LID);
                mySqlCmd.Parameters.AddWithValue("_Sroom", comboBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Sday", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Start_Time", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_End_Time", textBox2.Text.Trim());

                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Please select room");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please select day");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter start day");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter end time ");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                    GridFill__Not_Available_Times_Location();
                }
            }
        }



        //Delete button
        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_NotAvailableTimeLocation", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_NAT_LID", NAT_LID);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill__Not_Available_Times_Location();
            }
        }







//All comboboxes - dropdown function---------------------------------------------------------------------------------------------------------------
        private void dropdown()
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox2.Items.Add(dr2["Room_Name"].ToString());
                    comboBox2.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox2.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }


            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox3.Items.Add(dr2["Room_Name"].ToString());
                    comboBox3.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox3.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox4.Items.Add(dr2["Room_Name"].ToString());
                    comboBox4.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox4.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox5.Items.Add(dr2["Room_Name"].ToString());
                    comboBox5.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox5.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox6.Items.Add(dr2["Room_Name"].ToString());
                    comboBox6.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox6.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox7.Items.Add(dr2["Room_Name"].ToString());
                    comboBox7.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox7.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox8.Items.Add(dr2["Room_Name"].ToString());
                    comboBox8.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox8.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Location", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox9.Items.Add(dr2["Room_Name"].ToString());
                    comboBox9.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox9.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }
        }



        //clear function
        private void Clear()
        {
            textBox1.Text = textBox2.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = "";
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = comboBox7.Text = comboBox8.Text = comboBox9.Text = "";

        }




        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void Allocate_Suitable_Location_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
