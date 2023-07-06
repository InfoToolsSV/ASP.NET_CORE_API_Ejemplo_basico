using APIRestFul.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIRestFul.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private static List<Item> items = new();

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            items.Add(item);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Item item)
        {
            int index = items.FindIndex(i => i.Id == id);

            if (index != -1)
            {
                items[index] = item;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             int index = items.FindIndex(i => i.Id == id);

            if (index != -1)
            {
                items.RemoveAt(index);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}