using desafioCheckList.Core;
using desafioCheckList.DAO;
using FluentResults;
using static desafioCheckList.Core.User;

namespace desafioCheckList.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;
        public UserService(IUserDAO userDAO) {
            _userDAO = userDAO;
        }
        public async Task<Result<User>> GetById(int id)
        {
            User? userDb = await _userDAO.GetById(id);

            if (userDb is null)
            {
                return Result.Fail(new Error("Usuário não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(userDb);
        }
        public async Task<Result<List<User>>> List(FilterUser filter)
        {
            List<User>? ltsUserDb = await _userDAO.List(filter);

            if (ltsUserDb is null || ltsUserDb?.Count == 0)
            {
                return Result.Fail(new Error("Usuário não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(ltsUserDb);
        }
    }
}
