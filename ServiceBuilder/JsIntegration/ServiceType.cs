using Jurassic;
using Jurassic.Library;
using static PInvoke.AdvApi32.ServiceType;

namespace ServiceBuilder.JsIntegration
{
    public class ServiceType : ObjectInstance
    {
        public ServiceType(ScriptEngine engine) : base(engine)
        {
            PopulateFields();
        }

        [JSField] public const int Win32 = (int) SERVICE_WIN32;

        [JSField] public const int Driver = (int) SERVICE_DRIVER;

        [JSField] public const int Win32OwnProcess = (int) SERVICE_WIN32_OWN_PROCESS;

        [JSField] public const int Win32ShareProcess = (int) SERVICE_WIN32_SHARE_PROCESS;
    }
}