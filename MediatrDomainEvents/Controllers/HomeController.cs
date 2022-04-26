using MediatrDomainEvents.Data;
using MediatrDomainEvents.DTO;
using MediatrDomainEvents.Entities;
using MediatrDomainEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediatrDomainEvents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> AddToDoItem()
        {
            var todoItem = new TodoItem(new CreateToDoItem
            {
                Note = $"note {DateTime.Now}",
                Title = $"title {DateTime.Now}",
                Priority = Enums.PriorityLevel.High,
                Reminder = DateTime.Now.AddDays(5)
            });

            await db.TodoItems.AddAsync(todoItem);
            await db.SaveChangesAsync();
            return Ok(todoItem);
        }

        public async Task<IActionResult> SetComplete(int id)
        {
            var todoItem = await db.TodoItems.FindAsync(id);

            if (todoItem is not null)
            {
                todoItem.MarkAsComplete();
                db.Update(todoItem);
                await db.SaveChangesAsync();
            }
           
            return Ok(todoItem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}