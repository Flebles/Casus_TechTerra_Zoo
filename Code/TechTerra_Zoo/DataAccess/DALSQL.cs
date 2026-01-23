using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTerra_Zoo.Models;

namespace TechTerra_Zoo.DataAccess
{
    internal class DALSQL
    {
        private string webserver;
        private string database;
        private readonly string connectionstring;

        public DALSQL()
        {
            webserver = @"(localdb)\MSSQLLocalDB";
            database = "TechTerra_Zoo";

            connectionstring =
                $"Server={webserver};" +
                $"Database={database};" +
                $"Trusted_Connection=True;" +
                $"TrustServerCertificate=True;";

            ZorgDatDatabaseBestaat();
            ZorgDatTabellenBestaan();
        }

        private void ZorgDatDatabaseBestaat()
        {
            string masterConnectionString =
                $"Server={webserver};" +
                $"Database=master;" +
                $"Trusted_Connection=True;" +
                $"TrustServerCertificate=True;";

            string query = $@"
                IF NOT EXISTS (
                    SELECT name 
                    FROM sys.databases 
                    WHERE name = N'{database}'
                )
                BEGIN
                    CREATE DATABASE [{database}]
                END
            ";

            using SqlConnection connection = new SqlConnection(masterConnectionString);
            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
        }

        private void ZorgDatTabellenBestaan()
        {
            string query = @"
                IF NOT EXISTS (
                    SELECT * 
                    FROM sys.objects 
                    WHERE object_id = OBJECT_ID(N'[dbo].[Dier]')
                      AND type = N'U'
                )
                BEGIN
                    CREATE TABLE Dier
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Naam NVARCHAR(100) NOT NULL,
                        Geluid NVARCHAR(100) NOT NULL,
                        AantalPoten INT NOT NULL,
                        HeeftVacht BIT NOT NULL
                    )
                    
                    CREATE TABLE Verblijf
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        verblijfNaam NVARCHAR(100) NOT NULL,
                        capaciteit INT NOT NULL,
                    )
                END
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddDier(Dier dier)
        {
            string query = @"
                INSERT INTO Dier (Naam, Geluid, AantalPoten, HeeftVacht)
                VALUES (@Naam, @Geluid, @AantalPoten, @HeeftVacht);
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Naam", dier.Naam);
            command.Parameters.AddWithValue("@Geluid", dier.Geluid);
            command.Parameters.AddWithValue("@AantalPoten", dier.AantalPoten);
            command.Parameters.AddWithValue("@HeeftVacht", dier.HeeftVacht);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Dier> GetAllDieren()
        {
            List<Dier> dieren = new List<Dier>();

            string query = @"
                SELECT Id, Naam, Geluid, AantalPoten, HeeftVacht
                FROM Dier;
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string naam = reader["Naam"].ToString();
                string geluid = reader["Geluid"].ToString();
                int aantalPoten = (int)reader["AantalPoten"];
                bool heeftVacht = (bool)reader["HeeftVacht"];

                // Tijdelijk: alles als Leeuw
                Dier dier = new Leeuw(id, naam, geluid, aantalPoten, heeftVacht);
                dieren.Add(dier);
            }

            return dieren;
        }
        public void AddVerblijf(Verblijf verblijf)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string query = "INSERT INTO Verblijf (Verblijf, Capaciteit) VALUES (@verblijf, @capaciteit)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@verblijf", verblijf.VerblijfNaam);
                    command.Parameters.AddWithValue("@capaciteit", verblijf.Capaciteit);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Verblijf> GetAllVerblijven()
        {
            List<Verblijf> verblijven = new List<Verblijf>();
            string query = "SELECT Id, Verblijf, capaciteit FROM Verblijf";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Verblijf verblijf = new Verblijf(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        );

                        verblijven.Add(verblijf);
                    }
                }
            }

            return verblijven;
        }

    }
}