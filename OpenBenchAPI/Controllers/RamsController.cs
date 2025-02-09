using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBench.Models;
using OpenBench.Repositories;
using OpenBench.Services;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamsController : ControllerBase
    {
        private readonly RamService _service;

        public RamsController(RamService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<RamDto>>> GetAllRows()
        {
            var list = await _service.GetAllRows();
            return Ok(list);
        }



        [HttpPost("AddRow")]
        public async Task<ActionResult> AddRow(RamDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            await _service.AddRow(entity);
            return Ok();
        }

        [HttpPut("EditRow")]
        public async Task<ActionResult> Edit(int id, RamDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            await _service.UpdateRow(id, entity);
            return Ok();

        }

        [HttpGet("RowDetails")]
        public async Task<ActionResult> Details(int id)
        {
            var found = await _service.GetRowById(id);
            return Ok(found);
        }

        [HttpDelete("DeleteRow")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteRow(id);
            return Ok();
        }
    }
}
