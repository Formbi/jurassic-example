using Jurassic;
using Jurassic.Library;
using static PInvoke.AdvApi32.ServiceStartType;

namespace ServiceBuilder.JsIntegration
{
    public class StartType : ObjectInstance
    {
        public StartType(ScriptEngine engine) : base(engine)
        {
            PopulateFields();
        }

        [JSField] public const int AutoStart = (int) SERVICE_AUTO_START;

        [JSField] public const int BootStart = (int) SERVICE_BOOT_START;

        [JSField] public const int DemandStart = (int) SERVICE_DEMAND_START;

        [JSField] public const int Disabled = (int) SERVICE_DISABLED;

        [JSField] public const int SystemStart = (int) SERVICE_SYSTEM_START;
    }
}