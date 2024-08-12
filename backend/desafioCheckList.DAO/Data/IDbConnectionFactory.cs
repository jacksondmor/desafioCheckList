using System.Data.SqlClient;

namespace desafioCheckList.DAO.Data
{
    public interface IDbConnectionFactory : IDisposable
    {
        SqlConnection GetConnDbDesafioCheckList();
    }
}
