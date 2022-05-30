using Microsoft.AspNetCore.Mvc;
using ProjectX.Models;
using System.Diagnostics;
using ProjectX.DAL.EF;

namespace ProjectX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Context db;
        public HomeController(Context sers)
        {
            db = sers;
        }

        public IActionResult Index()
        {
            Console.WriteLine();
            Console.WriteLine("Teachers");
            foreach(var a in db.Teachers)
            {
                Console.WriteLine(a.Name + " " + a.SurName + " " + a.Email);
            }
            Console.WriteLine();
            Console.WriteLine("Students");
            foreach (var a in db.Students)
            {
                Console.WriteLine(a.Name + " " + a.SurName + " " + a.Email);
            }
            Console.WriteLine();
            Console.WriteLine("Homeworks");
            foreach (var a in db.Homeworks)
            {
                Console.WriteLine(a.ID + " " + a.LectureId + " " + a.Task);
            }
            Console.WriteLine();
            Console.WriteLine("Lectures");
            foreach (var a in db.Lectures)
            {
                Console.WriteLine(a.ID + " " + a.Name + " " +a.HomeworkId );
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}