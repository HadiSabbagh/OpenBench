using OpenBench.Models;
using Microsoft.AspNetCore.Mvc;
using OpenBench.Repositories;
using Microsoft.EntityFrameworkCore;
using OpenBench.Services;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly BrandService _service;

        public BrandsController(BrandService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<BrandDto>>> GetAllRows()
        {
            var list = await _service.GetAllRows();
            return Ok(list);
        }



        [HttpPost("AddRow")]
        public async Task<ActionResult> AddRow(BrandDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            await _service.AddRow(entity);
            return Created();
        }

        [HttpPut("EditRow")]
        public async Task<ActionResult> Edit(int id, BrandDto entity)
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

