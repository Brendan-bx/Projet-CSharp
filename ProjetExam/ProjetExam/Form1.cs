using MySql.Data.MySqlClient;
using System.Data;



        
namespace ProjetExam
{
    public partial class Form1 : Form
    {

        private void recupDatabase(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM vehicules";
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            string note = reader.GetString("Note eco");
            label3.Text = note;

            
        }
        private void afficherVehicule(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM vehicules";
            MySqlDataReader reader = command.ExecuteReader();



            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox1.DisplayMember = "Nom";
            comboBox1.DataSource = dt;



        }


        private void afficherEnergie(MySqlConnection connection)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM energie";
            MySqlDataReader reader = command.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox2.DisplayMember = "Nom";
            comboBox2.ValueMember = "Note eco";
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
            comboBox3.ValueMember = "Note eco";
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
            comboBox4.ValueMember = "Note eco";
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
                label2.Text = "Veuillez choisir vos données de votre véhicule";
                afficherVehicule(connection);
                afficherEnergie(connection);
                afficherKilometrage(connection);
                afficherAnnee(connection);
                afficherPassager(connection);
                recupDatabase(connection);



            }
            catch (MySqlException except)
            {
                label2.Text = $"{except}";
            }
            label1.Text = "Bienvenue sur le site Green Bank !";
            label1.ForeColor = Color.Green;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }

}

