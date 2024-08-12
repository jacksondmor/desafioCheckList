using desafioCheckList.Core;
using desafioCheckList.DAO;
using FluentResults;
using static desafioCheckList.Core.CheckList;
using static desafioCheckList.Core.CheckListItem;
using static desafioCheckList.Core.Vehicle_InspectionList;

namespace desafioCheckList.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListDAO _checkListDAO;
        private readonly ICheckListItemDAO _checkListItemDAO;
        private readonly IVehicle_InspectionListDAO _vehicle_InspectionListDAO;
        public CheckListService(ICheckListDAO checkListDAO, ICheckListItemDAO checkListItemDAO, IVehicle_InspectionListDAO vehicle_InspectionListDAO) {
            _checkListDAO = checkListDAO;
            _checkListItemDAO = checkListItemDAO;
            _vehicle_InspectionListDAO = vehicle_InspectionListDAO;
        }
        public async Task<Result<CheckList>> Insert(InsertCheckList checkList)
        {
            List<Vehicle_InspectionList>? lstVehicle_InspectionListDb = await _vehicle_InspectionListDAO.List(new FilterVehicle_InspectionList { IdVehicleType = checkList.IdVehicleType });

            if (lstVehicle_InspectionListDb is null || lstVehicle_InspectionListDb?.Count == 0)
            {
                return Result.Fail(new Error("Veículo não possui lista de inspeção para checklist").WithMetadata("ErrorCode", 404));
            }

            CheckList? checkListDb = await _checkListDAO.Insert(checkList);

            if (checkListDb is null)
            {
                return Result.Fail("Falha na requisição! Verifique e tente novamente.");
            }

            foreach (var insp in lstVehicle_InspectionListDb)
            {
                await _checkListItemDAO.Insert(new CheckListItem
                {
                    IdCheckList = checkListDb.Id,
                    IdVehicle_InspectionList = insp.Id,
                    Status = null,
                    Observation = null,
                    DateCreated = null,
                    DateUpdated = null
                });
            }

            checkListDb.checkListItems = await _checkListItemDAO.List(new FilterCheckListItem { IdCheckList = checkListDb.Id });

            return Result.Ok(checkListDb);
        }
        public async Task<Result> Update(int id, UpdateCheckList checkList)
        {
            CheckList? checkListDb = await _checkListDAO.GetById(id);
            if (checkListDb is null)
            {
                return Result.Fail(new Error("CheckList não encontrado").WithMetadata("ErrorCode", 404));
            }

            UpdateCheckList? checkListUpdate = await _checkListDAO.Update(id, checkList);

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
                return Result.Fail(new Error("CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            checkListDb.checkListItems = await _checkListItemDAO.List(new FilterCheckListItem { IdCheckList = checkListDb.Id });

            return Result.Ok(checkListDb);
        }
        public async Task<Result<List<CheckList>>> List(FilterCheckList filter)
        {
            List<CheckList>? lstCheckListDb = await _checkListDAO.List(filter);

            if (lstCheckListDb is null || lstCheckListDb?.Count == 0)
            {
                return Result.Fail(new Error("CheckList não encontrada").WithMetadata("ErrorCode", 404));
            }

            foreach (var item in lstCheckListDb)
            {
                item.checkListItems = await _checkListItemDAO.List(new FilterCheckListItem { IdCheckList = item.Id });
            }            

            return Result.Ok(lstCheckListDb);
        }
    }
}
