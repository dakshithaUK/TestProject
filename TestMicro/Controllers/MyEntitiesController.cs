using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMicro.Models;
using TestMicro.Services;

namespace TestMicro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyEntitiesController : ControllerBase
    {

        private readonly MyEntityService _service;

        public MyEntitiesController(MyEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MyEntity>>> Get()
        {
            var entities = await _service.GetAllEntitiesAsync();
            foreach (var entity in entities)
            {
                Console.WriteLine($"Entity ID: {entity.Id}, Name: {entity.Name}");               
            }

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyEntity>> Get(int id)
        {
            var entity = await _service.GetEntityByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

    }
}