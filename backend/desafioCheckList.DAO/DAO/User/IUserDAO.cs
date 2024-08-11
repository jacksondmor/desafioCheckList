using desafioCheckList.Core.Core;

namespace desafioCheckList.DAO.DAO
{
    public interface IUserDAO
    {
        Task<User> GetById(int id);
    }
}
