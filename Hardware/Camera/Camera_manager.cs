/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Camera
 *  Fichier     : Camera_manager.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Manager de la caméra pour le projet MALAN_PESAGE, responsable de la gestion globale 
 *  de chaque caméra, de l'initialisation à la capture d'images en passant par la configuration
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using System;
using System.Collections.Generic;
using System.Text;
using Hardware.Camera;
using Common;

namespace Hardware.Camera
{
    /// <summary>
    /// Fonctions : Gère les connexions et les commandes haut niveau pour les caméras
    /// Champs : 
    /// Méthodes : 
    /// </summary>
    public class Camera_manager
    {

        public void Capture_colis(string Save_path)
        {
            Hardware_manager Hardware_manager = new Hardware_manager();
            Camera_driver camera_driver = new Camera_driver();
            Log_error log_Error = new Log_error();
            try
            {
                if (!Hardware_manager.TryGetPort("Camera_colis", out string port) || port is null)
                {
                    Exception ex = new Exception("Port : " + port + " de la caméra colis non trouvé");
                    log_Error.Log_Error(ex);
                }

                string Port_cam_colis = port;

                Console.WriteLine($"Tentative de capture d'image au port {Port_cam_colis}");
                if(camera_driver.Camera_connect(Port_cam_colis))
                {
                    if(camera_driver.Camera_capture_image(Port_cam_colis, Save_path))
                    {
                        if(camera_driver.Camera_disconnect(Port_cam_colis))
                        {
                        }
                    }
                }
                
                Console.WriteLine(Port_cam_colis + " : Image capturée et sauvegardée à " + Save_path);
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
            }
        }

        public void Capture_palette(string Save_path1, string Save_path2)
        {
            Hardware_manager Hardware_manager = new Hardware_manager();
            Camera_driver camera1_driver = new Camera_driver();
            Camera_driver camera2_driver = new Camera_driver();
            Log_error log_Error = new Log_error();
            try
            {
                // On récupère le port de la caméra 1
                if (!Hardware_manager.TryGetPort("Camera_palette_1", out string port1) || port1 is null)
                {
                    Exception ex = new Exception("Port : " + port1 + " de la caméra colis non trouvé");
                    log_Error.Log_Error(ex);
                }

                string Port_cam_palette_1 = port1;
                Console.WriteLine($"Tentative de capture d'image au port {Port_cam_palette_1}");

                // On se connecte à la caméra, on capture l'image et on se déconnecte
                if (camera1_driver.Camera_connect(Port_cam_palette_1))
                {
                    if(camera1_driver.Camera_capture_image(Port_cam_palette_1, Save_path1))
                    {
                        if (camera1_driver.Camera_disconnect(Port_cam_palette_1))
                        {
                        }
                     }    
                }

                // On récupère le port de la caméra 2
                if (!Hardware_manager.TryGetPort("Camera_palette_2", out string port2) || port2 is null)
                {
                    Exception ex = new Exception("Port : " + port2 + " de la caméra colis non trouvé");
                    log_Error.Log_Error(ex);
                }

                string Port_cam_palette_2 = port2;
                Console.WriteLine($"Tentative de capture d'image au port {Port_cam_palette_2}");

                // On se connecte à la caméra, on capture l'image et on se déconnecte
                if (camera2_driver.Camera_connect(Port_cam_palette_2))
                {
                    if (camera2_driver.Camera_capture_image(Port_cam_palette_2, Save_path2))
                    {
                        if (camera2_driver.Camera_disconnect(Port_cam_palette_2))
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
            }
        }
    }
}
