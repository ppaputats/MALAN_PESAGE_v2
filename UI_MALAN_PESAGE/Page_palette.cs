/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : UI_MALAN_PESAGE
 *  Fichier     : Page_main.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Fonctions spécifiques à la page de principale
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *      - 19/02/26 : Ajout de toutes les fonctionnalités necessaires - Paul Paput
 *
 * ================================================================================================ */


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
using System.Runtime.Remoting.Messaging;
using System.IO;

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
                        Request_specific blRequest = new Request_specific();
                        dataGridView1.DataSource = blRequest.Call_BL(numeroBL);
                    }
                    catch (Exception ex)
                    {
                        Log_error log_Error = new Log_error();
                        log_Error.Log_Error(ex);
                        MessageBox.Show("Erreur lors du chargement : " + ex.Message);
                    }
                }
            }
            else
            {
                // Si vide
                dataGridView1.DataSource = null;
            }
        }

        private void Btn_prise_mesure_Click_1(object sender, EventArgs e)
        {
            Prise_mesure_palette();
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

        private bool Prise_mesure_palette()
        {
            Log_error log_Error = new Log_error();
            // Code pour lancer la prise de mesure
            // Si box check BL coché
            Page_login page_Login = new Page_login();
            // Réccupération de l'opérateur connecté on communique l'username, mais on veut plutôt l'id de l'opérateur
            // On appelle une requete pour récupérer l'id de l'opérateur à partir de son username
            Request_specific path_way = new Request_specific();

            if (Check_BL.Checked)
            {
                Console.WriteLine("Box check BL cochée, vérification du champ BL...");
                // On vérifie que le champ BL n'est pas vide et on récupère toutes les infos du BL
                int result_BL;

                // TO DO vérifier que le bl est dans la table BL
                if (int.TryParse(Txt_BL.Text, out result_BL))
                {
                    // Ainsi, on peut lancer la prise de mesure avec les infos du BL
                    Console.WriteLine("Lancement de la prise de mesure pour le BL numéro : " + result_BL);
                    try
                    {
                        Console.WriteLine("Resultat verif_bl :" + path_way.verif_bl(result_BL));
                        if (path_way.verif_bl(result_BL))
                        {
                            Hardware_call(result_BL);
                        }
                        else
                        {
                            Exception ex = new Exception("Le BL :" + result_BL + " n'existe pas");
                            log_Error.Log_Error(ex);
                            MessageBox.Show("BL non existant");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur lors de la prise de mesure");
                        log_Error.Log_Error(ex);
                        return false;
                    }

                }
                // Si pas de numéro de BL, on affiche un message d'erreur
                else
                {
                    // Affichage d'un message d'erreur
                    Exception ex = new Exception("Pas de numéro de BL");
                    log_Error.Log_Error(ex);
                    MessageBox.Show("Veuillez entrer un numéro de BL avant de lancer la prise de mesure.");
                    return false;
                }
            }
            // Si pas de box check BL coché
            else
            {
                // Message d'erreur pour indiquer que la box check BL doit être cochée
                Exception ex = new Exception("Check case non cochée");
                log_Error.Log_Error(ex);
                MessageBox.Show("Veuillez cocher la case 'BL' avant de lancer la prise de mesure.");
                return false;
            }
            return true;
        }

        public bool Hardware_call(int result_BL)
        {
            Request_specific path_way = new Request_specific();

            // Récupération de l'id_operateur
            int idOperateurInt = path_way.Id_operateur_from_username(Program.id_user);

            // Calcul du numéro de palette en fonction du nombre de palettes déjà créées pour ce BL
            int nombre_palettes = path_way.Compte_colis(result_BL);

            // Horodatage
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

            // Création des chemins de sauvegarde

            string chemin_photos1 = path_way.Path_crator(result_BL, nombre_palettes, "PNG1", timestamp);
            string chemin_photos2 = path_way.Path_crator(result_BL, nombre_palettes, "PNG2", timestamp);
            string chemin_ZPL = path_way.Path_crator(result_BL, nombre_palettes, "ZPL", timestamp);

            // Recherche des infos du BL
            (string depLivre, string contact, string adresseLivr, int idAR_int, int nbrColisTheo_int, float poidsTheoNet_int, int id_pal_colis) = path_way.Etiquette_creator(result_BL);
            Console.WriteLine("Infos du BL récupérées : " + depLivre + ", " + contact + ", " + adresseLivr + ", " + idAR_int + ", " + nbrColisTheo_int + ", " + poidsTheoNet_int + "," + id_pal_colis);

            // Appel de Scale_manager pour lancer la prise de mesure
            Scale_manager scale_Manager = new Scale_manager();
            poids = scale_Manager.Scale_colis("adresse_ip_de_la_balance");

            // Affichage du poids mesuré dans le label
            Label_affiche_poids.Text = "Poids mesuré : " + poids + " kg";

            // Prise des photos de la palette avec camera_manager
            Camera_manager camera_Manager = new Camera_manager();
            Console.WriteLine("############################################");

            camera_Manager.Capture_palette(chemin_photos1, chemin_photos2);
            Console.WriteLine("Chemin de la photo 1 : " + chemin_photos1);
            Console.WriteLine("Chemin de la photo 2 : " + chemin_photos2);
            Console.WriteLine("############################################");
            // Enregistrement des infos dans la base de données avec Insert_palette puis insert_Photo
            int type_pal_colis = 0;
            int tare_pal_colis = 0;
            if(path_way.Insert_palette(id_pal_colis, result_BL, type_pal_colis, tare_pal_colis, poids, idOperateurInt, chemin_ZPL, timestamp, nombre_palettes))
            {
            }
            else
            {
                Log_error log_Error = new Log_error();
                Exception ex = new Exception("Erreur lors de l'insertion de la palette : " + nombre_palettes + " du BL : "  + result_BL);
                log_Error.Log_Error(ex);
                MessageBox.Show("Erreur lors de l'insertion des infos de la palette dans la base de données.");
                return false;
            }




            if (path_way.Insert_photo( id_pal_colis, chemin_photos1, chemin_photos2))
            {
            }
            else
            {
                Log_error log_Error = new Log_error();
                Exception ex = new Exception("Erreur lors de l'insertion des photos de la palette : " + id_pal_colis + " aux chemins : " + chemin_photos1 + " et : " + chemin_photos2);
                log_Error.Log_Error(ex);
                Console.WriteLine("Erreur lors de l'insertion des chemins des photos dans la base de données.");
                return false;
            }

            // Impression de l'étiquette avec les infos du BL et le poids mesuré

            Printer_manager printer_Manager = new Printer_manager();
            printer_Manager.Print_Etiquette(chemin_ZPL, result_BL, poids, nombre_palettes, timestamp,
            depLivre, contact, adresseLivr, idOperateurInt, idAR_int, nbrColisTheo_int, poidsTheoNet_int
            , id_pal_colis);
            return true;
        }
        


    }
}