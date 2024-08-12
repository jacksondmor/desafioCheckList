using desafioCheckList.Core.Core;
using desafioCheckList.DAO.DAO;
using FluentResults;
using static desafioCheckList.Core.Core.InspectionList;

namespace desafioCheckList.Services.Services
{
    public class InspectionListService : IInspectionListService
    {
        private readonly IInspectionListDAO _inspectionListDAO;
        public InspectionListService(IInspectionListDAO inspectionListDAO) {
            _inspectionListDAO = inspectionListDAO;
        }
        public async Task<Result<InspectionList>> GetById(int id)
        {
            InspectionList? inspectionListDb = await _inspectionListDAO.GetById(id);

            if (inspectionListDb is null)
            {
                return Result.Fail(new Error("Inspeção não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(inspectionListDb);
        }
        public async Task<Result<List<InspectionList>>> List(FilterInspectionList filter)
        {
            List<InspectionList>? ltsInspectionListDb = await _inspectionListDAO.List(filter);

            if (ltsInspectionListDb is null || ltsInspectionListDb?.Count == 0)
            {
                return Result.Fail(new Error("Lista de Inspeções não encontrado").WithMetadata("ErrorCode", 404));
            }

            return Result.Ok(ltsInspectionListDb);
        }
    }
}
