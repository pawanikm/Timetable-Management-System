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
    public partial class View_Session_Room : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";


        public View_Session_Room()
        {
            InitializeComponent();
            GridFill();
        }
        //rooms table - parallel session
        private void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_session_rooms", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView5.DataSource = data_table_Add_Room;
                dataGridView5.Columns[0].Visible = true;

            }
        }
        //Back Button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void View_Session_Room_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
