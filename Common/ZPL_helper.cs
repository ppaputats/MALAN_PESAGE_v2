/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Common
 *  Fichier     : Log_error.cs
 *  Auteur      : Paul Paput
 *  Création    : 19/02/26
 *  Description : Driver de la caméra pour le projet MALAN_PESAGE
 *  Historique :
 *      - 19/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using System;
using System.IO;
using System.Text;

namespace Common
{
    public class ZPL_helper
    {
        /// <summary>
        /// Fonctions : Save_ZPL_to_file
        /// </summary>
        public void Save_ZPL_to_file(string ZPL_data, string File_path)
        {
            Log_error log_Error = new Log_error();
            try
            {
                // Vérifier si le dossier parent existe, sinon le créer
                string directory = Path.GetDirectoryName(File_path);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Dans File_path, on ne stock que le nom du fichier, il faut ajouter le chemin complet du dossier de destination
                // Le chemin de destination souhaité est :
                // "C:\Users\Paulp\Documents\C#\Proto2\UI_MALAN_PESAGE\Stockage_ZPL"
                string dossier = "C:\\Users\\Paulp\\Documents\\C#\\Proto2\\UI_MALAN_PESAGE\\Stockage_ZPL";
                File_path = Path.Combine(dossier, File_path);
                Console.WriteLine($"Chemin complet du fichier : {File_path}");
                // Enregistrement du fichier avec encodage UTF-8 (sans BOM de préférence pour Zebra)
                File.WriteAllText(File_path, ZPL_data, new UTF8Encoding(false));

                Console.WriteLine($"Fichier ZPL enregistré avec succès : {File_path}");
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
            }
        }
    }
}
