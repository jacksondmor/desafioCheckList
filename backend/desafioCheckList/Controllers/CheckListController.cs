using desafioCheckList.Core.Response;
using desafioCheckList.Core;
using desafioCheckList.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using static desafioCheckList.Core.CheckList;

namespace desafioCheckList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : Controller
    {
        private readonly ICheckListService _checkListService;
        public CheckListController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }

        [HttpPost()]
        public async Task<IActionResult> Insert(InsertCheckList chekList)
        {
            try
            {
                Result<CheckList> result = await _checkListService.Insert(chekList);

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

                return CreatedAtAction(nameof(GetById), new { result.Value.Id }, retorno);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCheckList chekList)
        {
            try
            {
                Result result = await _checkListService.Update(id, chekList);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Result result = await _checkListService.Delete(id);

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
                Result<CheckList> result = await _checkListService.GetById(id);

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
        public async Task<IActionResult> List([FromQuery] FilterCheckList filter)
        {
            try
            {
                Result<List<CheckList>> result = await _checkListService.List(filter);

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
