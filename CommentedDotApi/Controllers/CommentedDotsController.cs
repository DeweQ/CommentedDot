using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommentedDotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentedDotsController : ControllerBase
    {
        List<string> values = new List<string> { "value 0", "value 1", "value 2" };

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<string> GetAll()
        {
            return values;
        }

        [HttpGet]
        [Route("GetById")]
        public string GetById(int id)
        {
            return values[id];
        }

        [HttpDelete]
        [Route("Delete")]
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }
}
