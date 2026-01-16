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

                // Tijdelijk: alles als Leeuw (later verbeteren)
                Dier dier = new Leeuw(id, naam, geluid, aantalPoten, heeftVacht);
                dieren.Add(dier);
            }

            return dieren;
        }
    }
}