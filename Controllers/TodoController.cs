using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using paginacao.Data;
using paginacao.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace paginacao.Controllers
{
    [Route("v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet("load")]
        public async Task<ActionResult> LoadAsync([FromServices] AppDbContext context)
        {
            for (int i = 0; i < 1348; i++)
            {
                var todo = new Todo()
                {
                    Id = i + 1,
                    Done = false,
                    CreatedAt = DateTime.Now,   
                    Title = $"Tarefa {i}"
                };
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("skip/{skip:int}/take/{take:int}")]
        public async Task<ActionResult> GetAsync([FromServices] AppDbContext context,int skip = 0, int take = 25)
        {
            //Caso queira barrar o numero de requisições
            //if (take > 1000)
            //    return BadRequest();
            var total = await context.Todos.CountAsync();
            var todos = await context
                .Todos
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return Ok(new { total, skip, take, data = todos });
        }
    }
}
