using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Data.SQLite;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        List<string> url = new List<string>();
        string connectionString;
        SqlConnection connection;
        int check = 0;

        public object ShowConsole { get; private set; }

        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            textBox1.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            button2.Text = "Get Google Chrome History";
            button3.Text = "Get Mozilla FireFox History";
            button4.Text = "Get Safari History";
            button5.Text = "Get Opera History";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            label2.Visible = true;
            textBox1.Visible = true;
            label3.Visible = true;
            textBox2.Visible = true;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                connection = new SqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    if (textBox1.Text == Convert.ToString(dataReader.GetValue(1)) && textBox2.Text == Convert.ToString(dataReader.GetValue(2)))
                    {
                        MessageBox.Show("Parents Account Exist");
                       
                        check = 1;

                      //  MessageBox.Show(Convert.ToString(check));
                    }
                    else
                    {
                        if (check == 0)
                        {
                            MessageBox.Show("Parents Account don't Exist");
                        }

                    }
                    // MessageBox.Show(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                }




            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                string google = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default/History";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + google + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();
                SQLiteConnection conn = new SQLiteConnection
     (@"Data Source=C:\Users\hussi\AppData\Local\Google\Chrome\User Data\Default\History");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                //  cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                //  Use the above query to get all the table names
                cmd.CommandText = "Select * From urls";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[1].ToString());
                    url.Add(dr[1].ToString());

                }
                string res = "facebook";
                string res2 = "Facebook";
                foreach (string item in url)
                {
                    if (item.Contains(res) || item.Contains(res2))
                    {
                        MessageBox.Show("Restricted Site Access!", item);
                    }
                }
            }
            else { MessageBox.Show("Not Logged In as Parent"); }
        }

        private void ShowWindow(string v)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                string mozilla = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mozilla\Firefox\Profiles\2omnu1dg.default\places.sqlite";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + mozilla + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();
                SQLiteConnection conn = new SQLiteConnection
    (@"Data Source=C:\Users\hussi\AppData\Local\mozilla\User Data\Default\History"); //change the directory according to your computer
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                //  cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                //  Use the above query to get all the table names
                cmd.CommandText = "Select * From urls";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[1].ToString());
                    url.Add(dr[1].ToString());

                }
                string res = "facebook";
                string res2 = "Facebook";
                foreach (string item in url)
                {
                    if (item.Contains(res) || item.Contains(res2))
                    {
                        MessageBox.Show("Restricted Site Access!", item);
                    }
                }
            
        }
            else { MessageBox.Show("Not Logged In as Parent"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                string apple = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Apple Computer\Safari\WebpageIcons.db";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + apple + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select * from PageURL", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();
                SQLiteConnection conn = new SQLiteConnection
     (@"Data Source=C:\Users\hussi\AppData\Local\safari\User Data\Default\History"); //change the directory according to your computer
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                //  cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                //  Use the above query to get all the table names
                cmd.CommandText = "Select * From urls";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[1].ToString());
                    url.Add(dr[1].ToString());

                }
                string res = "facebook";
                string res2 = "Facebook";
                foreach (string item in url)
                {
                    if (item.Contains(res) || item.Contains(res2))
                    {
                        MessageBox.Show("Restricted Site Access!", item);
                    }
                }
            }
            else { MessageBox.Show("Not Logged In as Parent"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check == 1)
            {
                string opera = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Opera Software\Opera Stable\History";
                SQLiteConnection cn = new SQLiteConnection("Data Source=" + opera + ";Version=3;New=False;Compress=True;");
                cn.Open();
                SQLiteDataAdapter sd = new SQLiteDataAdapter("select * from URLS", cn);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cn.Close();
                SQLiteConnection conn = new SQLiteConnection
    (@"Data Source=C:\Users\hussi\AppData\Local\opera\User Data\Default\History"); //change the directory according to your computer
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                //  cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
                //  Use the above query to get all the table names
                cmd.CommandText = "Select * From urls";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[1].ToString());
                    url.Add(dr[1].ToString());

                }
                string res = "facebook";
                string res2 = "Facebook";
                foreach (string item in url)
                {
                    if (item.Contains(res) || item.Contains(res2))
                    {
                        MessageBox.Show("Restricted Site Access!", item);
                    }
                }
            }
        
            else { MessageBox.Show("Not Logged In as Parent"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

