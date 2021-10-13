using System.Windows.Forms;
using System.Data.SQLite;
using System;
using System.IO;
using Tram_Schedule.DAL;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        SQLiteConnection connection = new SQLiteConnection(@"data source=C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db");
        DatabaseContext context = new DatabaseContext();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                TramDao dao = new(context);
                List<Tram> trams = dao.ReadAll();
                dataGridView1.DataSource = trams;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection", ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                RouteDao dao = new(context);
                List<Route> routes = dao.ReadAll();
                dataGridView1.DataSource = routes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection", ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
