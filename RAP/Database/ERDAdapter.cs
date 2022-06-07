using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Entity;
using MySql.Data.MySqlClient;

using System.Reflection;
using System.ComponentModel;

namespace RAP.Database
{
    public static class ERDAdapter
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }


        public static List<Researcher> FetchBasicResearcherDetails()
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            List<Researcher> basicResearcher = new List<Researcher>();

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title, level, email from researcher", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    if(rdr.GetString(0)== "Staff") {
                        basicResearcher.Add(new Staff
                        {
                            Id = rdr.GetInt32(0),
                            GivenName = rdr.GetString(1),
                            FamilyName = rdr.GetString(2),
                            Title = rdr.GetString(3)
                           
                    });       
                }
                    else if (rdr.GetString(0) == "Student")
                    {
                        basicResearcher.Add(new Student
                        {
                            Id = rdr.GetInt32(0),
                            GivenName = rdr.GetString(1),
                            FamilyName = rdr.GetString(2),
                            Title = rdr.GetString(3)
                        });
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return basicResearcher;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static Researcher FetchFullResearcherDetails(int id)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            Researcher fullResearcher = new Researcher();
           // List<Researcher> fullResearcher = new List<Researcher>();

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select * from researcher where id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //possible this could be more elegant
                    if (!rdr.IsDBNull(9))
                    {
                        fullResearcher = new Student
                        {
                            Id = rdr.GetInt32(0),
                            Type = rdr.GetString(1),
                            GivenName = rdr.GetString(2),
                            FamilyName = rdr.GetString(3),
                            Title = rdr.GetString(4),
                            School = rdr.GetString(5),
                            Campus = rdr.GetString(6),
                            Email = rdr.GetString(7),
                            Photo = rdr.GetString(8),
                            Degree = rdr.GetString(9),
                            Supervisor_id = rdr.GetInt32(10),
                            Utas_start = rdr.GetDateTime(12),
                            Current_start = rdr.GetDateTime(13)
                        };
                    }
                    else
                    {
                        fullResearcher = new Staff
                        {
                            Id = rdr.GetInt32(0),
                            Type = rdr.GetString(1),
                            GivenName = rdr.GetString(2),
                            FamilyName = rdr.GetString(3),
                            Title = rdr.GetString(4),
                            School = rdr.GetString(5),
                            Campus = rdr.GetString(6),
                            Email = rdr.GetString(7),
                            Photo = rdr.GetString(8),
                            //Level = ParseEnum<EmploymentLevel>(rdr.GetString(11)), //may not work?
                         
                            Utas_start = rdr.GetDateTime(12),
                            Current_start = rdr.GetDateTime(13)
                        };
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return fullResearcher;
        }

        public static Researcher CompleteResearcherDetails(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            Researcher completeResearcher = new Researcher();

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select * from position where id=?id", conn);
                cmd.Parameters.AddWithValue("id", r.Id);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Position position = new Position
                    {
                        Level = ParseEnum<EmploymentLevel>(rdr.GetString(1)),
                        Start = rdr.GetDateTime(2),
                        End = rdr.GetDateTime(3)
                    };
                    //MAY NEED TO FIND A WAY TO ORDER BY DATE TO DEAL WITH DEMOTIONS?
                    r.Positions.Add(position);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            //MAY NEED METHOD TO ADD SUPERVISED STUDENTS NAMES?
            return r;
        }

        public static List<Publication> FetchBasicPublicationDetails(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            List<Publication> basicP = new List<Publication>();

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select pub.doi, title, year from publication as pub, " +
                                                    "researcher_publication as respub where pub.doi=respub.doi " +
                                                    "and researcher_id=?id", conn);
                cmd.Parameters.AddWithValue("id", r.Id);
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    basicP.Add(new Publication
                    {
                        DOI = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Year = rdr.GetInt32(2)
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return basicP;
        }

        public static Publication CompletePublicationDetails(Publication p)
        {
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select authors, type, cite_as, available " +
                                                    "from publication where doi=?doi", conn);
                cmd.Parameters.AddWithValue("doi", p.DOI);
                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    p.Authors = rdr.GetString(0);
                    p.Type = ParseEnum<OutputType>(rdr.GetString(1));
                    p.CiteAs = rdr.GetString(2);
                    p.Available = rdr.GetDateTime(3);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return p;
        }

        /*
+fetchPublicationCounts(from: Date, to: Date) : integer[]        ????????????????????????????????????*/

    }
}
