using Application.Filters;
using Application.Models;
using Application.Services.Contracts;
using CrossCutting.Enum;
using CrossCutting.Helpers;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;
        private readonly Guid _logId = Guid.NewGuid();

        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Add a new
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Property</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PropertyDto model)
        {
            try
            {
                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<PropertyDto>.AddResponse(
                            result: await _service.AddAsync(model),
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                        ResponseHelper<ErrorHelper>.AddResponse(
                            result: ErrorHelper.AddError(ex),
                            success: ResponseHttpMessageEnum.Error.Success,
                            statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                            message: ResponseHttpMessageEnum.Error.Message,
                            eventId: _logId
                        ));
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] Expression<Func<PropertyEntity, bool>> predicate = null, [FromQuery] Func<IQueryable<PropertyEntity>, IOrderedQueryable<PropertyEntity>> orderBy = null)
        {
            try
            {
                var result = await _service.GetAllAsync(predicate, orderBy);

                if (result == null)
                {
                    return StatusCode(ResponseHttpMessageEnum.NotFound.StatusCode,
                            ResponseHelper<string>.AddResponse(
                                result: null,
                                success: ResponseHttpMessageEnum.NotFound.Success,
                                statusCode: ResponseHttpMessageEnum.NotFound.StatusCode,
                                message: ResponseHttpMessageEnum.NotFound.Message
                            ));
                }

                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<IList<PropertyDto>>.AddResponse(
                            result: result,
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                        ResponseHelper<ErrorHelper>.AddResponse(
                            result: ErrorHelper.AddError(ex),
                            success: ResponseHttpMessageEnum.Error.Success,
                            statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                            message: ResponseHttpMessageEnum.Error.Message,
                            eventId: _logId
                        ));
            }
        }

        /// <summary>
        /// Get a
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _service.GetAsync(id);

                if (result == null)
                {
                    return StatusCode(ResponseHttpMessageEnum.NotFound.StatusCode,
                            ResponseHelper<string>.AddResponse(
                                result: null,
                                success: ResponseHttpMessageEnum.NotFound.Success,
                                statusCode: ResponseHttpMessageEnum.NotFound.StatusCode,
                                message: ResponseHttpMessageEnum.NotFound.Message
                            ));
                }

                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<PropertyDto>.AddResponse(
                            result: result,
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                        ResponseHelper<ErrorHelper>.AddResponse(
                            result: ErrorHelper.AddError(ex),
                            success: ResponseHttpMessageEnum.Error.Success,
                            statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                            message: ResponseHttpMessageEnum.Error.Message,
                            eventId: _logId
                        ));
            }
        }

        /// <summary>
        /// Get all paginated
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Paged")]
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page, [FromQuery] int take)
        {
            try
            {
                var result = await _service.GetPagedAsync(page, take);

                if (result == null)
                {
                    return StatusCode(ResponseHttpMessageEnum.NotFound.StatusCode,
                            ResponseHelper<string>.AddResponse(
                                result: null,
                                success: ResponseHttpMessageEnum.NotFound.Success,
                                statusCode: ResponseHttpMessageEnum.NotFound.StatusCode,
                                message: ResponseHttpMessageEnum.NotFound.Message
                            ));
                }

                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<DataCollection<PropertyDto>>.AddResponse(
                            result: result,
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                        ResponseHelper<ErrorHelper>.AddResponse(
                            result: ErrorHelper.AddError(ex),
                            success: ResponseHttpMessageEnum.Error.Success,
                            statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                            message: ResponseHttpMessageEnum.Error.Message,
                            eventId: _logId
                        ));
            }
        }

        /// <summary>
        /// Remove a
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            try
            {
                var any = await _service.ExistAsync(id);
                if (!any)
                {
                    return StatusCode(ResponseHttpMessageEnum.NotFound.StatusCode,
                            ResponseHelper<string>.AddResponse(
                                result: null,
                                success: ResponseHttpMessageEnum.NotFound.Success,
                                statusCode: ResponseHttpMessageEnum.NotFound.StatusCode,
                                message: ResponseHttpMessageEnum.NotFound.Message
                            ));
                }

                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<bool>.AddResponse(
                            result: await _service.RemoveAsync(id),
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                        ResponseHelper<ErrorHelper>.AddResponse(
                            result: ErrorHelper.AddError(ex),
                            success: ResponseHttpMessageEnum.Error.Success,
                            statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                            message: ResponseHttpMessageEnum.Error.Message,
                            eventId: _logId
                        ));
            }
        }

        /// <summary>
        /// Update a
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PropertyDto model)
        {
            if (model.Id != id)
            {
                return StatusCode(ResponseHttpMessageEnum.InvalidModel.StatusCode,
                        ResponseHelper<string>.AddResponse(
                            result: null,
                            success: ResponseHttpMessageEnum.InvalidModel.Success,
                            statusCode: ResponseHttpMessageEnum.InvalidModel.StatusCode,
                            message: ResponseHttpMessageEnum.InvalidModel.Message
                        ));
            }
            try
            {
                var any = await _service.ExistAsync(id);
                if (!any)
                {
                    return StatusCode(ResponseHttpMessageEnum.NotFound.StatusCode,
                            ResponseHelper<string>.AddResponse(
                                result: null,
                                success: ResponseHttpMessageEnum.NotFound.Success,
                                statusCode: ResponseHttpMessageEnum.NotFound.StatusCode,
                                message: ResponseHttpMessageEnum.NotFound.Message
                            ));
                }

                return StatusCode(ResponseHttpMessageEnum.Ok.StatusCode,
                        ResponseHelper<PropertyDto>.AddResponse(
                            result: await _service.UpdateAsync(model),
                            success: ResponseHttpMessageEnum.Ok.Success,
                            statusCode: ResponseHttpMessageEnum.Ok.StatusCode,
                            message: ResponseHttpMessageEnum.Ok.Message
                        ));
            }
            catch (Exception ex)
            {
                return StatusCode(ResponseHttpMessageEnum.Error.StatusCode,
                         ResponseHelper<ErrorHelper>.AddResponse(
                             result: ErrorHelper.AddError(ex),
                             success: ResponseHttpMessageEnum.Error.Success,
                             statusCode: ResponseHttpMessageEnum.Error.StatusCode,
                             message: ResponseHttpMessageEnum.Error.Message,
                             eventId: _logId
                         ));
            }
        }
    }
}
