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

namespace PraktikumWeek8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection sqlConnect = new MySqlConnection("server=localhost;uid=root;pwd=;database=premier_league"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;

        private void Form1_Load(object sender, EventArgs e)
        {
            LabelManagerTM.Text = "";
            LabelManagerTR.Text = "";
            LabelCaptainTM.Text = "";
            LabelCaptainTR.Text = "";
            LabelCapacity.Text = "";
            LabelStadium.Text = "";
            sqlConnect.Open();
            DataTable dtPlayerTM = new DataTable();
            //copy mulai sini
            sqlQuery = "SELECT team_name as 'Nama Tim', manager_name as 'Nama Manager', player_name as 'Nama Captain', capacity, home_stadium, city FROM manager, team, player WHERE team.manager_id = manager.manager_id and player.player_id = team.captain_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayerTM);
            ComboBoxTM.DataSource = dtPlayerTM;
            ComboBoxTM.DisplayMember = "Nama Tim";

            DataTable dtPlayerTR = new DataTable();
            //copy mulai sini
            sqlQuery = "SELECT team_name as 'Nama Tim', manager_name as 'Nama Manager', player_name as 'Nama Captain', capacity, home_stadium, city FROM manager, team, player WHERE team.manager_id = manager.manager_id and player.player_id = team.captain_id";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayerTR); // sampai sini
            ComboBoxTR.DataSource = dtPlayerTR;
            ComboBoxTR.DisplayMember = "Nama Tim";
        }
        
        private void ComboBoxTR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxTR.ValueMember = "Nama Manager";
            LabelManagerTR.Text = ComboBoxTR.SelectedValue.ToString();
            ComboBoxTR.ValueMember = "Nama Captain";
            LabelCaptainTR.Text = ComboBoxTR.SelectedValue.ToString();
            ComboBoxTR.ValueMember = "capacity";
            LabelCapacity.Text = ComboBoxTR.SelectedValue.ToString();
            ComboBoxTR.ValueMember = "home_stadium";
            string Stadium = ComboBoxTR.SelectedValue.ToString();
            ComboBoxTR.ValueMember = "city";
            string City = ComboBoxTR.SelectedValue.ToString();
            LabelStadium.Text = Stadium + ", " + City;
        }

        private void ComboBoxTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxTM.ValueMember = "Nama Manager";
            LabelManagerTM.Text = ComboBoxTM.SelectedValue.ToString();
            ComboBoxTM.ValueMember= "Nama Captain";
            LabelCaptainTM.Text = ComboBoxTM.SelectedValue.ToString();
            
        }
    }
}
