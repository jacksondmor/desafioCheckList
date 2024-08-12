using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.User;

namespace desafioCheckList.Services
{
    public interface IUserService
    {
        Task<Result<User>> GetById(int id);
        Task<Result<List<User>>> List(FilterUser filter);
    }
}
