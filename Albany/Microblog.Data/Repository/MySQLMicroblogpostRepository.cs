using Dapper;
using Microblog.Data.Models.Interfaces;
using Microblog.Data.Repository.Interfaces;
using MySqlConnector;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Repository
{
    public class MySQLMicroblogpostRepository : IMicroblogpostRepository
    {
        string connectionString = "MYSQL_CONNECTION";
        MySqlConnectionStringBuilder connectionStringBuilder;
        public MySQLMicroblogpostRepository()
        {
            connectionStringBuilder = new MySqlConnectionStringBuilder()
            { Server="localhost",
              Port=3302,
              UserID = "serviceUser",
              Password = "password",
              Database="gentry",
            };

        }

        public async Task<IMicroblogPost> GetMicroblogpost(int id)
        {
            using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
            {
                string selectString = "SELECT id, postdata, postdate from microblog where id =@id";
                var parameters = new { id = id };
                connection.Open();
                var postToReturn = connection.Query<IMicroblogPost>(selectString, parameters).ToList();
                return postToReturn.First();
            }
        }

        public async Task<int> StoreMicroblogpost(IMicroblogPost postToStore)
        {
            using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
            {
                string insertQuery = "INSERT INTO microblog(postdata, postdate) values(postString=@postString, NOW()) returning id)";
                var parameters = new { postString = postToStore.PostString };
                connection.Open();
                var postToReturn = connection.Query<int>(insertQuery, parameters).ToList();
                return postToReturn.First();
            }
        }

        public async void DeleteMicroblogpost(int id)
        {
            using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
            {
                string deleteQuery = "DELETE from microblog WHERE id=@id";
                var parameters = new { id = id };
                connection.Open();
                connection.Query(deleteQuery, parameters);
            }
        }


        public async Task<IList<IMicroblogPost>> GetMicroblogposts()
        {

            try
            {
                var connection = new MySqlConnection(connectionStringBuilder.ConnectionString);

                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
            /*
            using (var connection = new MySqlConnection(connectionStringBuilder.ConnectionString))
            {
                string selectString = "SELECT id, postdata, postdate from microblog";
                connection.Open();
                var postsToReturn = connection.Query<IMicroblogPost>(selectString).ToList();
                return postsToReturn;
            }*/
        }
    }
}
