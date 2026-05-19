using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CiclistApp
{
    public class Biciclist
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Cnp { get; set; }

        public override string ToString() => $"{Nume} — {Cnp}";
    }

    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string dbPath)
        {
            _connectionString = $"Data Source={dbPath};Version=3;";
        }

        public void InitDB()
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Biciclisti (
                            id_biciclist INTEGER PRIMARY KEY AUTOINCREMENT,
                            nume         TEXT NOT NULL,
                            cnp          TEXT NOT NULL
                        );
                        CREATE TABLE IF NOT EXISTS Trasee (
                            id_traseu        INTEGER PRIMARY KEY AUTOINCREMENT,
                            id_biciclist     INTEGER NOT NULL,
                            denumire_traseu  TEXT NOT NULL,
                            distanta_km      REAL NOT NULL,
                            dificultate      TEXT NOT NULL,
                            durata_estimata  INTEGER NOT NULL,
                            FOREIGN KEY (id_biciclist) REFERENCES Biciclisti(id_biciclist)
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Biciclist> GetBiciclisti()
        {
            var list = new List<Biciclist>();
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_biciclist, nume, cnp FROM Biciclisti ORDER BY nume";
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new Biciclist
                            {
                                Id = r.GetInt32(0),
                                Nume = r.GetString(1),
                                Cnp = r.GetString(2)
                            });
                        }
                    }
                }
            }
            return list;
        }

        // ══════════════════════════════════════════════════════
        //  METODE NOI METE PENTRU TRASEE ȘI OPERAȚII (ADĂUGATE)
        // ══════════════════════════════════════════════════════

        public List<TraseuDetalii> GetTrasee(int idBiciclist)
        {
            var list = new List<TraseuDetalii>();
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_traseu, denumire_traseu, distanta_km, dificultate, durata_estimata FROM Trasee WHERE id_biciclist = @id";
                    cmd.Parameters.AddWithValue("@id", idBiciclist);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new TraseuDetalii
                            {
                                IdTraseu = r.GetInt32(0),
                                Denumire = r.GetString(1),
                                DistantaKm = r.GetDouble(2),
                                Dificultate = r.GetString(3),
                                DurataMinute = r.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void AddBiciclist(string nume, string cnp)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Biciclisti (nume, cnp) VALUES (@nume, @cnp)";
                    cmd.Parameters.AddWithValue("@nume", nume);
                    cmd.Parameters.AddWithValue("@cnp", cnp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddTraseu(int idBiciclist, string denumire, double distanta, string dificultate, int durata)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Trasee (id_biciclist, denumire_traseu, distanta_km, dificultate, durata_estimata) VALUES (@idB, @den, @dist, @dif, @dur)";
                    cmd.Parameters.AddWithValue("@idB", idBiciclist);
                    cmd.Parameters.AddWithValue("@den", denumire);
                    cmd.Parameters.AddWithValue("@dist", distanta);
                    cmd.Parameters.AddWithValue("@dif", dificultate);
                    cmd.Parameters.AddWithValue("@dur", durata);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBiciclist(int idBiciclist)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    // șterge mai întâi traseele asociate
                    cmd.CommandText = "DELETE FROM Trasee WHERE id_biciclist = @id";
                    cmd.Parameters.AddWithValue("@id", idBiciclist);
                    cmd.ExecuteNonQuery();

                    // apoi biciclistul
                    cmd.CommandText = "DELETE FROM Biciclisti WHERE id_biciclist = @id";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTraseu(int idTraseu)        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Trasee WHERE id_traseu = @id";
                    cmd.Parameters.AddWithValue("@id", idTraseu);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Biciclist GetBiciclistByCnp(string cnp)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT id_biciclist, nume, cnp FROM Biciclisti WHERE cnp = @cnp LIMIT 1";
                    cmd.Parameters.AddWithValue("@cnp", cnp);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            return new Biciclist
                            {
                                Id = r.GetInt32(0),
                                Nume = r.GetString(1),
                                Cnp = r.GetString(2)
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ══════════════════════════════════════════════════════
        //  METODE STATISTICI (ADĂUGATE)
        // ══════════════════════════════════════════════════════
        public Tuple<int, double, double, string> GetStatisticiBiciclist(int idBiciclist)
        {
            int count = 0;
            double totalDist = 0;
            double maxDist = 0;
            string celMaiLungTraseu = "-";

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*), TOTAL(distanta_km), MAX(distanta_km) FROM Trasee WHERE id_biciclist = @id";
                    cmd.Parameters.AddWithValue("@id", idBiciclist);

                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            count = r.GetInt32(0);
                            totalDist = r.GetDouble(1);
                            maxDist = r.IsDBNull(2) ? 0 : r.GetDouble(2);
                        }
                    }

                    if (maxDist > 0)
                    {
                        cmd.CommandText = "SELECT denumire_traseu FROM Trasee WHERE id_biciclist = @id AND distanta_km = @max LIMIT 1";
                        cmd.Parameters.AddWithValue("@max", maxDist);
                        var nume = cmd.ExecuteScalar();
                        if (nume != null) celMaiLungTraseu = nume.ToString();
                    }
                }
            }

            return new Tuple<int, double, double, string>(count, totalDist, maxDist, celMaiLungTraseu);
        }

        public Tuple<int, int> GetStatisticiGenerale()
        {
            int nrBiciclisti = 0;
            int nrTrasee = 0;

            using (var con = new SQLiteConnection(_connectionString))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Biciclisti";
                    nrBiciclisti = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.CommandText = "SELECT COUNT(*) FROM Trasee";
                    nrTrasee = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return new Tuple<int, int>(nrBiciclisti, nrTrasee);
        }
    }
}