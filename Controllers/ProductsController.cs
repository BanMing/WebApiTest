using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Data;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ContosoPetsContext _context;

        public ProductsController(ContosoPetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        // GET by ID action
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(long id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST action
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // CreatedAtAction 方法调用中的第一个参数表示操作名称。 nameof 关键字用于避免对操作名称进行硬编码。 CreatedAtAction 使用操作名称生成 Location HTTP 响应标头，其中包含指向新创建的产品的 URL。
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT action
        // 返回 IActionResult，因为在运行时之前，ActionResult 返回类型未知。 BadRequest 和 NoContent 方法分别返回 BadRequestResult 和 NoContentResult 类型。
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            // 上面一句等同于这个
            // product.Name = productIn.Name;
            // product.Price = productIn.Price;
            await _context.SaveChangesAsync();

            // return Ok("");
            // return CreatedAtAction(nameof(Update), "ok");
            return Content("ok");
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            // return NoContent();
            // return CreatedAtAction(nameof(Update), "ok");
            return Content("ok");
        }
    }
}