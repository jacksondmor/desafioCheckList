using desafioCheckList.Core.Response;
using desafioCheckList.Core;
using desafioCheckList.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using static desafioCheckList.Core.CheckListItem;

namespace desafioCheckList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListItemController : Controller
    {
        private readonly ICheckListItemService _checkListItemService;
        public CheckListItemController(ICheckListItemService checkListItemService)
        {
            _checkListItemService = checkListItemService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string login, UpdateCheckListItem item)
        {
            try
            {
                Result result = await _checkListItemService.Update(id, login, item);

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

                return NoContent();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Result<CheckListItem> result = await _checkListItemService.GetById(id);

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
        public async Task<IActionResult> List([FromQuery] FilterCheckListItem filter)
        {
            try
            {
                Result<List<CheckListItem>> result = await _checkListItemService.List(filter);

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
