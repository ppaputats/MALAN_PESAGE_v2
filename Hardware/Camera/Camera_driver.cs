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
using System.IO; 
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
                // Création fictive d'une image et sauvegarde à l'emplacement spécifié
                Console.WriteLine("---------------------");
                Console.WriteLine("Tentative de capture d'image sur le port " + Port_COM + " et sauvegarde à : " + Save_path);
                Creer_image_fictive(Save_path);
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
        /// <summary>
        /// Crée un fichier PNG valide (1x1 pixel blanc) sans utiliser System.Drawing
        /// pour éviter les erreurs de référence manquante.
        /// </summary>
        public void Creer_image_fictive(string nom_fichier_seul)
        {
            // Définition du dossier de stockage
            string path_photos = @"C:\Users\Paulp\Documents\C#\Proto2\UI_MALAN_PESAGE\Stockage_Photo";

            // CORRECTION 1 : On combine pour avoir le chemin ABSOLU
            string chemin_complet = Path.Combine(path_photos, nom_fichier_seul);

            try
            {
                // CORRECTION 2 : On cherche le dossier du chemin COMPLET
                string dossier = Path.GetDirectoryName(chemin_complet);

                // On vérifie que le dossier existe (Stockage_Photo), sinon on le crée
                if (!string.IsNullOrEmpty(dossier) && !Directory.Exists(dossier))
                {
                    Directory.CreateDirectory(dossier);
                }

                // 2. Signature binaire d'un PNG blanc 1x1 pixel (Base64)
                string base64Png = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+ip1sAAAAASUVORK5CYII=";
                byte[] imageBytes = Convert.FromBase64String(base64Png);

                // CORRECTION 3 : On écrit dans le chemin COMPLET
                File.WriteAllBytes(chemin_complet, imageBytes);

                Console.WriteLine("Image fictive générée : " + chemin_complet);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la création de l'image fictive : " + ex.Message);
                log_Error.Log_Error(ex);
            }
        }
    }
}
