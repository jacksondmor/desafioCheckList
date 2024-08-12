using desafioCheckList.Core.Response;
using desafioCheckList.Core;
using desafioCheckList.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using static desafioCheckList.Core.InspectionList;

namespace desafioCheckList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InspectionListController : Controller
    {
        private readonly IInspectionListService _inspectionListService;
        public InspectionListController(IInspectionListService inspectionListService)
        {
            _inspectionListService = inspectionListService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Result<InspectionList> result = await _inspectionListService.GetById(id);

                if (result.IsFailed)
                {
                    var response = new Response
                    {
                        Message = result.Errors[0].Message
                    };

                    return (int?)result.Errors[0]?.Metadata["ErrorCode"] != 404
                        ? BadRequest(response)
                        : NotFound(response);
                }

                var retorno = new Response
                {
                    Message = "Operação executada com sucesso!",
                    Data = result.Value
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Message = "Erro ao executar a operação. Tente novamente mais tarde.",
                    ErrorDescription = ex.Message
                });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> List([FromQuery] FilterInspectionList filter)
        {
            try
            {
                Result<List<InspectionList>> result = await _inspectionListService.List(filter);

                if (result.IsFailed)
                {
                    var response = new Response
                    {
                        Message = result.Errors[0].Message
                    };

                    return (int?)result.Errors[0]?.Metadata["ErrorCode"] != 404
                        ? BadRequest(response)
                        : NotFound(response);
                }

                var retorno = new Response
                {
                    Message = "Operação executada com sucesso!",
                    Data = result.Value
                };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Message = "Erro ao executar a operação. Tente novamente mais tarde.",
                    ErrorDescription = ex.Message
                });
            }
        }
    }
}
