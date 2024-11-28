using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktikaa2
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private SQLiteDataAdapter dataAdapter;
        private DataTable dataTable;
        private SQLiteCommand command;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=AAA.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
          
        }
        private void LoadData()
        {
            string query = "SELECT * FROM Installations";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void LoadData2()
        {
            string query = "SELECT * FROM Products";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void LoadData3()
        {
            string query = "SELECT * FROM Users";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT application_area, COUNT(*) AS product_count\r\nFROM Products\r\nGROUP BY application_area\r\nORDER BY product_count DESC\r\nLIMIT 1;";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT SUM(installation_cost) AS total_cost\r\nFROM Installations\r\nWHERE user_id = (SELECT id FROM Users WHERE name = 'Белый ветер')\r\nAND strftime('%Y', installation_date) = '2000';";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT p.name, COUNT(i.id) AS installation_count\r\nFROM Products p\r\nLEFT JOIN Installations i ON p.id = i.product_id\r\nWHERE p.type = 'Серверная ОС'\r\nGROUP BY p.id\r\nORDER BY installation_count DESC;";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

     
 
    }
}
