using System.Windows.Forms;
using System;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule_Controls;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connection = new(path);
            Context = new();
            RouteControls = new(new RouteDao(Context));
            TramControls = new(new TramDao(Context));
            TramStopControls = new(new TramStopDao (Context));
            pictureBox1.Image = Properties.Resources.kitten;
        }

        private void BrowseTrams_Click(object sender, EventArgs e)
        {
            DisableChoosingRoute();
            DisableFillingData();
            listBox2.DataSource = null;
            try
            {
                Connection.Open();
                current = "button1";
                var trams = TramControls.ReadAllTramNames();
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
            DisableChoosingRoute();
            DisableFillingData();
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
            DisableChoosingRoute();
            DisableFillingData();
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
            if (name == "Papieski")
            {
                pictureBox1.Image = popeTram;
            }
            else if (name == "Wawelski")
            {
                pictureBox1.Image = vintageTram;
            }
            else
            {
                pictureBox1.Image = kitten;
            }

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
            DisableChoosingRoute();
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
                        MessageBox.Show("Successfully added a new tram!");
                        break;
                    case "button5":
                        string routeName = (string)RouteListBox.SelectedItem;
                        TramStopControls.AddNewStop(textBox1.Text, textBox2.Text, routeName);
                        MessageBox.Show("Successfully added a new stop!");
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
    }
}
