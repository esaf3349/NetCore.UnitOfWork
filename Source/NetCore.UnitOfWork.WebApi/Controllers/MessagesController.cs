using Microsoft.AspNetCore.Mvc;
using NetCore.UnitOfWork.Core.Entities;
using NetCore.UnitOfWork.Interfaces;
using NetCore.UnitOfWork.WebApi.Common.Pagination;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private IUnitOfWork _uow { get; set; }

        public MessagesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await _uow.Messages.Get(id);

            return Ok(message);
        }

        [HttpGet]
        [Route("/api/chats/{chatId:int}/messages")]
        public async Task<IActionResult> Get(int chatId, [FromQuery] PageParams page)
        {
            var messages = await _uow.Messages.Get(c => c.ChatId == chatId, page.PageNumber, page.PageSize);

            return Ok(messages);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Message message)
        {
            await _uow.Messages.Add(message);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Message message)
        {
            await _uow.Messages.Update(message);
            await _uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _uow.Messages.Delete(id);
            await _uow.Commit();

            return Ok();
        }
    }
}
