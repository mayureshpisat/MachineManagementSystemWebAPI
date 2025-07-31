using MachineManagementSystemWebAPI.Models;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MachineManagementSystemWebAPI.DTO
{
    public class UpdateMachineDTO
    {
     
        public string Name { get; set; }
        public int Temperature { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MachineStatus Status { get; set; }
    }
}
