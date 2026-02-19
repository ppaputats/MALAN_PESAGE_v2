/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : UI_MALAN_PESAGE
 *  Fichier     : Page_login.cs
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
            if (Login_request())
            {
            }
            else
            {
                MessageBox.Show("Erreur de conexion");
            }
        }

        private bool Login_request()
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
                return false;
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
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Connexion réussie en mode admin au menu utilisateur");

                        // Ouverture de la page utilisateur : Page_main
                        Page_main page_Main = new Page_main();
                        page_Main.Show();

                        // Stockage utilisateur
                        Program.id_user = username;
                        // Fermeture de la page de connexion
                        this.Hide();
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Connexion réussie en mode utilisateur au menu utilisateur");

                    // Ouverture de la page utilisateur : Page_main
                    Page_main page_Main = new Page_main();
                    page_Main.Show();

                    // Stockage utilisateur
                    Program.id_user = username;

                    // Fermeture de la page de connexion
                    this.Hide();
                    return true;
                }

            }
        }
        private void CheckBx_Admin_CheckedChanged(object sender, EventArgs e)
        {

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

        private void Label_username_Click(object sender, EventArgs e)
        {

        }
    }
}
