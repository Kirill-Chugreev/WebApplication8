using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    public class DataController : Controller
    {
        public IActionResult SessionData()
        {
            // Сохранить данные в сессии
            HttpContext.Session.SetString("ИмяПользователя", "John Doe");
            HttpContext.Session.SetInt32("Age", 19);

            // Получить данные из сессии
            var userName = HttpContext.Session.GetString("UserName");
            var age = HttpContext.Session.GetInt32("Age");

            // Передать данные в представление
            ViewData["UserName"] = userName;
            ViewData["Age"] = age;

            return View();
        }

        public IActionResult CookieData()
        {
            // Установить cookie
            HttpContext.Response.Cookies.Append("UserName", "John Doe", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            });

            // Получить значение cookie
            var userName = HttpContext.Request.Cookies["UserName"];

            // Передать данные в представление
            ViewData["UserName"] = userName;

            return View();
        }

        public IActionResult LocalStorageData()
        {
            return View();
        }

        public IActionResult SessionStorageData()
        {
            return View();
        }
    }
}
