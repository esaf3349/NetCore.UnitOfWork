using Microsoft.AspNetCore.Mvc;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.Interfaces;
using NetCore.UnitOfWork.WebApi.Common.Pagination;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private IUnitOfWork _uow { get; set; }

        public ChatsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var chat = await _uow.Chats.Get(id);

            return Ok(chat);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageParams page)
        {
            var chats = await _uow.Chats.Get(c => true, page.PageNumber, page.PageSize);

            return Ok(chats);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Chat chat)
        {
            await _uow.Chats.Add(chat);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Chat chat)
        {
            await _uow.Chats.Update(chat);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _uow.Chats.Delete(id);
            await _uow.Commit();

            return Ok();
        }
    }
}
