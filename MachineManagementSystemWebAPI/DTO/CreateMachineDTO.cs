using MachineManagementSystemWebAPI.Models;
using System.Text.Json.Serialization;

namespace MachineManagementSystemWebAPI.DTO
{
    public class CreateMachineDTO
    {
        public string Name { get; set; }
        public int Temperature { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MachineStatus Status { get; set; }
    }
}
