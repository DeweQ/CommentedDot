using CommentedDotApi.Library.DataAccess;
using CommentedDotApi.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CommentedDotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentedDotsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CommentedDotsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("PostDummyData")]
        public void PostDummyData()
        {
            DotModel d1 = new()
            {
                X = 100,
                Y = 100,
                Radius = 100,
                HEXColor = "#ff0000"
            };
            DotModel d2 = new()
            {
                X = 400,
                Y = 200,
                Radius = 50,
                HEXColor = "#0000ff"
            };
            CommentModel c1 = new()
            {
                Text = "Comment 1",
                HEXColor = "#ff0000"
            };
            CommentModel c2 = new()
            {
                Text = "Comment 2",
                HEXColor = "#ff0000"
            };
            CommentModel c3 = new()
            {
                Text = "Comment 3",
                HEXColor = "#0000ff"
            };
            CommentModel c4 = new()
            {
                Text = "Comment 4",
                HEXColor = "#0000ff"
            };
            d1.Comments.AddRange(new[] { c1, c3 });
            d2.Comments.AddRange(new[] { c2, c4 });
            using (_db)
            {
                _db.Comments.AddRange(new[] { c1, c2, c3, c4 });
                _db.Dots.AddRange(new[] { d1, d2 });
                _db.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<DotModel> GetAll()
        {
            List<DotModel> result = new List<DotModel>();

            using (_db)
            { 
                result = _db.Dots.Include(d => d.Comments).ToList();
            }

            return result;
        }

        [HttpDelete]
        [Route("DeleteDot")]
        public void DeleteDot(int id)
        {
            using (_db)
            {
                var removingDot = _db.Dots.FirstOrDefault(d => d.Id == id);
                if (removingDot != null)
                {
                    _db.Dots.Remove(removingDot);
                    _db.SaveChanges();
                }

            }
        }
    }
}
