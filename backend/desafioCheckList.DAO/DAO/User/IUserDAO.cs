using desafioCheckList.Core;
using static desafioCheckList.Core.User;

namespace desafioCheckList.DAO
{
    public interface IUserDAO
    {
        Task<User> GetById(int id);
        Task<List<User>?> List(FilterUser filter);
    }
}
