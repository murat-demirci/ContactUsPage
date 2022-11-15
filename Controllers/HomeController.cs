using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("your outlook mail");
            mail.To.Add("enter recevier");
            mail.Subject = subject;
            mail.Body = "Name --->  " + name + "\n" + "EMail --->  " + email + "\n"
                + body;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("enter your outlook email", "enter your password");
            smtp.Port = 587;
            smtp.Host = "smtp.outlook.com";
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View();
        }
    }
}