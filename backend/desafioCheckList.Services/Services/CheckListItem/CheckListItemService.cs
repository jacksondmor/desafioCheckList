using desafioCheckList.Core.Core;
using desafioCheckList.DAO.DAO;
using FluentResults;
using static desafioCheckList.Core.Core.CheckListItem;

namespace desafioCheckList.Services.Services
{
    public class CheckListItemService : ICheckListItemService
    {
        private readonly ICheckListItemDAO _checkListItemDAO;
        private readonly ICheckListDAO _checkListDAO;
        private readonly IUserDAO _userDAO;
        public CheckListItemService(ICheckListItemDAO checkListItemDAO, ICheckListDAO checkListDAO, IUserDAO userDAO)
        {
            _checkListItemDAO = checkListItemDAO;
            _checkListDAO = checkListDAO;
            _userDAO = userDAO;
        }
        public async Task<Result<CheckListItem>> Insert(CheckListItem item)
        {
            CheckListItem? itemDb = await _checkListItemDAO.Insert(item);

            if (itemDb is null)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            return Result.Ok(itemDb);
        }
        public async Task<Result> Update(int id, string login, CheckListItem item)
        {
            CheckListItem? itemDb = await _checkListItemDAO.GetById(id);
            if (itemDb is null)
            {
                return Result.Fail(new Error("CheckList não encontrado").WithMetadata("ErrorCode", 404));
            }

            //implementar validação de checklist para mesmo usuario
            CheckList? checkListDb = await _checkListDAO.GetById(item.IdCheckList);
            User? userDb = await _userDAO.GetById(checkListDb.IdUser);
            
            if (userDb.Login != login)
            {
                return Result.Fail("Este CheckList já foi iniciado por outro usuário!");
            }

            CheckListItem? itemUpdate = await _checkListItemDAO.Update(item);

            if (itemUpdate is null)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            return Result.Ok();
        }
        public async Task<Result<CheckListItem>> GetById(int id)
        {
            CheckListItem? checkListItemDb = await _checkListItemDAO.GetById(id);

            if (checkListItemDb is null)
            {
                return Result.Fail(new Error("Lista de Inspeções do CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(checkListItemDb);
        }
        public async Task<Result<List<CheckListItem>>> List(FilterCheckListItem filter)
        {
            List<CheckListItem>? lstCheckListItemDb = await _checkListItemDAO.List(filter);

            if (lstCheckListItemDb is null || lstCheckListItemDb?.Count == 0)
            {
                return Result.Fail(new Error("Lista de Inspeções do CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(lstCheckListItemDb);
        }
    }
}
