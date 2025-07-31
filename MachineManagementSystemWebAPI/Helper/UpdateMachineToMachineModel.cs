using MachineManagementSystemWebAPI.DTO;
using MachineManagementSystemWebAPI.Models;

namespace MachineManagementSystemWebAPI.Helper
{
    public static class UpdateMachineToMachineModel
    {
        public static MachineModel Convert(int id, UpdateMachineDTO request)
        {
            var machine = new MachineModel
                {

                Id = id,
                Name = request.Name,
                Temperature = request.Temperature, 
                Status = request.Status,    


            };
            return machine;
        }
    }
}
