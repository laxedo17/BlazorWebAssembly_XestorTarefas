using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWebAssembly_XestorTarefas.Server.Data;
using BlazorWebAssembly_XestorTarefas.Shared;

namespace BlazorWebAssembly_XestorTarefas.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefaItemsController : ControllerBase
    {
        private readonly BlazorWebAssembly_XestorTarefasServerContext _context;

        public TarefaItemsController(BlazorWebAssembly_XestorTarefasServerContext context)
        {
            _context = context;
        }

        // GET: api/TarefaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaItem>>> GetTarefaItem()
        {
            return await _context.TarefaItem.ToListAsync();
        }

        // GET: api/TarefaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaItem>> GetTarefaItem(int id)
        {
            var tarefaItem = await _context.TarefaItem.FindAsync(id);

            if (tarefaItem == null)
            {
                return NotFound();
            }

            return tarefaItem;
        }

        // PUT: api/TarefaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefaItem(int id, TarefaItem tarefaItem)
        {
            if (id != tarefaItem.TarefaItemId)
            {
                return BadRequest();
            }

            _context.Entry(tarefaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TarefaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TarefaItem>> PostTarefaItem(TarefaItem tarefaItem)
        {
            _context.TarefaItem.Add(tarefaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefaItem", new { id = tarefaItem.TarefaItemId }, tarefaItem);
        }

        // DELETE: api/TarefaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaItem(int id)
        {
            var tarefaItem = await _context.TarefaItem.FindAsync(id);
            if (tarefaItem == null)
            {
                return NotFound();
            }

            _context.TarefaItem.Remove(tarefaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaItemExists(int id)
        {
            return _context.TarefaItem.Any(e => e.TarefaItemId == id);
        }
    }
}
