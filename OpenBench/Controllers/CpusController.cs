using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBench.Models;
using OpenBench.Repositories;
using OpenBench.Services;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CpusController : ControllerBase
    {
        private readonly CpuService service;

        public CpusController(CpuService cpuService)
        {
            service = cpuService;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<CpuDto>>> GetAllRows()
        {
            try
            {
                var list = await service.GetAllRows();
                return Ok(list);

            }
            catch (InvalidOperationException e)
            {

                return StatusCode(500, e.Message);
            }
        }



        [HttpPost("AddRow")]
        public async Task<IActionResult> AddRow(CpuDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            try
            {
                await service.AddRow(entity);
                return Ok();

            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("EditRow")]
        public async Task<IActionResult> Edit(CpuDto entity)
        {

            try
            {
                await service.UpdateRow(entity);
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
                var found = await service.GetRowById(id);
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
                await service.DeleteRow(id);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);

            }

        }
    }
}
