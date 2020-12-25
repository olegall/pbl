using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PblService.BLL;
using PblDAL.Models;
using System.Collections.Generic;
using PblService.Models;

namespace PblService.Controllers
{
    [ApiController]
    [Route("rest/api/1")]
    public class LightsController : ControllerBase
    {
        private readonly LightsService lightsService;

        public LightsController()
        {
            lightsService = new LightsService(new ApplicationContext());
        }

        #region GET
        [Route("colors")]
        [HttpGet]
        public async Task<IEnumerable<Color>> GetColors()
        {
            return await lightsService.GetColors();
        }

        [Route("lights")]
        [HttpGet]
        public async Task<object> GetLights(string selectedColors)
        {
            return await lightsService.Get(selectedColors);
        }

        [Route("lights/{id}")]
        [HttpGet]
        public async Task<ActionResult<object>> GetLight(string id)
        {
            object light = await lightsService.GetOne(id);
            if (light == null) 
                return NotFound();

            return light;
        }

        [Route("controllers")]
        [HttpGet]
        public IEnumerable<ControllerVM> GetControllers()
        {
            return lightsService.GetControllers();
        }
        #endregion

        #region POST
        [Route("lights/{id}/on")]
        [HttpPost]
        public async Task<ActionResult> TurnOn(string id)
        {
            object light = await lightsService.GetOne(id);
            if (light == null)
                return NotFound();

            await lightsService.Toggle(id, true);
            return Ok();
        }

        [Route("lights/{id}/off")]
        [HttpPost]
        public async Task<ActionResult> TurnOff(string id)
        {
            object light = await lightsService.GetOne(id);
            if (light == null)
                return NotFound();

            await lightsService.Toggle(id, false);
            return Ok();
        }

        [Route("lights/on")]
        [HttpPost]
        public async Task TurnOnAll(string idColor)
        {
            await lightsService.ToggleAll(idColor, true);
        }

        [Route("lights/off")]
        [HttpPost]
        public async Task TurnOffAll(string idColor)
        {
            await lightsService.ToggleAll(idColor, false);
        }
        #endregion
    }
}