using System;
using System.IO;
using System.Linq;
using Jurassic;
using ServiceBuilder.JsIntegration;

namespace ServiceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || !args.Any())
                throw new Exception("Path to JS file should be specified");
            var scriptPath = args[0];
            if (!File.Exists(scriptPath))
                throw new Exception($"File does not exist - '{scriptPath}'");
            var engine = new ScriptEngine();
            engine.SetGlobalValue("ServiceBuilder", new Builder(engine));
            engine.SetGlobalValue("AccessRight", new AccessRight(engine));
            engine.SetGlobalValue("ErrorControl", new ErrorControl(engine));
            engine.SetGlobalValue("ServiceType", new ServiceType(engine));
            engine.SetGlobalValue("StartType", new StartType(engine));
            engine.ExecuteFile(scriptPath);
        }
    }
}
