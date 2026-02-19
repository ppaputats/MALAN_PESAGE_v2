/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Printer
 *  Fichier     : Printer_manager.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Manager de l'imprimante pour le projet MALAN_PESAGE, responsable de la gestion globale
 *   de l'imprimante, de l'initialisation à l'impression en passant par la configuration
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *      - 18/02/26 : Création du cycle d'impression — Paul Paput
 *
 * ================================================================================================ */

using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Text;

namespace Hardware.Printer
{
    public class Printer_manager
    {
        public void Print_Etiquette(string ZPL_path, int id_BL, float poids, int numero_colis, string timestamp, 
            string depLivre, string contact, string adresseLivr, int operateur, int idAR, int nbrColisTheo, float poidsTheoNet
            , int id_pal)
        {
            Hardware_manager Hardware_manager = new Hardware_manager();
            Printer_driver printer_driver = new Printer_driver();
            Printer_ZPL_Builder printer_ZPL_Builder = new Printer_ZPL_Builder();
            ZPL_helper printer_helper = new ZPL_helper();

            try
            {
                // On récupère le port de l'imprimante
                if (!Hardware_manager.TryGetPort("Printer", out string port) || port == null)
                {
                    Log_error log_Error = new Log_error();
                    Exception ex = new Exception("Erreur lors de la récupération du port de la palette");
                    log_Error.Log_Error(ex);
                    return;
                }

                // On enregistre le fichier ZPL à son path
                // Fonction qui enregistre le fichier ZPL à son path et retourne ce path
                int.TryParse(depLivre, out int depLivreInt);
                printer_helper.Save_ZPL_to_file(printer_ZPL_Builder.Build_ZPL(depLivreInt, contact, adresseLivr, timestamp, id_BL, operateur, idAR, nbrColisTheo,  numero_colis, poidsTheoNet, poids, id_pal),ZPL_path);

                // Cycle d'impression avec connexion, envoi et déconnexion
                if (printer_driver.Printer_connect(port))
                {
                    if (printer_driver.Printer_send(port,  ZPL_path))
                    {
                        if (printer_driver.Printer_disconnect(port))
                        {

                        }
                    }
                }
                
            }
            catch (Exception ex) 
            {
                Log_error log_Error = new Log_error();
                log_Error.Log_Error(ex);
            }
        }
    }
}
