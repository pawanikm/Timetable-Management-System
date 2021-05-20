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
    public partial class Add_Suitable_Room : Form
    {

        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int Id_suitable_location;

        
        public Add_Suitable_Room()
        {
            InitializeComponent();

            dropdown();
            Clear();
            GridFill1();
            GridFill2();
            GridFill3();
            GridFill4();
            GridFill5();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dropdown() {

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
                    comboBox2.Items.Add(dr2["Room_Name"].ToString());
                    comboBox2.DisplayMember = (dr2["Room_Name"].ToString());
                    comboBox2.ValueMember = (dr2["Location_Id"].ToString());
                }
                mysqlCon.Close();

            }

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("ViewAll_mTags", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox4.Items.Add(dr2["tag_name"].ToString());
                    comboBox4.DisplayMember = (dr2["tag_name"].ToString());
                    comboBox4.ValueMember = (dr2["id_MT"].ToString());
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

                MySqlCommand mysqlCmd2 = new MySqlCommand("View_Lecturers", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox6.Items.Add(dr2["lec_name"].ToString());
                    comboBox6.DisplayMember = (dr2["lec_name"].ToString());
                    comboBox6.ValueMember = (dr2["lec_id"].ToString());
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

                MySqlCommand mysqlCmd2 = new MySqlCommand("ViewAll_StdGroups", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox8.Items.Add(dr2["Group_ID"].ToString());
                    comboBox8.DisplayMember = (dr2["Group_ID"].ToString());
                    comboBox8.ValueMember = (dr2["id_SG"].ToString());
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

                MySqlCommand mysqlCmd = new MySqlCommand("View_Subject", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr = mysqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox11.Items.Add(dr["s_name"].ToString());
                    comboBox11.DisplayMember = (dr["s_name"].ToString());
                    comboBox11.ValueMember = (dr["sub_id"].ToString());
                }
                mysqlCon.Close();
            }


            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlCmd2 = new MySqlCommand("ViewAll_mTags", mysqlCon);
                mysqlCmd2.CommandType = CommandType.StoredProcedure;

                MySqlDataReader dr2 = mysqlCmd2.ExecuteReader();

                while (dr2.Read())
                {
                    comboBox10.Items.Add(dr2["tag_name"].ToString());
                    comboBox10.DisplayMember = (dr2["tag_name"].ToString());
                    comboBox10.ValueMember = (dr2["id_MT"].ToString());
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

        void Clear()
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = comboBox7.Text = comboBox8.Text = string.Empty;
            Id_suitable_location = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                mysqlCmd.Parameters.AddWithValue("_Subjects", comboBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Tags", comboBox4.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Lecturers", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Group_ids", comboBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Rooms", comboBox2.Text.Trim());

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Room Allocated Successfully!!");
            }

            Clear();
            GridFill1();
        }



        void GridFill1()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_subject_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView1.DataSource = data_table_Add_Room;
                dataGridView1.Columns[0].Visible = true;

            }
        }

        void GridFill2()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_tag_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView2.DataSource = data_table_Add_Room;
                dataGridView2.Columns[0].Visible = true;

            }
        }

        void GridFill3()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_lecturer_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView3.DataSource = data_table_Add_Room;
                dataGridView3.Columns[0].Visible = true;

            }
        }

        void GridFill4()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_group_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView4.DataSource = data_table_Add_Room;
                dataGridView4.Columns[0].Visible = true;

            }
        }

        void GridFill5()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_prefered_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView5.DataSource = data_table_Add_Room;
                dataGridView5.Columns[0].Visible = true;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("del_all_room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                Console.WriteLine(Id_suitable_location);

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!!");
            }
            Clear();
            GridFill1();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                mysqlCmd.Parameters.AddWithValue("_Subjects", comboBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Tags", comboBox4.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Lecturers", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Group_ids", comboBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Rooms", comboBox3.Text.Trim());

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Room Allocated Successfully!!");
            }

            Clear();
            GridFill2();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                mysqlCmd.Parameters.AddWithValue("_Subjects", comboBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Tags", comboBox4.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Lecturers", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Group_ids", comboBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Rooms", comboBox5.Text.Trim());

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Room Allocated Successfully!!");
            }

            Clear();
            GridFill3();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                mysqlCmd.Parameters.AddWithValue("_Subjects", comboBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Tags", comboBox4.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Lecturers", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Group_ids", comboBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Rooms", comboBox7.Text.Trim());

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Room Allocated Successfully!!");
            }

            Clear();
            GridFill4();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Room", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Id_suitable_location", Id_suitable_location);
                mysqlCmd.Parameters.AddWithValue("_Subjects", comboBox11.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Tags", comboBox10.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Lecturers", comboBox6.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Group_ids", comboBox8.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Rooms", comboBox9.Text.Trim());

                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Room Allocated Successfully!!");
            }

            Clear();
            GridFill5();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }
    }
}
