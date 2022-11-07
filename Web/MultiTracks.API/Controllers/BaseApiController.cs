﻿using Microsoft.AspNetCore.Mvc;
using MultiTracks.API.Core;
using MultiTracks.API.Extensions;

namespace MultiTracks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
                return Ok(result);
            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result);
        }

        protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null)
            {
                Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize, result.Value.TotalCount, result.Value.TotalPages);
                return Ok(result.Value);
            }

            if (result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
