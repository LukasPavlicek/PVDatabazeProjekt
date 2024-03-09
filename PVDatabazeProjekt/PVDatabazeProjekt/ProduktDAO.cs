using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class ProduktDAO : IRepozitory<Produkt>
    {
        public void Smazat(Produkt element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("Delete FROM Produkt where id = @id", conn))
            {
                command.Parameters.Add("@id", (System.Data.SqlDbType)element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Produkt> Vsechny()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkt", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Produkt produkt = new Produkt
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        nazev = reader["nazev"].ToString(),
                        cena = Convert.ToDecimal(reader["cena"]),
                        datumVyroby = Convert.ToDateTime(reader["datumVyroby"])
                    };
                    yield return produkt;
                }
                reader.Close();
            }

        }

        public Produkt PodleID(int id)
        {
            Produkt produkt = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();


            using (SqlCommand command = new SqlCommand("SELECT * FROM Produkt WHERE id = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    produkt = new Produkt
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        nazev = reader["nazev"].ToString(),
                        cena = Convert.ToDecimal(reader["cena"]),
                        datumVyroby = Convert.ToDateTime(reader["datumVyroby"])
                    };
                }
                reader.Close();
                return produkt;
            }
        }

        public void Vlozit(string nazev, decimal cena, DateTime datumVyroby)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Produkt (nazev, cena, datumVyroby) VALUES (@nazev, @cena, @datumVyroby)", conn))
            {
                command.Parameters.Add(new SqlParameter("@nazev", nazev));
                command.Parameters.Add(new SqlParameter("@cena", cena));
                command.Parameters.Add(new SqlParameter("@datumVyroby", datumVyroby));
                command.ExecuteNonQuery();
            }
        }
    }
}