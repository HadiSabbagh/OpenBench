using OpenBench.Models;
using Microsoft.AspNetCore.Mvc;
using OpenBench.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OpenBench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly BrandRepository _repository;

        public BrandsController(BrandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllRows")]
        public async Task<ActionResult<List<Brand>>> GetAllRows()
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
        public async Task<ActionResult> AddRow(Brand entity)
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
        public async Task<ActionResult> Edit(Brand entity)
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

