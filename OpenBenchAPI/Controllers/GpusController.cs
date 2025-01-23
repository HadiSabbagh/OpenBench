using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBench.Models;
using OpenBench.Models.Dtos;
using OpenBench.Repositories;
using OpenBench.Services;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GpusController : ControllerBase
    {
        private readonly GpuService _service;

        public GpusController(GpuService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<GpuDto>>> GetAllRows()
        {
            try
            {
                var list = await _service.GetAllRows();
                return Ok(list);

            }
            catch (InvalidOperationException e)
            {

                return StatusCode(500, e.Message);
            }
        }



        [HttpPost("AddRow")]
        public async Task<IActionResult> AddRow(GpuDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            try
            {
                await _service.AddRow(entity);
                return Ok();

            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("EditRow")]
        public async Task<IActionResult> Edit(int id, GpuDto entity)
        {

            try
            {
                await _service.UpdateRow(id, entity);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("RowDetails")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var found = await _service.GetRowById(id);
                return Ok(found);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }


        }

        [HttpDelete("DeleteRow")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _service.DeleteRow(id);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);

            }

        }
    }
}
