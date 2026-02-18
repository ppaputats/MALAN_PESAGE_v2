/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Scale
 *  Fichier     : Scale_manager.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Manager de la balance pour le projet MALAN_PESAGE, responsable de la gestion 
 *  globale de la balance, de l'initialisation à la lecture du poids en passant par la configuration
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
    /// Champs : 
    /// Méthodes :Scale_colis, Scale_palette
    /// </summary>
    public class Scale_manager
    {
        public float Scale_colis(string adresse)
        {
            Hardware_manager Hardware_manager = new Hardware_manager();
            Scale_driver scale_Driver = new Scale_driver();
            Log_error Log_error = new Log_error();
            Console.WriteLine("Tentative de connexion à la balance sur le port " + adresse);
            float poids = -1;

            try
            {
                if (!Hardware_manager.TryGetPort("Balance_colis", out string port_COM) || port_COM == null)
                {
                    Console.WriteLine("Port de la balance non trouvé dans la configuration.");
                    return poids;
                }

                if (scale_Driver.Scale_connect(port_COM))
                {
                    if (scale_Driver.Scale_get_weight(port_COM, out double mesure))
                    {
                        Console.WriteLine("Poids mesuré : " + mesure + " kg");
                        if (scale_Driver.Scale_disconnect(port_COM))
                        { 
                        }
                        poids = (float)mesure;
                    }
                }
            }
            catch (Exception ex)
            {
                Log_error.Log_Error(ex);
            }
            return poids;
        }

        public float Scale_palette(string adresse)
        {
            Hardware_manager Hardware_manager = new Hardware_manager();
            Scale_driver scale_Driver = new Scale_driver();
            Log_error Log_error = new Log_error();
            Console.WriteLine("Tentative de connexion à la balance sur le port " + adresse);
            float poids = -1;

            try
            {
                if (!Hardware_manager.TryGetPort("Balance_palette", out string port_COM) || port_COM == null)
                {
                    Console.WriteLine("Port de la balance non trouvé dans la configuration.");
                    return poids;
                }

                if (scale_Driver.Scale_connect(port_COM))
                {
                    if (scale_Driver.Scale_get_weight(port_COM, out double mesure))
                    {
                        Console.WriteLine("Poids mesuré : " + poids + " kg");
                        if (scale_Driver.Scale_disconnect(port_COM))
                        {
                        }
                        poids = (float)mesure;
                    }
                }
            }
            catch (Exception ex)
            {
                Log_error.Log_Error(ex);
            }
            return poids;
        }

    }
}