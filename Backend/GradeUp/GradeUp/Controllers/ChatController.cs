using GradeUp.Entities;
using GradeUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService chatService;
        public ChatController()
        {
            chatService = new ChatService();
        }

        [HttpGet("id/{id}")]
        public IActionResult getChatById(long id)
        {
            Chat chat = chatService.getChatById(id);

            if (chat != null)
            {
                return Ok(chat);
            }
            return NotFound("Subject not found.");
        }

        ///?????

        [HttpGet("user/id/{id_user1}")]
        public IActionResult getChatByUserId1(long id_user1)
        {
            List<Chat> chat = chatService.getChatByUserId1(id_user1);
            if (chat != null)
            {
                return Ok(chat);
            }
            return NotFound("User's chat not found");
        }

        [HttpGet("user/id/{id_user2}")]
        public IActionResult getChatByUserId2(long id_user2)
        {
            List<Chat> chat = chatService.getChatByUserId1(id_user2);
            if (chat != null)
            {
                return Ok(chat);
            }
            return NotFound("User's chat not found");
        }

        [HttpPut]
        public IActionResult updateChat(Chat chat)
        {
            try
            {
                if (chat == null)
                {
                    return BadRequest("Invalid chat data.");
                }
                chatService.updateChat(chat);
                return Ok("The chat's data was updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id/{id}")]
        public IActionResult deleteChatById(long id)
        {
            try
            {
                Chat chat = chatService.getChatById(id);
                if (chat == null)
                {
                    return NotFound("Chat not found.");
                }
                chatService.removeChat(id);
                return Ok("The chosen chat was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("user/id/{id_user}")]
        public IActionResult deleteChatByUserId(long id_user)
        {
            try
            {
                chatService.deleteChatByUserId(id_user);
                return Ok("The chosen chat was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
