using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.Interfaces;
using NetCore.UnitOfWork.WebApi.Common.Pagination;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IUnitOfWork Uow;
        private readonly ILogger<PersonsController> Logger;

        public PersonsController(IUnitOfWork uow, ILogger<PersonsController> logger)
        {
            Uow = uow;
            Logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await Uow.Persons.Get(id);

            return Ok(person);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageParams page)
        {
            var persons = await Uow.Persons.Get(c => true, page.PageNumber, page.PageSize);

            return Ok(persons);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Person person)
        {
            await Uow.Persons.Add(person);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            await Uow.Persons.Update(person);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Uow.Persons.Delete(id);
            await Uow.Commit();

            return Ok();
        }
    }
}
