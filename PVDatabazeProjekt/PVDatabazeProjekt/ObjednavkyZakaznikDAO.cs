using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PVDatabazeProjekt
{
    public class ObjednavkyZakaznikDAO : IRepository<Objednavky>
    {
        public void Smazat(Objednavky element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE FROM Objednavky WHERE ID = @id", conn))
            {
                command.Parameters.Add("@id", element.ID);
                command.ExecuteNonQuery();
                element.ID = 0;
            }
        }

        public IEnumerable<Objednavky> Vsechny()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavky", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Objednavky objednavky = new Objednavky
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        DatumObjednani = Convert.ToDateTime(reader["DatumObjednani"]),
                        IdZakaznika = Convert.ToInt32(reader["IdZakaznika"])
                    };
                    yield return objednavky;
                }
                reader.Close();
            }

        }

        public Objednavky PodleID(int id)
        {
            Objednavky objednavky = null;
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavky WHERE ID = @Id", conn))
            {
                command.Parameters.Add(new SqlParameter("@Id", id));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    objednavky = new Objednavky
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        DatumObjednani = Convert.ToDateTime(reader["DatumObjednani"]),
                        IdZakaznika = Convert.ToInt32(reader["IdZakaznika"])
                    };
                }
                reader.Close();
            }
            return objednavky;
        }

        public void Vlozit(Objednavky element)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT INTO Objednavky (DatumObjednani, IdZakaznika) VALUES (@datumObjednani, @idZakaznika)", conn))
            {
                command.Parameters.Add(new SqlParameter("@datumObjednani", element.DatumObjednani));
                command.Parameters.Add(new SqlParameter("@idZakaznika", element.IdZakaznika));
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Objednavky> dostatPresZakaznika(Zakaznik zakaznik)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Objednavky " +
                "WHERE Objednvky.ID IN" +
                "(SELECT ObjednavkyZakaznikID FROM ObjednavkyZakaznik " +
                "WHERE ObjednavkyZakaznik.ZakaznikID = @id)", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", zakaznik.ID));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Objednavky objednavky = new Objednavky
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Purpose = reader[1].ToString()
                    };
                    yield return objednavky;
                }
                reader.Close();
            }
        }
    }
}