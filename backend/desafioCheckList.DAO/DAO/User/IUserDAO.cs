using desafioCheckList.Core.Core;
using static desafioCheckList.Core.Core.User;

namespace desafioCheckList.DAO.DAO
{
    public interface IUserDAO
    {
        Task<User> GetById(int id);
        Task<List<User>?> List(FilterUser filter);
    }
}
