using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        public HomeController( IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var products = connection.Query<Product>("SELECT * FROM Products");
                return View(products);
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                connection.Execute("INSERT INTO Products (Id,Name,Description, Price) VALUES (@Id,@Name,@Description, @Price)", product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var product = connection.QuerySingleOrDefault<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                connection.Execute("UPDATE Products SET Name = @Name, Description=@Description, Price = @Price WHERE Id = @Id", product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                connection.Execute("DELETE FROM Products WHERE Id = @Id", new { Id = id });
            }
            return RedirectToAction("Index");
        }
        
    }

  
}
