using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using TodosTask.Models.Entities;
using TodoTask.Data;

namespace TodoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoCon : ControllerBase
    {
        private readonly TodoDbContext dbContext;

        TodoCon(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
                }

        [HttpGet]
        public async Task<ActionResult<List<TodoList>>> Get()
        {
            return Ok(this.dbContext.TodoLists.FindAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> Get(int id)
        {
            return null;
            /*
            var tlist = TodoL.Find(l => l.ListId == id);
            if (tlist == null)
                return BadRequest("not found");
            return Ok(tlist);*/
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoList>>> AddList([FromBody] TodoList tlist)
        {
            return null;
          //  TodoL.Add(tlist);


            // add to database
            // need to find a way to connect to the database

           // return Ok(TodoL);
        }

        [HttpPut]
        public async Task<ActionResult<List<TodoList>>> UpdateList(TodoList request)
        {
            return null;
        /*    var tlist = TodoL.Find(l => l.ListId == request.ListId);
            if (tlist == null)
                return BadRequest("not found");

            tlist.Title = request.Title;
            tlist.ListId = request.ListId;
            tlist.TodoW = request.TodoW;

            return Ok(tlist);*/
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TodoList>>> Delete(int id)
        {
            return null;
            /*
            var tlist = TodoL.Find(l => l.ListId == id);
            if (tlist == null)
                return BadRequest("not found");

            TodoL.Remove(tlist);
            return Ok(tlist);*/
        }

        /*[HttpGet("{id}")]
        public async Task<ActionResult<TodoWork>> Gett(int id)
        {
            var ttask = TodoW.Find(t => t.TodoId == id);
            if (ttask == null)
                return BadRequest("not found");
            return Ok(ttask);
        }*/


      


        /* [HttpPut]
         public async Task<ActionResult<List<TodoWork>>> UpdateTask(TodoWork request)
         {
             return null;
             var ttask = TodoL.Find(t => t.ListId == request.ListId);
             if (ttask == null)
                 return BadRequest("not found");



             return Ok(tlist);
         }*/

    }
        
}
