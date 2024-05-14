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

        [HttpPost]
        public IActionResult addSubject(Message message)
        {
            try
            {
                if (message == null)
                {
                    return BadRequest("Invalid message data.");
                }
                messageService.addMessage(message);
                return Ok("New message added!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult updateMessaget(Message message)
        {
            try
            {
                if (message == null)
                {
                    return BadRequest("Invalid message data.");
                }
                messageService.updateMessage(message);
                return Ok("The message's data was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteMessageById(long id)
        {
            try
            {
                Message message = messageService.getMessageById(id);
                if (message == null)
                {
                    return NotFound("Message not found.");
                }
                messageService.removeMessage(id);
                return Ok("The chosen message was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("chat/id/{id_chat}")]
        public IActionResult deleteMessageByChatId(long id_chat)
        {
            try
            {
                messageService.deleteMessageByChatId(id_chat);
                return Ok("The chosen message was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
