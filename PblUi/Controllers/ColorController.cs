using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PblUi.Models;
using PblUi.BLL;
using PblDAL.Models;
using MVC_Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace PblUi.Controllers
{
    public class ColorController : MVC_Controller
    {
        private readonly ColorService service;
        public ColorController(ApplicationContext context) => service = new ColorService(context);

        public async Task<IActionResult> Index()
        {
            var colors = await service.GetAllAsync();
            return View(colors);
        }

        public async Task<IActionResult> Create()
        {
            await service.CreateAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Color c)
        {
            await service.UpdateAsync(c);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}