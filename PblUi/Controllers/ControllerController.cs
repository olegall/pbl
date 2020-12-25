using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PblUi.Models;
using PblUi.BLL;
using PblDAL.Models;
using MVC_Controller = Microsoft.AspNetCore.Mvc.Controller;
using ModelController = PblDAL.Models.Controller;

namespace PblUi.Controllers
{
    public class ControllerController : MVC_Controller
    {
        private readonly ControllerService service;
        public ControllerController(ApplicationContext context)
        {
            service = new ControllerService(context);
        }

        public async Task<IActionResult> Index()
        {
            var controllers = await service.GetAllAsync();
            return View(controllers);
        }

        public async Task<IActionResult> Create()
        {
            await service.CreateAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(ModelController m)
        {
            await service.UpdateAsync(m);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
