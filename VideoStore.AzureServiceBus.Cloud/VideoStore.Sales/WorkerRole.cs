using Microsoft.WindowsAzure.ServiceRuntime;
using NServiceBus.Hosting.Azure;

namespace VideoStore.Sales
{
    // Note: We're now using Microsoft.WindowsAzure.ServiceRuntime.RoleEntryPoint as a base class

    public class WorkerRole : RoleEntryPoint
    {
        private readonly NServiceBusRoleEntrypoint nsb = new NServiceBusRoleEntrypoint();

        public override bool OnStart()
        {
            nsb.Start();
            return base.OnStart();
        }

        public override void OnStop()
        {
            nsb.Stop();
            base.OnStop();
        }
    }
}
