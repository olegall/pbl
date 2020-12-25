using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PblUi.Models;
using PblUi.BLL;
using PblDAL.Models;
using MVC_Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace PblUi.Controllers
{
    public class LightController : MVC_Controller
    {
        private readonly LightService _service;
        public LightController(ApplicationContext context)
        {
            _service = new LightService(context);
        }

        #region CRUD One
        public async Task<IActionResult> Index()
        {
            LightVM vm = await _service.GetVm();
            return View(vm);
        }

        public async Task<IActionResult> Create(Light l)
        {
            try
            {
                await _service.CreateAsync(l);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CU_Failed");
            }
        }

        public async Task<IActionResult> Update(Light l)
        {
            try
            {
                await _service.UpdateAsync(l);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View("CU_Failed");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region CRUD Many
        public async Task<IActionResult> Many()
        {
            LightVM vm = await _service.GetVm();
            return View(vm);
        }

        public async Task<IActionResult> CreateMany(CreateMany m)
        {
            try
            {
                await _service.CreateManyAsync(m);
                return RedirectToAction("Many");
            }
            catch
            {
                return View("CU_Failed");
            }
        }
        public async Task<IActionResult> ShowUpdateMany(UpdateMany m)
        {
            m = await _service.GetUpdateManyModel(m);
            return View("ShowUpdateMany", m);
        }

        public async Task<IActionResult> UpdateMany(UpdateMany m)
        {
            try
            {
                await _service.UpdateManyAsync(m);
                return RedirectToAction("Many");
            }
            catch
            {
                return View("CU_Failed");
            }
        }

        public async Task<IActionResult> DeleteMany(DeleteMany m)
        {
            await _service.DeleteManyAsync(m);
            return RedirectToAction("Many");
        }
        #endregion
    }
}