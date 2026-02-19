/* ==================================================================================================
 *  Projet      : Expe
 *  Module      : SOftware/Requete/Requete_MALAN_PESAGE
 *  Fichier     : Request.specific.cs
 *  Auteur      : Paul Paput
 *  Création    : 13/02/26
 *  Description : Fonctions spécifiques d'accès à la base de données SQL Server pour le projet MALAN_PESAGE
 *  Historique :
 *      - 13/02/26 : Création de la classe — Paul Paput
 *      - 16/02/26 : Mise à  jour de Last_BL et Call_BL — Paul Paput
 *      - 19/02/26 : Ajout verif_bl — Paul Paput
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
        /// Méthodes : Last_Bl,  Call_BL, Path_crator, Insert_palette, Insert_photo, Compte_colis, Prochain_id_pal_colis, Etiquette_creator, Id_operateur_from_username
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
                // Connexion a la bdd
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    const string sql = "SELECT TOP 100 id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids FROM BL ORDER BY id_BL DESC";

                    // Envoi et reception des données
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

            // Préparation de la requête
            string sql = @"SELECT C.contact, B.poids_theo_brut, B.id_AR, B.erreur_poids 
                   FROM BL B
                   INNER JOIN Client C ON B.id_client = C.id_client 
                   WHERE B.id_BL = @id_BL";

            try
            {
                // Connexion à la BDD
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

        // <summary>
        // Création nom fichier selon type de fichier
        // </summary>
        public string Path_crator(int id_BL, int numero_palette, string type_path, string timestamp)
        {
            Log_error log = new Log_error();
            // On créé le bon nom de fichier en fonction du type de fichier
            // .zpl -> Etiquettes
            // 1.png & 2.png -> Photos palette
            // .png -> Photo colis
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
                Exception ex = new Exception("Extension fichier non reconnue : " + type_path);
                log.Log_Error(ex);
                return null;
            }

        }

        // <summary>
        // Insertion des infos d'une palette
        // </summary>
        public bool Insert_palette(int id_pal_colis, int id_BL, int type_pal_colis, int tare_pal_colis, float poids_pal_colis, int id_operateur, string url_etiquette, string horodatage, int numero_pal_colis)
        {
            Log_error log_Error = new Log_error();
            // Création de la commande SQL
            string sql = "INSERT INTO Pal_colis (id_pal_colis, id_BL, type_pal_colis, tare_pal_colis, poids_pal_colis, id_operateur, url_etiquette, horodatage, numero_pal_colis) " +
                         "VALUES (@id_pal_colis, @id_BL, @type_pal_colis, @tare_pal_colis, @poids_pal_colis, @id_operateur, @url_etiquette, @horodatage, @numero_pal_colis)";
            try
            {
                // Connexion à la base et envoi de la requête
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        Console.WriteLine("Requete SQL : " + sql + "envoyée");
                        command.Parameters.AddWithValue("@id_pal_colis", id_pal_colis);
                        command.Parameters.AddWithValue("@id_BL", id_BL);
                        command.Parameters.AddWithValue("@type_pal_colis", type_pal_colis);
                        command.Parameters.AddWithValue("@tare_pal_colis", tare_pal_colis);
                        command.Parameters.AddWithValue("@poids_pal_colis", poids_pal_colis);
                        command.Parameters.AddWithValue("@id_operateur", id_operateur);
                        command.Parameters.AddWithValue("@url_etiquette", url_etiquette);

                        // Cas particulier de horodatage
                        string format = "yyyy_MM_dd_HH_mm_ss";

                        // Convertir la string en objet DateTime
                        DateTime datePourBDD;
                        try
                        {
                            datePourBDD = DateTime.ParseExact(horodatage, format, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (FormatException)
                        {
                            // Gestion d'erreur si le format ne correspond pas (ex: fallback sur la date actuelle)
                            Exception ex = new Exception("Formar horodatage ne correspond pas : " + format);
                            log_Error.Log_Error(ex);
                            datePourBDD = DateTime.Now;
                        }

                        command.Parameters.AddWithValue("@horodatage", datePourBDD);

                        command.Parameters.AddWithValue("@numero_pal_colis", numero_pal_colis);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;

            }
            catch (Exception ex) {
                log_Error.Log_Error(ex);
                return false;
            }

        }

        // <summary>
        // Insertion des photos à la table Photo
        // </summary>
        public bool Insert_photo(int id_pal_colis, string url_photo_1, string url_photo_2)
        {
            Log_error log_Error = new Log_error();
            // Création de la requête SQL
            string sql = " INSERT INTO Photo (id_pal_colis, url_photo1, url_photo2) " +
                         "VALUES (@id_pal_colis, @url_photo1, @url_photo2)";
            try
            {
                // Connexion à la BDD
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_pal_colis", id_pal_colis);
                        command.Parameters.AddWithValue("@url_photo1", url_photo_1);
                        command.Parameters.AddWithValue("@url_photo2", url_photo_2);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                return false;
            }
        }

        // <summary>
        // Création de numero_pal_colis
        // </summary>
        public int Compte_colis(int id_bl)
        {
            // Requete SQL pour compter le nombre de lignes dans Pal_colis avec le numéro de BL donné
            Log_error log_Error = new Log_error();
            int nbr_colis = -1; // Si erreur de comptage, on a la palette -1
            // Création de la requête SQL
            string sql = @"SELECT COUNT(*) FROM Pal_colis WHERE id_BL = @id_bl";
            try
            {
                // Connexion à la BDD
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id_BL", id_bl);

                        // Ouverture de la connexion
                        connection.Open();

                        // Le nombre en retour est le numéro de colis, on le convertit en int
                        // ExecuteScalar est utilisé car on ne récupère qu'une seule valeur (le count)
                        nbr_colis = Convert.ToInt32(command.ExecuteScalar());
                        nbr_colis += 1;
                        Console.WriteLine("Numéro de colis : " + nbr_colis);
                    }
                }
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
            }

            return nbr_colis; // -1 si erreur
        }

        // <summary>
        // Calcul du prochain id palette
        // </summary>
        public int Prochain_id_pal_colis()
        {
            Log_error log_Error = new Log_error();
            // Par défaut, si ça plante ou si la base est vide, on renvoie à -1
            int next_id = -1;

            // Création de la requête SQL
            string sql = @"SELECT MAX(id_pal_colis) FROM Pal_colis";

            try
            {
                // Connexion à la BDD
                using (SqlConnection connection = new SqlConnection(Connection_string))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            next_id = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);
                // En cas d'erreur, on retourne 1 ou -1 selon votre logique de gestion d'erreur
            }

            return next_id+1;
        }

        // <summary>
        // On récupère les infos spécifiques à la création de l'étiquette
        // </summary>
        public (string depLivre, string contact, string adresseLivr, int idAR_int, int nbrColisTheo_int, float poidsTheoNet_float, int id_pal_colis) Etiquette_creator(int id_Bl)
        {
            Log_error log_Error = new Log_error();
            // Requête SQL pour récupérer les informations nécessaires à l'étiquette
            // Dans la table BL : id_BL, id_client, nbr_pal_colis_theo, poids_theo_brut, poids_theo_net, poids_reel, id_AR, erreur_poids
            // Dans la table Client : id_client, dep_livre, contact, adresse_livr
            // Dans la table Pal_colis : id_pal_colis, id_BL, id_AR, numero_colis

            // Création de la requête SQL pour récupérer les informations nécessaires à l'étiquette
            string sql =    @"SELECT C.dep_livr, C.contact, C.adresse_livr, 
                            B.id_AR, B.nbr_pal_colis_theo, B.poids_theo_net
                            FROM BL B
                            LEFT JOIN Client C ON B.id_client = C.id_client
                            LEFT JOIN Pal_colis P ON B.id_BL = P.id_BL
                            WHERE B.id_BL = @id_BL";
            Console.WriteLine("Requete SQL : " + sql);
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
                                Console.WriteLine("Entree dans if reader");
                                string depLivre = reader["dep_livr"].ToString();
                                string contact = reader["contact"].ToString();
                                string adresseLivr = reader["adresse_livr"].ToString();
                                int idAR_int = Convert.ToInt32(reader["id_AR"]);
                                int nbrColisTheo_int = Convert.ToInt32(reader["nbr_pal_colis_theo"]);
                                float poidsTheoNet_float = Convert.ToSingle(reader["poids_theo_net"]);
                                int id_pal_colis = Prochain_id_pal_colis();
                                return (depLivre, contact, adresseLivr, idAR_int, nbrColisTheo_int, poidsTheoNet_float, id_pal_colis);
                            }
                            else
                            {
                                // Si aucun résultat n'est trouvé, retourner des valeurs nulles
                                return (null, null, null, 0, 0, 0, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log_Error.Log_Error(ex);

                return (null, null, null, 0, 0, 0, 0);
            }
        }

        // <summary>
        // Conversion de l'id_operateur depuis un nom_utilisateur donné
        // </summary>
        public int Id_operateur_from_username(string id_operateur)
        {
            Log_error log_Error = new Log_error();
            int id_op = -1; // SI ça plante on renvoie -1

            // Création de la requête SQL
            string sql = @"SELECT id_operateur FROM Operateur WHERE nom_operateur = @nom_operateur";

            // Connexion à la BDD
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

        public bool verif_bl(int bl)
        {
            // On fait une requete à la BDD pour savoir si on peut faire la préparation de la commande
            Log_error log_Error = new Log_error();
            int bl_recup = -1;
            string sql = @"SELECT id_BL FROM BL WHERE id_BL=@bl";
            // Connexion à la BDD
            using (SqlConnection connection = new SqlConnection(Connection_string))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@bl", bl);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            bl_recup = Convert.ToInt32(result);
                        }
                    }
                    return bl==bl_recup;
                }
                catch (Exception ex)
                {
                    log_Error.Log_Error(ex);
                    Console.WriteLine("BL fault");
                    return false;
                }
                
            }
        }
    }
}
