using Microsoft.Data.SqlClient;
using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Data.Repositories
{
    public class SubsciptionsRepository : IRepository<Subscription, int>
    {
        public void Delete(Subscription entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscription> GetAll()
        {
            var listSubsctiption = new List<Subscription>();

            using(SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ParaglidingClub;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                con.Open();

                string sql = "SELECT * FROM Subscription ORDER BY YearID DESC";

                using(SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = con;
                    var reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        var s = new Subscription();
                        s.YearID = Int32.Parse(reader["YearID"].ToString());
                        s.Price = decimal.Parse(reader["Price"].ToString());

                        listSubsctiption.Add(s);
                    }
                }
            }

            return listSubsctiption;
        }

        public Subscription GetByID(int id)
        {
            var subscription = new Subscription();

            using (SqlConnection con = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=ParaglidingClub;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                con.Open();

                string sql = "SELECT * FROM Subscription JOIN Payment JOIN Pilot WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        subscription.YearID = Int32.Parse(reader["YearID"].ToString());
                        subscription.Price = decimal.Parse(reader["Price"].ToString());
                    }
                }
            }

            return subscription;
        }

        public Subscription Insert(Subscription entity)
        {
            throw new NotImplementedException();
        }

        public Subscription Update(Subscription entity)
        {
            throw new NotImplementedException();
        }
    }
}
