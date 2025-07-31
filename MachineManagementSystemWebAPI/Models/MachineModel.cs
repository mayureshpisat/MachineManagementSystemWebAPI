using System.Text.Json.Serialization;

namespace MachineManagementSystemWebAPI.Models
{
    public enum MachineStatus
    {
        Running = 0, 
        Stopped = 1,
        Error = 2
    }
    public class MachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MachineStatus Status { get; set; }
        
    }
}
