using Microsoft.AspNetCore.Mvc;
using TodosTask.Models.Entities;
using TodoTask.Data;
using TodoTask.Models.DTO;

namespace TodoTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly TodoDbContext dbContext;

        public TestController(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddList(AddListRequest addListRequest)
        {
            var todoL = new TodoList()
            {
                Title = addListRequest.Title
            };

            todoL.ListId = addListRequest.ListId;
            await dbContext.TodoLists.AddAsync(todoL);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(AddList), todoL);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var todoL = dbContext.TodoLists.ToList();
            return Ok(todoL);
        }

        [HttpGet]
        [Route("id")]

        public async Task<ActionResult> GetList(int id, AddListRequest addListRequest)
        {
            var TodoT = dbContext.TodoLists.Find(addListRequest.ListId);
            if (TodoT != null)
            {
                return Ok(TodoT);
            }
            else
                return BadRequest();
        }


        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var TodoL = dbContext.TodoLists.ToList();
            var tlist = TodoL.Find(l => l.ListId == id);
            if (tlist != null)
            {
                dbContext.TodoLists.Remove(tlist);
                dbContext.SaveChanges();
                return Ok(TodoL);

            }
            return BadRequest("not found");
        }

        [HttpPut]
        public async Task<IActionResult> PutList(int id, AddListRequest addListRequest)
        {
            var Tnew = new TodoList()
            {
                Title = addListRequest.Title
            };

            var Elist = dbContext.TodoLists.Find(addListRequest.ListId);

            if (Elist != null)
            {
                Elist.Title = Tnew.Title;

                dbContext.SaveChanges();
                return Ok(Elist);
            }
            else
                return BadRequest();
        }

        //[HttpPut]
        //public async Task<IActionResult> PutList(int id, AddListRequest addListRequest)
        //{
        //    var Elist = dbContext.TodoLists.Find(addListRequest.ListId);

        //    if (Elist != null)
        //    {
        //        Elist.Title = addListRequest.Title;
        //        dbContext.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //        return NotFound();
        //}

    }
}

