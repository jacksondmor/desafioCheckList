using desafioCheckList.Core.Core;
using FluentResults;
using static desafioCheckList.Core.Core.InspectionList;

namespace desafioCheckList.Services.Services
{
    public interface IInspectionListService
    {        
        Task<Result<InspectionList>> GetById(int id);
        Task<Result<List<InspectionList>>> List(FilterInspectionList filter);
    }
}
