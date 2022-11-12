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
    public class ChatsController : ControllerBase
    {
        private readonly IUnitOfWork Uow;
        private readonly ILogger<ChatsController> Logger;

        public ChatsController(IUnitOfWork uow, ILogger<ChatsController> logger)
        {
            Uow = uow;
            Logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var chat = await Uow.Chats.Get(id);

            return Ok(chat);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] PageParams page)
        {
            var chats = await Uow.Chats.Get(c => true, page.PageNumber, page.PageSize);

            return Ok(chats);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] Chat chat)
        {
            await Uow.Chats.Add(chat);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] Chat chat)
        {
            await Uow.Chats.Update(chat);
            await Uow.Commit();

            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Uow.Chats.Delete(id);
            await Uow.Commit();

            return Ok();
        }
    }
}
