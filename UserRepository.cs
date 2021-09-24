using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Eem.App
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }
        public decimal getUsersPercentage(Perfil perfil)
        {
            decimal total = 0;
            decimal totalByPerfil = 0;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = _config["ConnectionStrings:EemGaiaDatabase"];
                conexao.Open();
                total = conexao.ExecuteScalar<decimal>("select count(*) from UsuariosCadastrados");
                totalByPerfil = conexao.ExecuteScalar<decimal>($"select count(*) from UsuariosCadastrados where Perfil = '{perfil.name}'");
            }

            if (perfil.name == "total") return total;

            return totalByPerfil / total;
        }
    }
}