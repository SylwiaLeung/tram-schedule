using System.Windows.Forms;
using System;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule_Controls;
using Tram_Schedule.Models;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connection = new(path);
            Context = new();
            RouteDao = new RouteDao(Context);
            RouteControls = new(RouteDao);
            TramDao = new TramDao(Context);
            TramControls = new(TramDao);
            TramStopDao = new TramStopDao(Context);
            TramStopControls = new(TramStopDao);
            pictureBox1.Image = Properties.Resources.kitten;
            routes = RouteDao.ReadAll();
            stops = TramStopDao.ReadAll();
            trams = TramDao.ReadAll();
            comboBoxBinding = new();
            listBoxBinding = new();
        }

        private void BrowseTrams_Click(object sender, EventArgs e)
        {
            DisableChoosingRoute();
            DisableFillingData();
            try
            {
                Connection.Open();
                current = "button1";
                SetUpTramBindings();
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
            try
            {
                Connection.Open();
                current = "button2";
                SetUpRouteBindings();
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
            try
            {
                Connection.Open();
                current = "button3";
                SetUpStopBindings();
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

        private void SetUpTramBindings()
        {
            comboBoxBinding.DataSource = null;
            listBoxBinding.DataSource = null;
            comboBoxBinding.DataSource = TramDao.ReadAll();
            listBoxBinding.DataSource = comboBoxBinding;
            listBoxBinding.DataMember = "FirstRun";
            comboBox1.DataSource = comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = listBoxBinding;
        }

        private void SetUpRouteBindings()
        {
            comboBoxBinding.DataSource = null;
            listBoxBinding.DataSource = null;
            comboBoxBinding.DataSource = routes;
            listBoxBinding.DataSource = comboBoxBinding;
            listBoxBinding.DataMember = "StopsList";
            comboBox1.DataSource = comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = listBoxBinding;
            listBox3.DisplayMember = "Name";
        }

        private void SetUpStopBindings()
        {
            comboBoxBinding.DataSource = null;
            listBoxBinding.DataSource = null;
            comboBoxBinding.DataSource = stops;
            listBoxBinding.DataSource = comboBoxBinding;
            listBoxBinding.DataMember = "Description";
            comboBox1.DataSource = comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = listBoxBinding;
        }

        private void SetUpTramPicture()
        {
            if (comboBox1.SelectedItem != null)
            {
                Tram tram = (Tram)comboBox1.SelectedItem;
                string name = tram.Name;
                if (name == "PapaTram")
                {
                    pictureBox1.Image = popeTram;
                }
                else if (name == "VintageTram")
                {
                    pictureBox1.Image = vintageTram;
                }
                else
                {
                    pictureBox1.Image = kitten;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (current == "button1") SetUpTramPicture();
        }
    }
}
