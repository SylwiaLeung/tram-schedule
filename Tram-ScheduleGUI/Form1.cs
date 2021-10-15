using System.Windows.Forms;
using System.Data.SQLite;
using System;
using Tram_Schedule.DAL;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule_Controls;
using Tram_Schedule.Models;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        private readonly SQLiteConnection Connection = new SQLiteConnection(@"data source=C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db");
        private readonly DatabaseContext Context = new DatabaseContext();
        private string current;
        private string routeName = string.Empty;
        private readonly IDao<Route> RouteDao;
        private readonly IDao<Tram> TramDao;
        private readonly IDao<TramStop> TramStopDao;
        private readonly RouteControls RouteControls;
        private readonly TramControls TramControls;
        private readonly TramStopControls TramStopControls;

        public Form1()
        {
            InitializeComponent();
            RouteDao = new RouteDao(Context);
            TramDao = new TramDao(Context);
            TramStopDao = new TramStopDao(Context);
            RouteControls = new(RouteDao);
            TramControls = new(TramDao);
            TramStopControls = new(TramStopDao);
        }

        private void BrowseTrams_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            try
            {
                Connection.Open();
                current = "button1";
                TramDao dao = new(Context);
                TramControls tramControls = new(dao);
                var trams = tramControls.ReadAllTramNames();
                listBox1.DataSource = trams;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                Connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            try
            {
                Connection.Open();
                current = "button2";
                var routes = RouteControls.ReadAllRouteNames();
                listBox1.DataSource = routes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                Connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            try
            {
                Connection.Open();
                current = "button3";
                var stops = TramStopControls.ReadAllTramStopNames();
                listBox1.DataSource = stops;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                Connection.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)listBox1.SelectedItem;
            switch (current)
            {
                case "button3":
                    var descriptions = TramStopControls.ReadTramStopDescription(name);
                    listBox2.DataSource = descriptions;
                    break;
                case "button2":
                    var routStops = RouteControls.ReadRouteStops(name);
                    listBox2.DataSource = routStops;
                    break;
                case "button1":
                    var runs = TramControls.ReadTramFirstRun(name);
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
                Connection.Open();
                var routes = RouteControls.ReadAllRouteNames();
                RouteListBox.DataSource = routes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                Connection.Close();
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
                Connection.Open();
                switch (current)
                {
                    case "button4":
                        TramControls.AddNewTram(textBox1.Text, textBox2.Text);
                        MessageBox.Show("Successfully added the new tram!");
                        break;
                    case "button5":
                        TramStopControls.AddNewStop(textBox1.Text, textBox2.Text, routeName);
                        MessageBox.Show("Successfully added the new stop!");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                Connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                DisableChoosingRoute();
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
