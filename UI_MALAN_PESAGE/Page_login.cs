/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : Software/Requete/Login
 *  Fichier     : Request.login.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Fonctions spécifiques à la page de connexion des utilisateurs
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using Common;
using Hardware;
using Software.Request.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_MALAN_PESAGE
{
    public partial class Page_login : Form
    {
        bool isAdmin = false;
        public Page_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_close_Click(object sender, EventArgs e)
        {

        }

        private void Btn_connection_Click(object sender, EventArgs e)
        {
            Log_error log_Error = new Log_error();
            Request_login request_Login = new Request_login();

            string username = Txt_username.Text;
            string password = Txt_password.Text;
            bool admin_pass = false;
            bool login_pass = false;
            (login_pass, admin_pass) = request_Login.Test_connection(username, password);
            if (login_pass == false)
            {
                Console.WriteLine("Connexion impossible pour cet utilisateur");
            }
            else
            {
                // On vérifie si l'utilisateur est admin
                if (admin_pass == true)
                {
                    // On vérifie si l'utilisateur veut entrer en mode admin ou utilisateur
                    if (isAdmin == true)
                    {
                        Console.WriteLine("Connexion réussie en mode admin au menu admin");
                    }
                    else
                    {
                        Console.WriteLine("Connexion réussie en mode admin au menu utilisateur");
                        
                        // Ouverture de la page utilisateur : Page_main
                        Page_main page_Main = new Page_main();
                        page_Main.Show();

                        // Stockage utilisateur
                        Program program = new Program();
                        program.id_user = username;
                        // Fermeture de la page de connexion
                        this.Hide();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Connexion réussie en mode utilisateur au menu utilisateur");

                    // Ouverture de la page utilisateur : Page_main
                    Page_main page_Main = new Page_main();
                    page_Main.Show();
                    
                    // Stockage utilisateur
                    Program program = new Program();
                    program.id_user = username;

                    // Fermeture de la page de connexion
                    this.Hide();
                    return;
                }

            }
        }


        private void CheckBx_Admin_CheckedChanged(object sender, EventArgs e)
        {
            //// Test
            //Log_error logger = new Log_error();

            //Console.WriteLine("Début du test de log...");

            //try
            //{
            //    // 2. On provoque une erreur volontaire
            //    int a = 10;
            //    int b = 0;
            //    int result = a / b;
            //}
            //catch (Exception ex)
            //{
            //    // 3. Appel de ta méthode pour enregistrer l'erreur
            //    Console.WriteLine("Une erreur est survenue, enregistrement dans l'Event Viewer...");
            //    logger.Log_Error(ex);
            //}
            //Console.WriteLine("Test terminé. Appuyez sur une touche pour quitter.");
            //// Test

            if (CheckBx_Admin.Checked)
            {
                isAdmin = true;
                Console.WriteLine("Mode admin activé");
            }
            else
            {
                isAdmin = false;
                Console.WriteLine("Mode admin désactivé");
            }
            
        }

        private void Label_password_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Txt_password_TextChanged(object sender, EventArgs e)
        {
        }

        public void Txt_username_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
