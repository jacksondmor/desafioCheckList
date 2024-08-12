using desafioCheckList.Core;
using FluentResults;
using static desafioCheckList.Core.InspectionList;

namespace desafioCheckList.Services
{
    public interface IInspectionListService
    {        
        Task<Result<InspectionList>> GetById(int id);
        Task<Result<List<InspectionList>>> List(FilterInspectionList filter);
    }
}
