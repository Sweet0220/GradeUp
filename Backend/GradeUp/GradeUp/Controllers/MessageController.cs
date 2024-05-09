using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService messageService;
        public MessageController()
        {
            messageService = new MessageService();
        }

        [HttpGet("id/{id}")]
        public IActionResult getMesageById(long id)
        {
            Message message = messageService.getMessageById(id);

            if (message != null)
            {
                return Ok(message);
            }
            return NotFound("Message not found.");
        }


        [HttpGet("chat/id/{id}")]
        public IActionResult getMessageByChatId(long id_chat)
        {
            List<Message> messages = messageService.getMessageByChatId(id_chat);
            if (messages != null)
            {
                return Ok(messages);
            }
            return NotFound("User's chat not found");
        }
    }
}
