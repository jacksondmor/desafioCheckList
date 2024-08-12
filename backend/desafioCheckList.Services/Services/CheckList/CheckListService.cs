using desafioCheckList.Core.Core;
using desafioCheckList.DAO.DAO;
using FluentResults;
using static desafioCheckList.Core.Core.CheckList;
using static desafioCheckList.Core.Core.CheckListItem;

namespace desafioCheckList.Services.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListDAO _checkListDAO;
        public CheckListService(ICheckListDAO checkListDAO) {
            _checkListDAO = checkListDAO;
        }
        public async Task<Result<CheckList>> Insert(CheckList checkList)
        {
            CheckList? checkListDb = await _checkListDAO.Insert(checkList);

            if (checkListDb is null)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            return Result.Ok(checkListDb);
        }
        public async Task<Result> Update(int id, CheckList checkList)
        {
            CheckList? checkListDb = await _checkListDAO.GetById(id);
            if (checkListDb is null)
            {
                return Result.Fail(new Error("CheckList não encontrado").WithMetadata("ErrorCode", 404));
            }

            CheckList? checkListUpdate = await _checkListDAO.Update(checkList);

            if (checkListUpdate is null)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            return Result.Ok();
        }
        public async Task<Result> Delete(int id)
        {
            CheckList? checkListDb = await _checkListDAO.GetById(id);

            if (checkListDb is null)
            {
                return Result.Fail(new Error("CheckList não encontrado").WithMetadata("ErrorCode", 404));
            }

            if (await _checkListDAO.Delete(id) == false)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            return Result.Ok();
        }
        public async Task<Result<CheckList>> GetById(int id)
        {
            CheckList? checkListDb = await _checkListDAO.GetById(id);

            if (checkListDb is null)
            {
                return Result.Fail(new Error("Lista de Inspeções do CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(checkListDb);
        }
        public async Task<Result<List<CheckList>>> List(FilterCheckList filter)
        {
            List<CheckList>? lstCheckListDb = await _checkListDAO.List(filter);

            if (lstCheckListDb is null || lstCheckListDb?.Count == 0)
            {
                return Result.Fail(new Error("Lista de Inspeções do CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(lstCheckListDb);
        }
    }
}
