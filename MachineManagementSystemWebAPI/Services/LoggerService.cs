namespace MachineManagementSystemWebAPI.Services
{
    public class LoggerService
    {

        public LoggerService(MachineService service)
        {
            service.OnMachineAdded += MachineAddedSubscription;
            service.OnMachineRemoved += MachineRemovedSubscription;
            service.OnMachineUpdate += MachineUpdatedSubscription;
        }
        public void MachineAddedSubscription(object sender,  MachineEventArgs e )
        {
            Console.WriteLine($"Machine: Id : {e.Id} Name : {e.Name} Temperature : {e.Temperature} was ADDED");

        }

        public void MachineRemovedSubscription(object sender, MachineEventArgs e)
        {
            Console.WriteLine($"Machine: Id : {e.Id} Name : {e.Name} Temperature : {e.Temperature} was REMOVED");

        }

        public void MachineUpdatedSubscription(object sender, MachineEventArgs e)
        {
            Console.WriteLine($"Machine: Id : {e.Id} was UPATED to Name : {e.Name} Temperature : {e.Temperature}");

        }

    }
}
