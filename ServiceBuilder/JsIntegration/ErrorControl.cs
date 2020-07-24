using Jurassic;
using Jurassic.Library;
using static PInvoke.AdvApi32.ServiceErrorControl;

namespace ServiceBuilder.JsIntegration
{
    public class ErrorControl : ObjectInstance
    {
        public ErrorControl(ScriptEngine engine) : base(engine)
        {
            PopulateFields();
        }

        [JSField] public const int Critical = (int) SERVICE_ERROR_CRITICAL;

        [JSField] public const int Ignore = (int) SERVICE_ERROR_IGNORE;

        [JSField] public const int Normal = (int) SERVICE_ERROR_NORMAL;

        [JSField] public const int Severe = (int) SERVICE_ERROR_SEVERE;
    }
}