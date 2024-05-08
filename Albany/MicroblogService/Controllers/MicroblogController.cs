using Microblog.Data.Models.Interfaces;
using Microblog.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroblogService.Controllers
{
    [ApiController]
    [Route("api/microblog")]
    public class MicroblogController : ControllerBase
    {
        private readonly IMicroblogpostService microblogService;


        public MicroblogController(IMicroblogpostService microblogService)
        {
            this.microblogService = microblogService;
        }


        [HttpGet]
        public IActionResult GetPosts() {
            try
            {
                IList<IMicroblogPost> posts = this.microblogService.GetAllMicroblogPosts();
                return Ok(posts);
            }catch (Exception ex) { 
                return NotFound("No posts found! Post something first!");
            }
        }

        [HttpPost]
        public IActionResult PostMicroblog(string postData)
        {
            return Ok(this.microblogService.CreateMicroblogPost(postData));
        }

        [HttpDelete]
        public IActionResult DeleteMicroblog(int id) {
            try
            {
                this.microblogService.DeleteMicroblogPost(id);
                return Ok();
            }  catch (Exception ex)
            {
                return NotFound("No such post exists");
            }
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult GetMicroblogPost(int id) {
            try
            {
                var post = this.microblogService.GetMicroblogPost(id);
                return Ok(post.PostString);

            }catch(Exception ex)
            {
                return NotFound($"No post with id {id} found");
            }
        }


    }
}
