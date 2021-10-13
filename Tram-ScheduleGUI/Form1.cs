using System.Windows.Forms;
using System.Data.SQLite;
using System;
using Tram_Schedule.DAL;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;
using System.Collections.Generic;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        SQLiteConnection connection = new SQLiteConnection(@"data source=C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db");
        DatabaseContext context = new DatabaseContext();
        string current;

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BrowseTrams_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            try
            {
                connection.Open();
                current = "button1";
                TramDao dao = new(context);
                var trams = dao.ReadAllTramNames();
                listBox1.DataSource = trams;
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
            listBox2.DataSource = null;
            try
            {
                connection.Open();
                current = "button2";
                RouteDao dao = new(context);
                var routes = dao.ReadAllRouteNames();
                listBox1.DataSource = routes;
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

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            try
            {
                connection.Open();
                current = "button3";
                TramStopDao dao = new(context);
                var stops = dao.ReadAllTramStopNames();
                listBox1.DataSource = stops;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string name = (string)listBox1.SelectedItem;
                switch (current)
                {
                    case "button3":
                        TramStopDao dao = new(context);
                        var descriptions = dao.ReadTramStopDescription(name);
                        listBox2.DataSource = descriptions;
                        break;
                    case "button2":
                        RouteDao routeDao = new(context);
                        var routStops = routeDao.ReadRouteStops(name);
                        listBox2.DataSource = routStops;
                        break;
                    case "button1":
                        TramDao tramDao = new(context);
                        var runs = tramDao.ReadTramFirstRun(name);
                        listBox2.DataSource = runs;
                        break;
                    default:
                        break;
                }

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
        private void AddTram_Click(object sender, EventArgs e)
        {

        }

        private void AddStop_Click(object sender, EventArgs e)
        {

        }
    }
}
