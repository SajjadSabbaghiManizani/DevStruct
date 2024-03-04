﻿using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TModel> : Controller where TModel : BaseEntity
    {
        private readonly IGenericRepository<TModel> _repository;

        public GenericController(IGenericRepository<TModel> repository)
        {
            _repository = repository;
        }

        // GET: /api/[controller]
        public async Task<IActionResult> Get()
        {
            var models = await _repository.GetAllAsync();
            return Ok(models);
        }

        // GET: /api/[controller]/5
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST: /api/[controller] 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.InsertAsync(model);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        // PUT: /api/[controller]/5
        [HttpPut]
        public async Task<IActionResult> Put(Guid id, [FromBody] TModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repository.UpdateAsync(model);
            }
            catch
            {
                if (await ModelExists(id))
                {
                    throw;

                }
                else
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // DELETE: /api/[controller]/5
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(model);

            return NoContent();
        }

        private async Task<bool> ModelExists(Guid id)
        {
            
            return  await _repository.GetByIdAsync(id);
        }
    }

}