/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : SOftware/Requete/Requete_MALAN_PESAGE
 *  Fichier     : Request.specific.cs
 *  Auteur      : Paul Paput
 *  Création    : 13/02/26
 *  Description : Fonctions spécifiques d'accès à la base de données SQL Server pour le projet MALAN_PESAGE
 *  Historique :
 *      - 13/02/26 : Création de la classe — Paul Paput
 *      - 16/02/26 : Mise à  jour de Last_BL et Call_BL
 *
 * ================================================================================================ */

using Common;

using Software.Request.Request_MALAN_PESAGE;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;


namespace Software.Request.Request_MALAN_PESAGE
{

    public class Request_specific
    {
        /// <summary>
        /// Fonctions : Appels spécifiques à la base de données SQL Server pour le projet MALAN_PESAGE
        /// Champs : Charge_BL_async, 
        /// Méthodes : Vide
        /// </summary>
        string Connection_string =
"Server=SRVATS3-VM2; Database=MALAN_PESAGE; User Id=paulp; Password=1234; TrustServerCertificate=True;";

        // <summary>
        // Charger les 100 derniers BL
        // </summary>
        public DataTable Last_BL()
        {
            DataTable dt = new DataTable();
            Log_error log_Error = new Log_error();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    const string sql = "SELECT TOP 100 id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids FROM BL ORDER BY id_BL DESC";

                    // Utiliser SqlDataAdapter est plus simple pour remplir une DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                return null;
            }
        }

        // <summary>
        // Chercher les informations du BL sélectionné
        // </summary>
        public DataTable Call_BL(int id_BL)
        {
            DataTable dt = new DataTable();
            Log_error log_Error = new Log_error();

            // On prépare une seule requête qui récupère tout d'un coup
            string sql = @"SELECT C.contact, B.poids_theo_brut, B.id_AR, B.erreur_poids 
                   FROM BL B
                   INNER JOIN Client C ON B.id_client = C.id_client 
                   WHERE B.id_BL = @id_BL";

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_BL", id_BL);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                return null;
            }
        }

        public string Path_crator(int id_BL, int numero_palette, string type_path, string timestamp)
        {
            if (type_path == "ZPL")
            {
                return $"BL_{id_BL}_Pal_{numero_palette}_{timestamp}.zpl";
            }
            if (type_path == "PNG1")
            {
                return $"BL_{id_BL}_Pal_{numero_palette}_{timestamp}_1.png";
            }
            if (type_path == "PNG2")
            {
                return $"BL_{id_BL}_Pal_{numero_palette}_{timestamp}_2.png";
            }
            if (type_path == "PNG")
            {
                return $"BL_{id_BL}_Col_{numero_palette}_{timestamp}.png";
            }
            else
            {
                return null;
            }

        }

        public (string depLivre, string contact, string adresseLivr, int idAR_int, int nbrColisTheo_int, float poidsTheoNet_float) Etiquette_creator(int id_Bl)
        {
            Log_error log_Error = new Log_error();
            // Requête SQL pour récupérer les informations nécessaires à l'étiquette
            // Dans la table BL : id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids
            // Dans la table Client : id_client, dep_livre, contact, adresse_livr
            // Dans la table Pal_colis : id_pal_colis, id_BL, id_AR, numero_colis

            // Création de la requête SQL pour récupérer les informations nécessaires à l'étiquette
            string sql = @"SELECT C.dep_livre, C.contact, C.adresse_livr, B.id_AR, B.nbr_pal_colis_theo, B.poids_theo_net
                   FROM BL B
                   INNER JOIN Client C ON B.id_client = C.id_client 
                   WHERE B.id_BL = @id_BL";
            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_BL", id_Bl);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string depLivre = reader["dep_livre"].ToString();
                                string contact = reader["contact"].ToString();
                                string adresseLivr = reader["adresse_livr"].ToString();
                                int idAR_int = Convert.ToInt32(reader["id_AR"]);
                                int nbrColisTheo_int = Convert.ToInt32(reader["nbr_pal_colis_theo"]);
                                float poidsTheoNet_float = Convert.ToSingle(reader["poids_theo_net"]);
                                return (depLivre, contact, adresseLivr, idAR_int, nbrColisTheo_int, poidsTheoNet_float);
                            }
                            else
                            {
                                // Si aucun résultat n'est trouvé, retourner des valeurs par défaut ou nulles
                                return (null, null, null, 0, 0, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);

                return (null, null, null, 0, 0, 0);
            }

            //        // ----------------------------------------------------------------
            //        // Charger les 100 derniers BL
            //        // ----------------------------------------------------------------
            //        public async Task<(Ack_result ack, DataTable table)> Charge_BL_async()
            //        {
            //            const string sql =
            //                "SELECT TOP 100 * FROM BL ORDER BY id_BL DESC";

            //            return await tb.Sql_select(sql);
            //        }


            //        // ----------------------------------------------------------------
            //        // Ajouter un BL 
            //        // ----------------------------------------------------------------
            //        public async Task<Ack_result> Add_BL_async(
            //            int id_BL, int id_client, int nbr_pal_colis_theo,
            //            float poids_theo_brut, float poids_theo_net, float poids_reel,
            //            int id_AR, float erreur_poids)
            //        {

            //            var ackTestBdd = await tb.Get_connection_async();
            //            if (!ackTestBdd.Success)
            //                return ackTestBdd;

            //            const string sql_merge = @"
            //MERGE INTO dbo.BL AS Target
            //USING (VALUES (@id_BL, @id_client, @nbr_pal_colis_theo, @poids_theo_brut, @poids_theo_net, @poids_reel, @id_AR, @erreur_poids))
            //       AS Source (id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids)
            //ON Target.id_BL = Source.id_BL
            //WHEN MATCHED THEN
            //    UPDATE SET
            //        id_client = Source.id_client,
            //        nbr_pal_colis_theo = Source.nbr_pal_colis_theo,
            //        poids_theo_brut = Source.poids_theo_brut,
            //        poids_theo_net = Source.poids_theo_net,
            //        poids_reel = Source.poids_reel,
            //        id_AR = Source.id_AR,
            //        erreur_poids = Source.erreur_poids
            //WHEN NOT MATCHED THEN
            //    INSERT (id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids)
            //    VALUES (Source.id_BL, Source.id_client, Source.nbr_pal_colis_theo, Source.poids_theo_brut, Source.poids_theo_net, Source.poids_reel, Source.id_AR, Source.erreur_poids);";

            //            return await tb.Sql_insert(sql_merge, cmd =>
            //            {
            //                cmd.Parameters.AddWithValue("@id_BL", id_BL);
            //                cmd.Parameters.AddWithValue("@id_client", id_client);
            //                cmd.Parameters.AddWithValue("@nbr_pal_colis_theo", nbr_pal_colis_theo);
            //                cmd.Parameters.AddWithValue("@poids_theo_brut", poids_theo_brut);
            //                cmd.Parameters.AddWithValue("@poids_theo_net", poids_theo_net);
            //                cmd.Parameters.AddWithValue("@poids_reel", poids_reel);
            //                cmd.Parameters.AddWithValue("@id_AR", id_AR);
            //                cmd.Parameters.AddWithValue("@erreur_poids", erreur_poids);
            //            });
            //        }
        }

        public int Id_operateur_from_username(string id_operateur)
        {
            // On a le nom de l'utilisateur, on veut récupérer son id dans la base de données pour l'utiliser dans les différentes requêtes
            Log_error log_Error = new Log_error();
            int id_op = 0;
            string sql = @"SELECT id_operateur FROM Operateur WHERE nom_operateur = @nom_operateur";
            using (SqlConnection connection = new SqlConnection(Connection_string))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nom_operateur", id_operateur);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            id_op = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log_Error.Log_Error(ex);
                }
                return id_op;
            }
        }
    }
}
