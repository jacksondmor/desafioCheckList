using desafioCheckList.Core.Response;
using desafioCheckList.Core;
using desafioCheckList.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using static desafioCheckList.Core.Vehicle_InspectionList;

namespace desafioCheckList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Vehicle_InspectionListController : Controller
    {
        private readonly IVehicle_InspectionListService _vehicle_InspectionListService;
        public Vehicle_InspectionListController(IVehicle_InspectionListService vehicle_InspectionListService)
        {
            _vehicle_InspectionListService = vehicle_InspectionListService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Result<Vehicle_InspectionList> result = await _vehicle_InspectionListService.GetById(id);

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
        public async Task<IActionResult> List([FromQuery] FilterVehicle_InspectionList filter)
        {
            try
            {
                Result<List<Vehicle_InspectionList>> result = await _vehicle_InspectionListService.List(filter);

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
