using desafioCheckList.Core.Core;
using FluentResults;
using static desafioCheckList.Core.Core.User;

namespace desafioCheckList.Services.Services
{
    public interface IUserService
    {
        Task<Result<User>> GetById(int id);
        Task<Result<List<User>>> List(FilterUser filter);
    }
}
