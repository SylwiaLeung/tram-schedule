using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using Tram_Schedule.DAL;
using Tram_Schedule.DAL.DAO;
using Tram_Schedule.Models;
using Tram_Schedule_Controls;

namespace Tram_ScheduleGUI
{
    public partial class Form1 : Form
    {
        private const string _path = @"data source=C:\Users\CTNW74\Desktop\projects\tram-schedule\Tram-Schedule\bin\Debug\net5.0\TramTable.db";
        private readonly Bitmap _popeTram = Properties.Resources.mdo_5153080;
        private readonly Bitmap _vintageTram = Properties.Resources.old_vintage_tram_old_vintage_tram_cracow_poland_107523067;
        private readonly Bitmap _kitten = Properties.Resources.kitten;
        private readonly SQLiteConnection _connection;
        private readonly DatabaseContext _context;
        private readonly TramDao _tramDao;
        private readonly TramStopDao _tramStopDao;
        private readonly RouteDao _routeDao;
        private readonly RouteControls _routeControls;
        private readonly TramControls _tramControls;
        private readonly TramStopControls _tramStopControls;
        private readonly BindingSource _comboBoxBinding;
        private readonly BindingSource _listBoxBinding;
        private string _current;

        public Form1()
        {
            InitializeComponent();
            _connection = new(_path);
            _context = new();
            _routeDao = new RouteDao(_context);
            _routeControls = new(_routeDao);
            _tramDao = new TramDao(_context);
            _tramControls = new(_tramDao);
            _tramStopDao = new TramStopDao(_context);
            _tramStopControls = new(_tramStopDao);
            pictureBox1.Image = Properties.Resources.kitten;
            _comboBoxBinding = new();
            _listBoxBinding = new();
        }

        private void BrowseTrams_Click(object sender, EventArgs e)
        {
            DisableChoosingRoute();
            DisableFillingData();
            try
            {
                _connection.Open();
                _current = "button1";
                SetUpTramBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisableChoosingRoute();
            DisableFillingData();
            try
            {
                _connection.Open();
                _current = "button2";
                SetUpRouteBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisableChoosingRoute();
            DisableFillingData();
            try
            {
                _connection.Open();
                _current = "button3";
                SetUpStopBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void AddTram_Click(object sender, EventArgs e)
        {
            _current = "button4";
            EnableFillingData();
            DisableChoosingRoute();
            textBox2.Text = "First run date (dd-MM-yyy)";
        }

        private void AddStop_Click(object sender, EventArgs e)
        {
            RouteListBox.DataSource = null;
            _current = "button5";
            EnableFillingData();
            EnableChoosingRoute();
            textBox2.Text = "Description of the stop";
            try
            {
                _connection.Open();
                var routes = _routeControls.ReadAllRouteNames();
                RouteListBox.DataSource = routes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
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
                _connection.Open();
                switch (_current)
                {
                    case "button4":
                        _tramControls.AddNewTram(textBox1.Text, textBox2.Text);
                        MessageBox.Show("Successfully added a new tram!");
                        break;
                    case "button5":
                        string routeName = (string)RouteListBox.SelectedItem;
                        _tramStopControls.AddNewStop(textBox1.Text, textBox2.Text, routeName);
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
                _connection.Close();
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
            _comboBoxBinding.DataSource = null;
            _listBoxBinding.DataSource = null;
            _comboBoxBinding.DataSource = _tramDao.ReadAll();
            _listBoxBinding.DataSource = _comboBoxBinding;
            _listBoxBinding.DataMember = "FirstRun";
            comboBox1.DataSource = _comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = _listBoxBinding;
        }

        private void SetUpRouteBindings()
        {
            _comboBoxBinding.DataSource = null;
            _listBoxBinding.DataSource = null;
            _comboBoxBinding.DataSource = _routeDao.ReadAll();
            _listBoxBinding.DataSource = _comboBoxBinding;
            _listBoxBinding.DataMember = "StopsList";
            comboBox1.DataSource = _comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = _listBoxBinding;
            listBox3.DisplayMember = "Name";
        }

        private void SetUpStopBindings()
        {
            _comboBoxBinding.DataSource = null;
            _listBoxBinding.DataSource = null;
            _comboBoxBinding.DataSource = _tramStopDao.ReadAll();
            _listBoxBinding.DataSource = _comboBoxBinding;
            _listBoxBinding.DataMember = "Description";
            comboBox1.DataSource = _comboBoxBinding;
            comboBox1.DisplayMember = "Name";
            listBox3.DataSource = _listBoxBinding;
        }

        private void SetUpTramPicture()
        {
            if (comboBox1.SelectedItem != null)
            {
                Tram tram = (Tram)comboBox1.SelectedItem;
                string name = tram.Name;
                if (name == "PapaTram")
                {
                    pictureBox1.Image = _popeTram;
                }
                else if (name == "VintageTram")
                {
                    pictureBox1.Image = _vintageTram;
                }
                else
                {
                    pictureBox1.Image = _kitten;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_current == "button1") SetUpTramPicture();
        }
    }
}
