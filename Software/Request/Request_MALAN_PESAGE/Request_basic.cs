/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : Software/Requete/Requete_MALAN_PESAGE
 *  Fichier     : Request.basic.cs
 *  Auteur      : Paul Paput
 *  Création    : 13/02/26
 *  Description : Appel à la base de données SQL Server pour le projet MALAN_PESAGE
 *  Historique :
 *      - 13/02/26 : Création de la classe — Paul Paput
 *      - 16/02/26 : Mise à  jour de Sql_select
 *
 * ================================================================================================ */

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using Common;

namespace Software.Request.Request_MALAN_PESAGE
{
    /// <summary>
    /// Fonctions : Connection à la base de données SQL Server et exécution de requêtes SQL génériques (SELECT, INSERT, UPDATE, DELETE)
    /// Champs : Connection_string
    /// Méthodes :Get_connection_async,
    /// </summary>
    public class Request_basic
    {

        private readonly string Connection_string =
"Server=SRVATS3-VM2; Database=MALAN_PESAGE; User Id=paulp; Password=1234; TrustServerCertificate=True;";



        // ----------------------------------------------------------------
        // SELECT 
        // ----------------------------------------------------------------
        public DataTable Sql_select(string query)
        {
            Log_error log_Error = new Log_error();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection_string))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
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
    }
}