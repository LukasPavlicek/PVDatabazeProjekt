using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class DodavatelDAO : IRepozitory<Dodavatel>
    {
        public void Smazat(Dodavatel element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Dodavatel where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Dodavatel> Vsechny()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Dodavatel", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Dodavatel dodavatel = new Dodavatel
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Adresa = reader["adresa"].ToString(),
                        TelefonCislo = reader["telefonCislo"].ToString()
                    };
                    yield return Dodavatel;
                }
                reader.Close();
            }

        }

        public Dodavatel PodleID(int id)
        {
            Dodavatel dodavatel = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Dodavatel WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dodavatel = new Dodavatel
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Adresa = reader["adresa"].ToString(),
                        TelefonCislo = reader["telefonCislo"].ToString()
                    };
                }
                reader.Close();
                return dodavatel;
            }
        }

        public void Vlozit(string jmeno, string adresa, string telefonCislo)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Dodavatel (jmeno, adresa, telefonCislo) VALUES (@jmeno, @adresa, @telefonCislo)", conn))
            {
                command.Parameters.Add(new SqlParameter("@jmeno", jmeno));
                command.Parameters.Add(new SqlParameter("@adresa", adresa));
                command.Parameters.Add(new SqlParameter("@telefonCislo", telefonCislo));
                command.ExecuteNonQuery();
            }
        }
    }
}