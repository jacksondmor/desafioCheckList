using System.Data;
using System.Data.SqlClient;

namespace desafioCheckList.DAO.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly SqlConnection _connDbDesafioCheckList;

        public DbConnectionFactory(string connDbDesafioCheckList)
        {
            _connDbDesafioCheckList = new SqlConnection(connDbDesafioCheckList);           
        }

        public SqlConnection GetConnDbDesafioCheckList()
        {
            if (_connDbDesafioCheckList.State == ConnectionState.Closed) _connDbDesafioCheckList.Open();

            return _connDbDesafioCheckList;
        }

        public void Dispose()
        {
            _connDbDesafioCheckList.Close();
        }
    }
}
