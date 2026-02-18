using Common;
using Software.Request.Request_MALAN_PESAGE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hardware.Scale;
using Hardware.Camera;
using Hardware.Printer;

namespace UI_MALAN_PESAGE
{
    public partial class Page_palette : Form
    {
        public float poids;
        public string chemin_photos1;
        public string chemin_photos2;
        public Page_palette()
        {
            InitializeComponent();
        }


        private void Txt_BL_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Txt_BL.Text))
            {

                if (int.TryParse(Txt_BL.Text, out int numeroBL))
                {
                    try
                    {
                        Console.WriteLine($"Recherche du BL numéro : {numeroBL}");
                        Request_specific blRequest = new Request_specific();


                        dataGridView1.DataSource = blRequest.Call_BL(numeroBL);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erreur lors du chargement : " + ex.Message);
                    }
                }
            }
            else
            {

                dataGridView1.DataSource = null;
            }
        }

        private void Btn_prise_mesure_Click_1(object sender, EventArgs e)
        {
            Log_error log_Error = new Log_error();
            // Code pour lancer la prise de mesure
            // Si box check BL coché
            Page_login page_Login = new Page_login();
            // Réccupération de l'opérateur connecté on communique l'username, mais on veut plutôt l'id de l'opérateur
            // On appelle une requete pour récupérer l'id de l'opérateur à partir de son username
            Request_specific path_way = new Request_specific();
            
            Program program = new Program();
            int idOperateurInt = path_way.Id_operateur_from_username(program.id_user);
            Console.WriteLine("Récupération de l'id de l'opérateur à partir de son username : " + program.id_user + " et son numéro d'utilisateur : " + idOperateurInt);

            int numero_palette = 0;
            if (Check_BL.Checked)
            {
                Console.WriteLine("Box check BL cochée, vérification du champ BL...");
                // On vérifie que le champ BL n'est pas vide et on récupère toutes les infos du BL
                int result_BL;
  
                
                int id_pal = 0;
                // TO DO vérifier que le bl est dans la table BL
                if (int.TryParse(Txt_BL.Text,out result_BL))
                {
                    // Ainsi, on peut lancer la prise de mesure avec les infos du BL
                    Console.WriteLine("Lancement de la prise de mesure pour le BL numéro : " + result_BL);
                    try
                    {
                        // Horodatage
                        string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

                        // Création des chemins de sauvegarde
                        
                        string chemin_photos1 = path_way.Path_crator(result_BL, numero_palette, "photo_palette1", timestamp);
                        string chemin_photos2 = path_way.Path_crator(result_BL, numero_palette, "photo_palette2", timestamp);
                        string chemin_ZPL = path_way.Path_crator(result_BL, numero_palette, "ZPL", timestamp);

                        // Recherche des infos du BL
                        (string depLivre, string contact, string adresseLivr, int idAR_int, int nbrColisTheo_int, float poidsTheoNet_int) = path_way.Etiquette_creator(result_BL);


                        // Appel de Scale_manager pour lancer la prise de mesure
                        Scale_manager scale_Manager = new Scale_manager();
                        poids = scale_Manager.Scale_colis("adresse_ip_de_la_balance");

                        // Affichage du poids mesuré dans le label
                        Label_affiche_poids.Text = "Poids mesuré : " + poids + " kg";

                        // Prise des photos de la palette avec camera_manager
                        Camera_manager camera_Manager = new Camera_manager();
                        Console.WriteLine("Debug 1");
                        camera_Manager.Capture_palette(chemin_photos1, chemin_photos2);

                        // Impression de l'étiquette avec les infos du BL et le poids mesuré

                        Printer_manager printer_Manager = new Printer_manager();
                        printer_Manager.Print_Etiquette(chemin_ZPL, result_BL, poids, numero_palette, timestamp,
                        depLivre, contact, adresseLivr, idOperateurInt, idAR_int, nbrColisTheo_int, poidsTheoNet_int
                        , id_pal);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur lors de la prise de mesure");
                        log_Error.Log_Error(ex);
                    }

                }
                // Si pas de numéro de BL, on affiche un message d'erreur
                else
                {
                    // Affichage d'un message d'erreur
                    MessageBox.Show("Veuillez entrer un numéro de BL avant de lancer la prise de mesure.");
                }
            }
            // Si pas de box check BL coché
            else
            {
                // Message d'erreur pour indiquer que la box check BL doit être cochée
                MessageBox.Show("Veuillez cocher la case 'BL' avant de lancer la prise de mesure.");
            }
        }

        private void Label_affiche_poids_Click_1(object sender, EventArgs e)
        {
            // Affichage du poids mesuré dans le label
            Label_affiche_poids.Text = "Poids mesuré : " + poids + " kg";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Check_BL_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}