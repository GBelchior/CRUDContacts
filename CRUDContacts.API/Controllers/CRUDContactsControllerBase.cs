using System.Linq;
using CRUDContacts.Interfaces;
using CRUDContacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDContactsControllerBase<T> : ControllerBase where T : ModelBase
    {
        private ICoreBase<T> core;

        public CRUDContactsControllerBase(ICoreBase<T> core)
        {
            this.core = core;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(core.ReadAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            T model = core.Read(c => c.Id == id).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] T model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            core.Create(model);
            return CreatedAtRoute("Get", model.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] T model)
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }

            T dbModel = core.Read(c => c.Id == id).FirstOrDefault();
            if (dbModel == null)
            {
                return NotFound();
            }

            core.Edit(model);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!core.Exists(id))
            {
                return NotFound();
            }

            core.Delete(id);
            return NoContent();
        }
    }
}
