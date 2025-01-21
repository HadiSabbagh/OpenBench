using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenBench.Models;
using OpenBench.Repositories;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamsController : ControllerBase
    {
        private readonly RamRepository _repository;

        public RamsController(RamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<Ram>>> GetAllRows()
        {
            try
            {
                var list = await _repository.GetAllRows();
                return Ok(list);

            }
            catch (InvalidOperationException e)
            {

                return StatusCode(500, e.Message);
            }
        }



        [HttpPost("AddRow")]
        public async Task<ActionResult> AddRow(Ram entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity cannot be null");
            }
            try
            {
                await _repository.AddRow(entity);
                return Ok();

            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("EditRow")]
        public async Task<ActionResult> Edit(Ram entity)
        {

            try
            {
                await _repository.UpdateRow(entity);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("RowDetails")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var found = await _repository.GetRowById(id);
                return Ok(found);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);
            }


        }

        [HttpDelete("DeleteRow")]
        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                await _repository.DeleteRow(id);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, e.Message);

            }

        }
    }
}
