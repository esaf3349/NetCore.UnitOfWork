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
    public class MessagesController : ControllerBase
    {
        private readonly IUnitOfWork Uow;
        private readonly ILogger<MessagesController> Logger;

        public MessagesController(IUnitOfWork uow, ILogger<MessagesController> logger)
        {
            Uow = uow;
            Logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var message = await Uow.Messages.Get(id);

            return Ok(message);
        }

        [HttpGet]
        [Route("/api/chats/{chatId:int}/messages")]
        public async Task<IActionResult> Get(int chatId, [FromQuery] PageParams page)
        {
            var messages = await Uow.Messages.Get(c => c.ChatId == chatId, page.PageNumber, page.PageSize);

            return Ok(messages);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Message message)
        {
            await Uow.Messages.Add(message);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Message message)
        {
            await Uow.Messages.Update(message);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Uow.Messages.Delete(id);
            await Uow.Commit();

            return Ok();
        }
    }
}
