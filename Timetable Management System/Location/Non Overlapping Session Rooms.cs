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

namespace Timetable_Management_System.Location
{
    public partial class Non_Overlapping_Session_Rooms : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";


        public Non_Overlapping_Session_Rooms()
        {
            InitializeComponent();
            GridFill();
        }

        //Non overlapping rooms table view
        private void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_NOlp_session_room", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView5.DataSource = data_table_Add_Room;
                dataGridView5.Columns[0].Visible = true;

            }
        }

        //back button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
