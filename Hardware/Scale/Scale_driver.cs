/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Scale
 *  Fichier     : Scale_driver.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Driver de la balance pour le projet MALAN_PESAGE
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */


using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.Scale
{

    /// <summary>
    /// Fonctions : Gère l'interface bas niveau avec la balance
    /// Champs : Vide
    /// Méthodes :Scale_connect, Scale_disconnect, Scale_get_weight
    /// </summary>
    public class Scale_driver
    {
        public bool Scale_connect(string Port_COM)
        {
            Log_error log_Error = new Log_error();
            // TODO: Implémenter la logique de connexion à la balance via le port COM spécifié.
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                return false;
            }

        }

        public bool Scale_disconnect(string Port_COM)
        {
            Log_error log_Error = new Log_error();
            // TODO: Implémenter la logique de déconnexion à la balance via le port COM spécifié.
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                return false;
            }
        }

        public bool Scale_get_weight(string Port_COM, out double Weight)
        {
            Log_error log_Error = new Log_error();
            // TODO: Implémenter la logique pour obtenir le poids actuel de la balance via le port COM spécifié.
            try
            {
                Weight = 1.0;
                return true;
            }
            catch (Exception ex)
            {
                Weight = 0.0;
                log_Error.Log_Error(ex);
                return false;
            }
        }
    }
}
