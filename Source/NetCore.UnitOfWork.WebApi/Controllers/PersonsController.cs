using Microsoft.AspNetCore.Mvc;
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
        private IUnitOfWork _uow { get; set; }

        public PersonsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _uow.Persons.Get(id);

            return Ok(person);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageParams page)
        {
            var persons = await _uow.Persons.Get(c => true, page.PageNumber, page.PageSize);

            return Ok(persons);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Person person)
        {
            await _uow.Persons.Add(person);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Person person)
        {
            await _uow.Persons.Update(person);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _uow.Persons.Delete(id);
            await _uow.Commit();

            return Ok();
        }
    }
}
