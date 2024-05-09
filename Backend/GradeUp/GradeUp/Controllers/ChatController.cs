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

        [HttpGet("user/id/{id}")]
        public IActionResult getChatByUserId1(long id_user1)
        {
            List<Chat> chat = chatService.getChatByUserId1(id_user1);
            if (chat != null)
            {
                return Ok(chat);
            }
            return NotFound("User's chat not found");
        }

        /*[HttpPut]
        public IActionResult updateChat(Chat chat) 
        {
            try
            {
                if(chat == null)
                {
                    return BadRequest("Invalid chat information");
                }
               chatService.update_chat
            }
        }*/


    }
}
