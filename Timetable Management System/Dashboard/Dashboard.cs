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
using System.Windows.Forms.DataVisualization.Charting;

namespace Timetable_Management_System
{
    public partial class Dashboard : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int lecturers_count, subjects_count, groups_count, locations_count;

        public Dashboard()
        {
            InitializeComponent();
        }


        void Counts()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlcmd1 = new MySqlCommand("SELECT COUNT(lec_id) AS lec_count FROM lecturers", mysqlCon);
                MySqlDataReader reader1;

                reader1 = mysqlcmd1.ExecuteReader();
                while (reader1.Read())
                {

                    lecturers_count = reader1.GetInt32("lec_count");
                    textBox11.Text = lecturers_count.ToString();

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd2 = new MySqlCommand("SELECT COUNT(sub_id) AS sub_count FROM subjects", mysqlCon);
                MySqlDataReader reader2;

                reader2 = mysqlcmd2.ExecuteReader();
                while (reader2.Read())
                {

                    subjects_count = reader2.GetInt32("sub_count");
                    textBox12.Text = subjects_count.ToString();

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd3 = new MySqlCommand("SELECT COUNT(id_SG) AS group_count FROM student_group", mysqlCon);
                MySqlDataReader reader3;

                reader3 = mysqlcmd3.ExecuteReader();
                while (reader3.Read())
                {

                    groups_count = reader3.GetInt32("group_count");
                    textBox13.Text = groups_count.ToString();

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd4 = new MySqlCommand("SELECT COUNT(Location_Id) AS location_count  FROM location", mysqlCon);
                MySqlDataReader reader4;

                reader4 = mysqlcmd4.ExecuteReader();
                while (reader4.Read())
                {

                    locations_count = reader4.GetInt32("location_count");
                    textBox14.Text = locations_count.ToString();

                }
                mysqlCon.Close();
            }

        }

        void Chart()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlCommand mysqlcmd1 = new MySqlCommand("SELECT COUNT(lec_id) AS lec_count FROM lecturers", mysqlCon);
                MySqlDataReader reader1;

                reader1 = mysqlcmd1.ExecuteReader();

                chart2.Series["No of Count"].XValueMember = "No of Registered Items";
                chart2.Series["No of Count"].YValueMembers = "Category";
                this.chart2.Titles.Add("Statistics");
                chart2.Series["No of Count"].ChartType = SeriesChartType.Column;
                chart2.Series["No of Count"].IsValueShownAsLabel = true;

                while (reader1.Read())
                {

                    this.chart2.Series["No of Count"].Points.AddXY("lecturers",reader1.GetUInt32("lec_count"));

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd2 = new MySqlCommand("SELECT COUNT(sub_id) AS sub_count FROM subjects", mysqlCon);
                MySqlDataReader reader2;

                reader2 = mysqlcmd2.ExecuteReader();
                while (reader2.Read())
                {

                    this.chart2.Series["No of Count"].Points.AddXY("subjects",reader2.GetUInt32("sub_count"));

                }
                mysqlCon.Close();

                mysqlCon.Open();
                MySqlCommand mysqlcmd3 = new MySqlCommand("SELECT COUNT(id_SG) AS group_count FROM student_group", mysqlCon);
                MySqlDataReader reader3;

                reader3 = mysqlcmd3.ExecuteReader();
                while (reader3.Read())
                {

                    this.chart2.Series["No of Count"].Points.AddXY("groups",reader3.GetUInt32("group_count"));

                }

                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd4 = new MySqlCommand("SELECT COUNT(Location_Id) AS LH_count  FROM location WHERE Room_Type = 'Lecture Hall'", mysqlCon);
                MySqlDataReader reader4;
                reader4 = mysqlcmd4.ExecuteReader();
                while (reader4.Read())
                {

                    this.chart2.Series["No of Count"].Points.AddXY("lecture halls",reader4.GetUInt32("LH_count"));

                }
                mysqlCon.Close();

                mysqlCon.Open();
                MySqlCommand mysqlcmd5 = new MySqlCommand("SELECT COUNT(Location_Id) AS lab_count  FROM location WHERE Room_Type = 'Lab'", mysqlCon);
                MySqlDataReader reader5;
                reader5 = mysqlcmd5.ExecuteReader();
                while (reader5.Read())
                {

                    this.chart2.Series["No of Count"].Points.AddXY("labs", reader5.GetUInt32("lab_count"));

                }
                mysqlCon.Close();



            }
        }

        void Latest_Updates()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlcmd1 = new MySqlCommand("SELECT lec_name AS lecturer FROM lecturers ORDER BY lec_id DESC LIMIT 1", mysqlCon);
                MySqlDataReader reader1;

                reader1 = mysqlcmd1.ExecuteReader();
                while (reader1.Read())
                { 
                    textBox8.Text = reader1.GetString("lecturer");

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd2 = new MySqlCommand("SELECT s_name AS subject FROM subjects ORDER BY sub_id DESC LIMIT 1", mysqlCon);
                MySqlDataReader reader2;

                reader2 = mysqlcmd2.ExecuteReader();
                while (reader2.Read())
                {

                    
                    textBox9.Text = reader2.GetString("subject");

                }
                mysqlCon.Close();


                mysqlCon.Open();
                MySqlCommand mysqlcmd3 = new MySqlCommand("SELECT Group_ID AS st_group FROM student_group ORDER BY id_SG DESC LIMIT 1", mysqlCon);
                MySqlDataReader reader3;

                reader3 = mysqlcmd3.ExecuteReader();
                while (reader3.Read())
                {

                    textBox10.Text = reader3.GetString("st_group");

                }
                mysqlCon.Close();

             
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {
         
            Chart();
            Counts();
            Latest_Updates();

        }

        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

       
       
    }
}
