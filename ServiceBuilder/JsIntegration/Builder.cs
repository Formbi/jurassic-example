using System;
using Jurassic;
using Jurassic.Library;
using PInvoke;

namespace ServiceBuilder.JsIntegration
{
    public class Builder : ObjectInstance
    {
        //TODO implement lpLoadOrderGroup, lpdwTagId, lpDependencies
        private string serviceName;
        private string displayName;
        private Kernel32.ACCESS_MASK desiredAccess = new Kernel32.ACCESS_MASK(AccessRight.GenericRead);
        private AdvApi32.ServiceType serviceType = AdvApi32.ServiceType.SERVICE_WIN32;
        private AdvApi32.ServiceStartType startType = AdvApi32.ServiceStartType.SERVICE_AUTO_START;
        private AdvApi32.ServiceErrorControl errorControl = AdvApi32.ServiceErrorControl.SERVICE_ERROR_NORMAL;
        private string binaryPathName;
        private string serviceStartName;
        private string password;

        public Builder(ScriptEngine engine) : base(engine)
        {
            PopulateFunctions();
        }

        [JSFunction(Name = "serviceName")]
        public Builder ServiceName(string name)
        {
            serviceName = name;
            return this;
        }

        [JSFunction(Name = "displayName")]
        public Builder DisplayName(string name)
        {
            displayName = name;
            return this;
        }

        [JSFunction(Name = "desiredAccess")]
        public Builder DesiredAccess(int accessType)
        {
            desiredAccess = accessType;
            return this;
        }

        [JSFunction(Name = "serviceType")]
        public Builder ServiceType(int type)
        {
            serviceType = (AdvApi32.ServiceType) type;
            return this;
        }

        [JSFunction(Name = "startType")]
        public Builder StartType(int type)
        {
            startType = (AdvApi32.ServiceStartType) type;
            return this;
        }

        [JSFunction(Name = "errorControl")]
        public Builder ErrorControl(int type)
        {
            errorControl = (AdvApi32.ServiceErrorControl) type;
            return this;
        }
        
        [JSFunction(Name = "binaryPath")]
        public Builder BinaryPath(string path)
        {
            binaryPathName = path;
            return this;
        }

        [JSFunction(Name = "startFromUser")]
        public Builder StartFromUser(string userName, string userPassword)
        {
            serviceStartName = userName;
            password = userPassword;
            return this;
        }

        [JSFunction(Name = "createService")]
        public void CreateService()
        {
            Console.WriteLine($"created service serviceName:{serviceName}, displayName:{displayName}, desiredAccess: 0x{(uint)desiredAccess:X8}," +
                              $" serviceType: {serviceType},startType: {startType}, errorControl: {errorControl}," +
                              $" binaryPathName: {binaryPathName}, serviceStartName: {serviceStartName}");
            using var scManager = AdvApi32.OpenSCManager(null, null, desiredAccess);
            using var serviceHandle = AdvApi32.CreateService(scManager,
                serviceName,
                displayName,
                desiredAccess,
                serviceType,
                startType,
                errorControl,
                binaryPathName,
                null,
                0,
                null,
                serviceStartName,
                password);
        }
    }
}