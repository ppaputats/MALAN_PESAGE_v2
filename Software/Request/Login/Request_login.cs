/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : Software/Requete/Login
 *  Fichier     : Request.login.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Fonctions spécifiques à la connxion des utilisateurs
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using Common;
using Microsoft.Data.SqlClient;
using Software.Request.Request_MALAN_PESAGE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Fonctions : Fonctions spécifiques à la connxion des utilisateurs
/// Champs : Request_basic tb
/// Méthodes : Test_connection
/// </summary>
namespace Software.Request.Login
{
    public class Request_login
    {
        private readonly Request_basic tb = new Request_basic();

        /// <summary>
        /// Teste la connexion d'un utilisateur en vérifiant son nom et mot de passe dans la base de données SQL Server
        /// Entrées : id_operateur_averif (string), mdp_operateur_averif (string)
        /// Sorties : (bool login, bool admin) — login indique si la connexion est réussie, admin indique si l'utilisateur a des droits d'administrateur
        /// </summary>
        public (bool login, bool admin) Test_connection(string id_operateur_averif, string mdp_operateur_averif)
        {
            string connectionString = "Server=SRVATS3-VM2; Database=MALAN_PESAGE; User Id=paulp; Password=1234; TrustServerCertificate=True;";
            bool login = false;
            bool admin = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Ouverture de la connexion à la BDD
                    connection.Open();

                    // Création de la requête SQL avec des paramètres
                    string sql = "SELECT nom_operateur, id_operateur, droit_operateur FROM Operateur WHERE nom_operateur = @id AND mdp_operateur = @mdp";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id_operateur_averif);
                        command.Parameters.AddWithValue("@mdp", mdp_operateur_averif);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Récupération des valeurs
                                    string nom = reader["nom_operateur"]?.ToString();
                                    string id = reader["id_operateur"]?.ToString();
                                    string droit = reader["droit_operateur"]?.ToString()?.Trim().ToLower(); // Nettoyage pour comparaison

                                    // Vérification des droits 
                                    if (droit == "admin")
                                    {
                                        Console.WriteLine("RÉSULTAT: Accès ADMINISTRATEUR accordé.");
                                        return (true, true); // Login réussi et admin
                                    }
                                    else if (droit == "writer")
                                    {
                                        Console.WriteLine("RÉSULTAT: Accès RÉDACTEUR accordé.");
                                        return(true, false); // Login réussi et writer 
                                    }
                                    else
                                    {
                                        Console.WriteLine($"RÉSULTAT: Accès STANDARD (Droit actuel: {droit})");
                                        return (false, false); // Login réussi mais droit inconnu ou insuffisant
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("DEBUG: Aucun utilisateur trouvé avec ces identifiants.");
                            }
                        }
                    }
                }

                // Gestion des exceptions 
                catch (SqlException ex)
                {
                    Console.WriteLine($"ERREUR SQL ({ex.Number}): {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERREUR GÉNÉRALE: {ex.Message}");
                }

                return (login, admin);
                
            }
        }

    }
}