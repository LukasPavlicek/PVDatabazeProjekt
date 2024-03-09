using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class ZakaznikDAO : IRepozitory<Zakaznik>
    {
        public void Smazat(Zakaznik element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Zakaznik where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Zakaznik> Vsechny()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Zakaznik", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Zakaznik zakaznik = new Zakaznik
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Adresa = reader["adresa"].ToString(),
                        TelefonCislo = reader["telefonCislo"].ToString()
                    };
                    yield return Zakaznik;
                }
                reader.Close();
            }

        }

        public Zakaznik PodleID(int id)
        {
            Zakaznik zakaznik = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Zakaznik WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    zakaznik = new Zakaznik
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Jmeno = reader["jmeno"].ToString(),
                        Adresa = reader["adresa"].ToString(),
                        TelefonCislo = reader["telefonCislo"].ToString()
                    };
                }
                reader.Close();
                return zakaznik;
            }
        }

        public void Vlozit(string jmeno, string adresa, string telefonCislo)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Zakaznik (jmeno, adresa, telefonCislo) VALUES (@jmeno, @adresa, @telefonCislo)", conn))
            {
                command.Parameters.Add(new SqlParameter("@jmeno", jmeno));
                command.Parameters.Add(new SqlParameter("@adresa", adresa));
                command.Parameters.Add(new SqlParameter("@telefonCislo", telefonCislo));
                command.ExecuteNonQuery();
            }
        }
    }
}