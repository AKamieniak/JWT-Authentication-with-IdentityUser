using System;
using System.Net;
using System.Threading.Tasks;
using JWT.Infrastructure.Interfaces;
using JWT.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    public class BaseController<TEntity> : ResultController where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public BaseController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Add([FromBody] TEntity entity)
        {
            try
            {
                await _repository.Add(entity);
                await _repository.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetById(id);

                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entity = await _repository.GetAll();

                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);
                await _repository.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
