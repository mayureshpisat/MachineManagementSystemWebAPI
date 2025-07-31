using MachineManagementSystemWebAPI.DTO;
using MachineManagementSystemWebAPI.Helper;
using MachineManagementSystemWebAPI.Models;
using MachineManagementSystemWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineManagementSystemWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachinesController : ControllerBase
    {
        private readonly MachineService _services;

        public MachinesController(MachineService services, LoggerService logger_service)
        {
            _services = services;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<MachineModel> machines = new List<MachineModel>();
            machines = _services.GetAllMachines();
            return Ok(machines);
        }

        [HttpPost("addmachine")]
        public IActionResult AddMachine([FromBody] CreateMachineDTO request)
        {
            string Name = request.Name;
            int Temperature = request.Temperature;
            var Status = request.Status;
            _services.AddMachine(Name, Temperature, Status);

            
            return Ok(_services.GetAllMachines());
        }

        [HttpPut("updatemachine/{id}")]

        public IActionResult UpdateMachine(int id, [FromBody] UpdateMachineDTO request)
        {


            //converting machine that we get from user to actual machine to send to the service
            //as user is not allowed to change the Id field
            bool successFlag = _services.UpdateMachine(id, request);


            //machine not found
            if (!successFlag)
            {
                return NotFound($"Machine not found");
            }

            return Ok(_services.GetAllMachines());


        }

        [HttpDelete("deletemachine/{id}")]
        public IActionResult DeleteMachine(int id)
        {
            bool successFlag;


            successFlag = _services.DeleteMachine(id);

            if (!successFlag)
            {
                return NotFound($"Machine to be deleted was not found");
            }

            return Ok(_services.GetAllMachines());
        }

            

    }
}
