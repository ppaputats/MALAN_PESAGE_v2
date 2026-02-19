/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Software/Requete/Requete_MALAN_PESAGE
 *  Fichier     : Request.basic.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Logging des erreurs propre
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Common
{ 
    public class Log_error
    {
        // Chemin relatif pour remonter à la racine de la solution depuis le dossier /bin/Debug
        private readonly string logPath = "C:\\Users\\Paulp\\Documents\\C#\\Proto2\\UI_MALAN_PESAGE\\logs_erreurs.txt";
        public void Log_Error(Exception ex)
        {
            Console.WriteLine("Entrée Log_error");
            try
            {
                // 1. Préparation du message (Lisible et structuré)
                string divider = new string('-', 80);
                string logEntry = $"{divider}\n" +
                                  $"DATE    : {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                                  $"MESSAGE : {ex.Message}\n" +
                                  $"{divider}\n\n";

                // 2. Écriture (Append) dans le fichier
                File.AppendAllText(logPath, logEntry);

                // 3. Maintenance : Garder seulement les 100 dernières entrées
                GérerTailleFichier();

                // Affichage console pour le debug immédiat
                Console.WriteLine("Erreur consignée dans le fichier log.");
            }
            catch (Exception errorLog)
            {
                // Si même le log échoue, on écrit au moins dans la console
                Console.WriteLine("Échec de l'écriture du log : " + errorLog.Message);
            }
        }

        private void GérerTailleFichier()
        {
            try
            {
                if (File.Exists(logPath))
                {
                    var lines = File.ReadAllLines(logPath);
                    // On estime qu'une erreur prend environ 10 lignes. 
                    // Pour garder ~100 erreurs, on peut limiter à 1000 lignes.
                    if (lines.Length > 1000)
                    {
                        File.WriteAllLines(logPath, lines.Skip(lines.Length - 1000));
                    }
                }
            }
            catch { /* On ignore pour ne pas boucler sur une erreur de log */ }
        }
    }
}