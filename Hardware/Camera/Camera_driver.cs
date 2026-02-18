/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Camera
 *  Fichier     : Camera_driver.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Driver de la caméra pour le projet MALAN_PESAGE
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */


using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.Camera
{
    /// <summary>
    /// Fonctions : Gère les connexions et les commandes bas niveau pour les caméras
    /// Champs : 
    /// Méthodes : Camera_connect, Camera_disconnect, Camera_capture_image
    /// </summary>
    public class Camera_driver
    {
        Log_error log_Error = new Log_error();
        /// <summary>   
        /// Fonction : Tente de se connecter à une caméra via un port COM spécifié
        /// <summary>
        public bool Camera_connect(string Port_COM)
        {

            // TO DO : Implémenter la connexion à la caméra via le port COM
            try
            {
                Console.WriteLine("Tentative de connexion à la caméra sur le port " + Port_COM + "...");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la connexion à la caméra sur le port {Port_COM} : {ex.Message}");
                log_Error.Log_Error(ex);
                return false;
            }
        }

        public bool Camera_disconnect(string Port_COM)
        {
            // TO DO : Implémenter la déconnexion à la caméra via le port COM
            try
            {
                Console.WriteLine("Tentative de déconnexion à la caméra sur le port " + Port_COM + "...");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la déconnexion à la caméra sur le port {Port_COM} : {ex.Message}");
                log_Error.Log_Error(ex);
                return false;
            }
        }

        public bool Camera_capture_image(string Port_COM, string Save_path)
        {
            // TO DO : Implémenter la capture d'image à partir de la caméra connectée via le port COM
            // et sauvegarder l'image à l'emplacement spécifié
            try
            {
                Console.WriteLine("Tentative de capture sur le port " + Port_COM + " et sauvegarde à : " + Save_path);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la capture d'image sur le port " + Port_COM + " et sauvegarde à : " + Save_path);
                log_Error.Log_Error(ex);
                return false;
            }
        }
    }
}
