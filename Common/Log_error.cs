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


namespace Common
{
    public class Log_error
    {


        public void Log_Error(Exception ex)
        {
            try
            {
                // Vérifier si la source existe, sinon la créer
                // Note : Cela peut lever une exception si l'app n'est pas lancée en Admin
                //if (!EventLog.SourceExists(sourceName))
                //{
                //    EventLog.CreateEventSource(sourceName, logName);
                //}

                // Construire le message d'erreur
                string message = $"Message: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}";
                Console.WriteLine(message);

                // Écrire dans l'observateur d'événements
                //EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
            }
            catch (Exception)
            {
                // Si l'écriture échoue (souvent un problème de droits), on ne veut pas 
                // faire planter l'appli entière, on peut afficher en console
                Console.WriteLine("Impossible d'écrire dans l'Event Viewer. Droits admin requis ?");
            }
        }
    }
}