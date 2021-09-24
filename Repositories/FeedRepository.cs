using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dommel;
using Microsoft.Extensions.Configuration;

namespace Eem.App
{
    public class FeedRepository : IFeedRepository
    {
        private readonly IConfiguration _config;

        public FeedRepository(IConfiguration config)
        {
            _config = config;
        }
        public List<Feed> GetFeeds()
        {
            List<Feed> feeds = null;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = _config["ConnectionStrings:EemGaiaDatabase"];
                conexao.Open();
                feeds = conexao.Query<Feed>("select * from Feeds where Priority = 1").ToList();
            }

            return feeds;
        }
    }
}