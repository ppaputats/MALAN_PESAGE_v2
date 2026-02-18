using Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software.Request.Request_MALAN_PESAGE;


namespace UI_MALAN_PESAGE
{
    public partial class Page_main : Form
    {
        public Page_main()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            Request_specific bl = new Request_specific();
            DataTable données = bl.Last_BL();

            if (données != null)
            {
                dataGridView1.DataSource = données;
            }
            else
            {
                MessageBox.Show("Erreur lors de la récupération des données.");
            }
        }

        private void Page_main_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Code pour afficher les données dans le DataGridView
            // On affiche les derniers BL de la table BL de la base de données via Last_Bl
            
            Request_specific bl = new Request_specific();
            dataGridView1.DataSource = bl.Last_BL();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code pour allumer ou éteindre le voyant en fonction du status
            //if

        }

        private void Btn_periph_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Initialisation (Le constructeur cherche et lit le fichier Port.json ici)
                var manager = new Hardware_manager();

                // 2. Utilisation
                string softwareKey = "Capteur_Pression_01";

                if (manager.TryGetPort(softwareKey, out string hardwarePort))
                {
                    string status = manager.GetStatus(softwareKey);
                    Console.WriteLine($"Clé : {softwareKey} -> Port : {hardwarePort} (Status: {status})");
                }
                else
                {
                    Console.WriteLine($"La clé '{softwareKey}' n'existe pas dans le fichier de config.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erreur : Fichier manquant ! {ex.Message}");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Erreur de formatage : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur imprévue est survenue : {ex.Message}");
            }
        }

        private void Btn_palette_Click(object sender, EventArgs e)
        {
            Page_palette page = new Page_palette();
            page.Show();

            // Fermeture de la page principale
            this.Hide();
            return;
        }
    }
}
