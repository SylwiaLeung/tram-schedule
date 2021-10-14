using System.Windows.Forms;
using System.Data.SQLite;
using System;
using Tram_Schedule.DAL;
using Tram_Schedule.DAL.DAO;
using System.Collections.Generic;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        SQLiteConnection connection = new SQLiteConnection(@"data source=C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db");
        DatabaseContext context = new DatabaseContext();
        string current;
        string routeName = string.Empty;

        public Form1()
        {
            InitializeComponent();
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
                MessageBox.Show($"Connection error: {ex.Message}");
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
                MessageBox.Show($"Connection error: {ex.Message}");
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
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void AddTram_Click(object sender, EventArgs e)
        {
            current = "button4";
            EnableFillingData();
            textBox2.Text = "First run date (dd-MM-yyy)";
        }

        private void AddStop_Click(object sender, EventArgs e)
        {
            RouteListBox.DataSource = null;
            current = "button5";
            EnableFillingData();
            EnableChoosingRoute();
            textBox2.Text = "Description of the stop";
            try
            {
                connection.Open();
                RouteDao dao = new(context);
                var routes = dao.ReadAllRouteNames();
                RouteListBox.DataSource = routes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (CheckIfFieldIsEmpty(textBox1))
            {
                MessageBox.Show("The name field cannot be empty.");
                return;
            }
            try
            {
                connection.Open();
                switch (current)
                {
                    case "button4":
                        TramDao dao = new(context);
                        try
                        {
                            dao.AddNewTram(textBox1.Text, textBox2.Text);
                            MessageBox.Show("Successfully added the new tram!");
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }
                        finally
                        {
                            DisableFillingData();
                        }
                        break;
                    case "button5":
                        TramStopDao stopDao = new(context);
                        try
                        {
                            stopDao.AddNewStop(textBox1.Text, textBox2.Text, routeName);
                            MessageBox.Show("Successfully added the new stop!");
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }
                        finally
                        {
                            DisableChoosingRoute();
                            DisableFillingData();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Try again; {ex.Message}");
            }
            finally
            {
                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                DisableFillingData();
            }
        }

        private void EnableFillingData()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            Submit.Enabled = true;
        }

        private void DisableFillingData()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            Submit.Enabled = false;
        }
        private void EnableChoosingRoute()
        {
            RouteListBox.Enabled = true;
        }
        private void DisableChoosingRoute()
        {
            RouteListBox.Enabled = false;
        }

        private bool CheckIfFieldIsEmpty(TextBox box)
        {
            return box.Text == string.Empty;
        }

        private void RemoveText(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void RouteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            routeName = (string)RouteListBox.SelectedItem;
        }
    }
}
