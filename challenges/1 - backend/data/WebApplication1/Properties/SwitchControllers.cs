using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwitchController : ControllerBase
    {
        
        private static Switch _switch = new Switch(); // Создание объекта Switch
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_switch.State); // Возвращает текущее состояние переключателя
        }

        [HttpPost]
        public IActionResult Post([FromBody] Switch state)
        {
            _switch.State = state.State;
            return Ok(state);
        }
        
    }
    

    public class Switch
    {
        public string? State { get; set; } = "on";
    }

   
}