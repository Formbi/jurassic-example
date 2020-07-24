using Jurassic;
using Jurassic.Library;
using PInvoke;

namespace ServiceBuilder.JsIntegration
{
    public class AccessRight : ObjectInstance
    {
        public AccessRight(ScriptEngine engine) : base(engine)
        {
            PopulateFields();
        }

        [JSField] public const int GenericRead = (int) ((uint) Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_READ
                                                  | AdvApi32.ServiceAccess.SERVICE_QUERY_CONFIG
                                                  | AdvApi32.ServiceAccess.SERVICE_QUERY_STATUS
                                                  | AdvApi32.ServiceAccess.SERVICE_INTERROGATE
                                                  | AdvApi32.ServiceAccess.SERVICE_ENUMERATE_DEPENDENTS);

        [JSField] public const int GenericWrite = (int) ((uint) Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_WRITE
                                                         | AdvApi32.ServiceAccess.SERVICE_CHANGE_CONFIG);

        [JSField] public const int GenericExecute = (int) ((uint) Kernel32.ACCESS_MASK.StandardRight.STANDARD_RIGHTS_EXECUTE
                                                    | AdvApi32.ServiceAccess.SERVICE_START
                                                    | AdvApi32.ServiceAccess.SERVICE_STOP
                                                    | AdvApi32.ServiceAccess.SERVICE_PAUSE_CONTINUE
                                                    | AdvApi32.ServiceAccess.SERVICE_USER_DEFINED_CONTROL);

        [JSField] public const int ReadWrite = GenericRead | GenericWrite;
        
        [JSField] public const int ReadWriteExecute = ReadWrite | GenericExecute;
    }
}