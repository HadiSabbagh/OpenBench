﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBench.Models;
using OpenBench.Repositories;
using OpenBench.Services;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultsController : ControllerBase
    {
        private readonly ResultService _service;

        public ResultsController(ResultService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<ResultDto>>> GetAllRows()
        {
            var list = await _service.GetAllRows();
            return Ok(list);
        }



        [HttpPost("AddRow")]
        public async Task<IActionResult> AddRow(ResultDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            await _service.AddRow(entity);
            return Ok();
        }

        [HttpPut("EditRow")]
        public async Task<IActionResult> Edit(int id, ResultDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            await _service.UpdateRow(id, entity);
            return Ok();
        }

        [HttpGet("RowDetails")]
        public async Task<IActionResult> Details(int id)
        {
            var found = await _service.GetRowById(id);
            return Ok(found);
        }

        [HttpDelete("DeleteRow")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteRow(id);
            return Ok();
        }
    }
}

