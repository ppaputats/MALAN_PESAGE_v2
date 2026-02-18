/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Printer
 *  Fichier     : Printer_ZPL_to_PNG.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Convertisseur de ZPL en PNG, utilisé pour la visualisation de l'étiquette
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Hardware.Printer
{
    internal class Printer_ZPL_to_PNG
    {
        Log_error log_Error = new Log_error();
        public bool Convert_ZPL_to_PNG(string ZPL_path, string PNG_path)
        {
            try
            {
                // Convertir le fichier ZPL en PNG
                return true;
            }
            catch (Exception ex) 
            { 
                log_Error.Log_Error(ex);
                return false;
            }
        }
    }
}
