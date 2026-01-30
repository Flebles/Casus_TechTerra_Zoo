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
                        Soort NVARCHAR(100) NOT NULL,
                        Geboortedatum DATE NULL,
                        Opmerking NVARCHAR(250) NULL,
                    )
                END

                IF NOT EXISTS (
                    SELECT * 
                    FROM sys.objects 
                    WHERE object_id = OBJECT_ID(N'[dbo].[Verblijf]')
                    AND type = N'U'
                )
                BEGIN
                    CREATE TABLE Verblijf
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        verblijfNaam NVARCHAR(100) NOT NULL,
                        Capaciteit INT NOT NULL,
                    )
                END

                IF NOT EXISTS (
                    SELECT * 
                    FROM sys.objects 
                    WHERE object_id = OBJECT_ID(N'[dbo].[VoedingSchema]')
                    AND type = N'U'
                )
                BEGIN
                    CREATE TABLE VoedingSchema
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Tijd NVARCHAR(50) NOT NULL,
                        Voeding NVARCHAR(100) NOT NULL,
                        Hoeveelheid NVARCHAR(50) NOT NULL,
                        Uitzonderingen NVARCHAR(255) NULL
                    );
                END

                IF NOT EXISTS (
                    SELECT *
                    FROM sys.objects
                    WHERE object_id = OBJECT_ID(N'[dbo].[DierVoeding]')
                    AND type = N'U'
                )
                BEGIN
                    CREATE TABLE DierVoeding
                    (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        DierId INT NOT NULL,
                        GevoerdOp DATETIME NOT NULL,

                        CONSTRAINT FK_DierVoeding_Dier
                            FOREIGN KEY (DierId) REFERENCES Dier(Id)
                    )
                END
            ";

            // tabel DierVoeding en tabel VoedingSchema zijn verschillend

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddDier(Dier dier)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string query = @"
                    INSERT INTO Dier (Naam, Soort, Geboortedatum, Opmerking)
                    VALUES (@Naam, @Soort, @Geboortedatum, @Opmerking);
                ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Naam", dier.Naam);
                    command.Parameters.AddWithValue("@Soort", dier.Soort);
                    command.Parameters.AddWithValue("@Geboortedatum", dier.Geboortedatum);
                    command.Parameters.AddWithValue("@Opmerking", dier.Opmerking ?? string.Empty);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Dier> GetAllDieren()
        {
            List<Dier> dieren = new List<Dier>();

            string query = @"
                SELECT Id, Naam, Soort, Geboortedatum, Opmerking
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
                string soort = reader["Soort"].ToString();
                DateTime? geboortedatum = reader["Geboortedatum"] == DBNull.Value ? null : (DateTime)reader["Geboortedatum"]; // geen flauw idee waarom dit werkt dus niet aanraken
                string opmerking = reader["Opmerking"].ToString();

                Dier dier = new Dier(id, naam, soort, geboortedatum, opmerking);
                dieren.Add(dier);
            }

            return dieren;
        }

        public Dier? GetDierById(int id)
        {
            string query = "SELECT Id, Naam, Soort, Geboortedatum, Opmerking FROM Dier WHERE Id = @id";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Dier(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDateTime(3),
                reader.GetString(4)
            );
        }

        public void UpdateDier(Dier dier)
        {
            string query = @"
                UPDATE Dier
                SET 
                    Naam = @naam,
                    Soort = @soort,
                    Geboortedatum = @geboortedatum,
                    Opmerking = @opmerking
                WHERE Id = @id
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", dier.Id);
            command.Parameters.AddWithValue("@naam", dier.Naam);
            command.Parameters.AddWithValue("@soort", dier.Soort);
            command.Parameters.AddWithValue("@geboortedatum", dier.Geboortedatum);
            command.Parameters.AddWithValue("@opmerking", dier.Opmerking ?? string.Empty);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"Aangepaste rijen: {rows}");
            Console.ReadKey();
        }

        public void DeleteDier(int id)
        {
            string query = "DELETE FROM Dier WHERE Id = @id";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddVerblijf(Verblijf verblijf)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string query = "INSERT INTO Verblijf (verblijfNaam, Capaciteit) VALUES (@verblijf, @capaciteit)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@verblijf", verblijf.VerblijfNaam);
                    command.Parameters.AddWithValue("@capaciteit", verblijf.Capaciteit);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RegistreerVoeding(int dierId)
        {
            string query = @"
                INSERT INTO DierVoeding (DierId, GevoerdOp)
                VALUES (@dierId, @tijdstip);
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@dierId", dierId);
            command.Parameters.AddWithValue("@tijdstip", DateTime.Now);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public bool IsDierVandaagGevoerd(int dierId)
        {
            // geen punten aftrek geven omdat ik weer "as" heb gebruikt thanks
            string query = @"
                SELECT COUNT(*)
                FROM DierVoeding
                WHERE DierId = @dierId
                AND CAST(GevoerdOp AS DATE) = CAST(GETDATE() AS DATE);
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@dierId", dierId);

            connection.Open();
            return (int)command.ExecuteScalar() > 0;
        }

        public DateTime? GetLaatsteVoeding(int dierId)
        {
            string query = @"
                SELECT TOP 1 GevoerdOp
                FROM DierVoeding
                WHERE DierId = @dierId
                ORDER BY GevoerdOp DESC;
            ";

            using SqlConnection connection = new SqlConnection(connectionstring);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@dierId", dierId);

            connection.Open();
            object result = command.ExecuteScalar();

            return result == null ? null : (DateTime)result;
        }

        public List<Verblijf> GetAllVerblijven()
        {
            List<Verblijf> verblijven = new List<Verblijf>();
            string query = "SELECT Id, verblijfNaam, Capaciteit FROM Verblijf";

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
        public void AddVoeding(VoedingSchema voeding)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                string query = @"INSERT INTO VoedingSchema 
                         (Tijd, Voeding, Hoeveelheid, Uitzonderingen)
                         VALUES (@tijd, @voeding, @hoeveelheid, @uitzonderingen)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tijd", voeding.Tijd);
                    command.Parameters.AddWithValue("@voeding", voeding.Voeding);
                    command.Parameters.AddWithValue("@hoeveelheid", voeding.Hoeveelheid);
                    command.Parameters.AddWithValue(
                        "@uitzonderingen",
                        voeding.Uitzonderingen ?? (object)DBNull.Value
                    );

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<VoedingSchema> GetAllVoeding()
        {
            List<VoedingSchema> voedingen = new List<VoedingSchema>();
            string query = "SELECT Id, Tijd, Voeding, Hoeveelheid, Uitzonderingen FROM VoedingSchema";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VoedingSchema voeding = new VoedingSchema(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.IsDBNull(4) ? null : reader.GetString(4)
                        );

                        voedingen.Add(voeding);
                    }
                }
            }

            return voedingen;
        }


    }
}