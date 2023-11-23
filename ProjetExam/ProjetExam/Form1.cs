using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;



        
namespace ProjetExam
{
    public partial class Form1 : Form
    {



        private void afficherVehicule(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT nom, note_eco FROM vehicules";
            MySqlDataReader reader = command.ExecuteReader();



            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox1.DisplayMember = "Nom";
            comboBox1.ValueMember = "Note_eco";
            comboBox1.DataSource = dt;



        }


        private void afficherEnergie(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT nom, Note_eco_energie FROM energie";
            MySqlDataReader reader = command.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox2.DisplayMember = "Nom";
            comboBox2.ValueMember = "Note_eco_energie";
            comboBox2.DataSource = dt;

        }

        private void afficherKilometrage(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM kilometrage";
            MySqlDataReader reader = command.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox3.DisplayMember = "Nom";
            comboBox3.ValueMember = "Note_eco_km";
            comboBox3.DataSource = dt;

        }

        private void afficherAnnee(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM annee";
            MySqlDataReader reader = command.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox4.DisplayMember = "Nom";
            comboBox4.ValueMember = "Note_eco_annee";
            comboBox4.DataSource = dt;

        }

        private void afficherPassager(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM passager";
            MySqlDataReader reader = command.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox5.DisplayMember = "Nombre";
            comboBox5.ValueMember = "Pourcentage";
            comboBox5.DataSource = dt;

        }


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "projetcsharp"
            };
            try
            {
                // Tenter d'établir la connexion
                MySqlConnection connection = new MySqlConnection(connectionStringBuilder.ToString());
                connection.Open();
                label8.Text = "Type de véhicule :";
                label9.Text = "Type d'énergie :";
                label10.Text = "Kilométrage :";
                label11.Text = "Année :";
                label12.Text = "Nb de passager :";
                label13.Visible = false;
                label14.Visible = false;

                label2.Text = "Veuillez choisir vos données de votre véhicule";
                afficherVehicule(connection);
                afficherEnergie(connection);
                afficherKilometrage(connection);
                afficherAnnee(connection);
                afficherPassager(connection);




            }
            catch (MySqlException except)
            {
                label2.Text = $"{except}";
            }
            label1.Text = "Bienvenue sur le site Green Bank !";
            label1.ForeColor = Color.Green;
        }

        public double calculNoteFinal ()
        {
            double resultNote = Convert.ToDouble(comboBox1.SelectedValue) + Convert.ToDouble(comboBox2.SelectedValue) + Convert.ToDouble(comboBox3.SelectedValue) + Convert.ToDouble(comboBox4.SelectedValue);
            double result;
            double pourcent = Convert.ToDouble(comboBox5.SelectedValue);
            double taux;
            if (resultNote <= 10)
            {
                taux = 3;
            }
            else if (resultNote <= 15)
            {
                taux = 2.74;
            }
            else if (resultNote <= 25)
            {
                taux = 2.52;
            }
            else if (resultNote <= 33)
            {
                taux = 2.10;
            }
            else
            {
                taux = 1.85;
            }

            result = taux + pourcent;
            return Math.Round(result, 2);
        }

        private double calculNote()
        {
            double resultNote = Convert.ToDouble(comboBox1.SelectedValue) + Convert.ToDouble(comboBox2.SelectedValue) + Convert.ToDouble(comboBox3.SelectedValue) + Convert.ToDouble(comboBox4.SelectedValue);
            return resultNote;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            label13.Visible= true;
            label13.Text = $"L'emprunteur devra donc payer {calculNoteFinal()}% de frais pour cet emprunt \n car le véhicule va rouler " + comboBox3.Text + "/an pour " + comboBox5.Text + " personne(s)";
            label14.Visible= true;
            label14.Text = $"Note eco total : {calculNote()}/40"; 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                label3.Text = "Votre note eco : " + comboBox1.SelectedValue.ToString();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                label4.Text = "Votre note eco : " + comboBox2.SelectedValue.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                label5.Text = "Votre note eco : " + comboBox3.SelectedValue.ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                label6.Text = "Votre note eco : " + comboBox4.SelectedValue.ToString();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1)
            {
                label7.Text = "Pourcentage : " + comboBox5.SelectedValue.ToString() + " %";
            }
        }

       
    }

}

