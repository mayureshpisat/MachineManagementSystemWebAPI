using MachineManagementSystemWebAPI.DTO;
using MachineManagementSystemWebAPI.Models;
using System.Security.Cryptography.X509Certificates;

namespace MachineManagementSystemWebAPI.Services
{

    public class MachineEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature {  get; set; }
    }
    public class MachineService 
    {
        private static List<MachineModel> machines = new();
        public static int IdCounter = 0;


        // Event for Adding Machine
        public event EventHandler<MachineEventArgs> OnMachineAdded;

        // Event for Deleteing Machine
        public event EventHandler<MachineEventArgs> OnMachineRemoved;

        // Event for Updating Machine 
        public event EventHandler<MachineEventArgs> OnMachineUpdate;
        

        public List<MachineModel> GetAllMachines()
        {
            return machines;
        }
        public void AddMachine(string Name, int Temperature, MachineStatus Status) { 
        
            IdCounter++;
            MachineModel NewMachine = new MachineModel
            {
                Id = IdCounter,
                Name = Name,
                Temperature = Temperature,
                Status = Status
            };

            machines.Add(NewMachine);
            OnMachineAdded?.Invoke(this, new MachineEventArgs
            {
                Id = IdCounter,
                Name = Name,
                Temperature = Temperature
            });

        }

        public bool DeleteMachine(int id)
        {
            bool successFlag = false;
            
            var machine = machines.Where(m => m.Id == id).FirstOrDefault();

            if (machine == null)
            {
                return successFlag;
            }

            OnMachineRemoved?.Invoke(this, new MachineEventArgs
            {
                Id = machine.Id,
                Name = machine.Name,
                Temperature = machine.Temperature
            });
            machines.Remove(machine);

            successFlag = true;
            return successFlag;



            
            

        }

        public bool UpdateMachine(int id, UpdateMachineDTO UpdatedMachine)
        {
            bool successFlag = false;
          
            var machine = machines.Where(m => m.Id == id).FirstOrDefault();

            if (machine == null)
            {
                return successFlag;
            }

            machine.Status = UpdatedMachine.Status;
            machine.Name = UpdatedMachine.Name;
            machine.Temperature = UpdatedMachine.Temperature;

            OnMachineUpdate?.Invoke(this, new MachineEventArgs
            {
                Id = machine.Id,
                Name = machine.Name,
                Temperature = machine.Temperature
            });

            successFlag = true;
            return successFlag;
            


        }
    }
}
