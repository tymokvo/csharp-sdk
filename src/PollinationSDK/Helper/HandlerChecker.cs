using PollinationSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PollinationSDK
{
    /// <summary>
    /// Create a new HandlerChecker that inherited from this for your platform. You can call it RhinoHandlerChecker or RevitHandlerChecker.
    /// You can also use DefaultHandlerChecker.Instance if you just want to use a default one.
    /// </summary>
    public abstract class HandlerChecker
    {
        public object CheckWithHandlers(object inputData, List<IOAliasHandler> handlers)
        {
            if (inputData == null) return inputData;
            if (handlers == null || !handlers.Any()) return inputData;

            var errors = new List<string>();
            var handled = false;
            object checkedData = null;
            foreach (var item in handlers)
            {
                Exception err = null;
                try
                {
                    handled = CheckWithHandler(inputData, item, out var newData);
                    checkedData = newData;
                }
                catch (Exception e)
                {
                    err = e;
                    //throw;
                }

                if (err == null)
                    break;

                errors.Add($"Handler-{item.Language}: {err.Message}");
            }

            if (handled)
                return checkedData;


            // throw exception
            var joinedMessage = string.Join(Environment.NewLine, errors);
            throw new ArgumentException(joinedMessage);


            // local method
            bool CheckWithHandler(object inData, IOAliasHandler handler, out object handledData)
            {
                handledData = inData;
                if (handler == null) return false;
                var isPythonObj = handler.Language == "python";
                var func = handler.Function; // "HoneybeeSchema.Handlers"

                // load the module: csharp- dll file, python- module
                var module = handler.Module.Trim();

                // execute
                if (isPythonObj)// module = "honeybee_radiance_handlers.handlers";
                {
                    handledData = InvokePythonFunction(module, func, inData);
                }
                else   // module = "HoneybeeSchema.Handlers";
                {
                    var asm = LoadDll(module);
                    var handlerType = asm.GetType(module);
                    // execute
                    handledData = InvokeCSharpFunction(handlerType, func, inData);
                }

                return true;

            }
        }


        public virtual object CheckLinkedData(IOAliasHandler handler)
        {
            if (handler == null) return null;

            var module = handler.Module;
            var func = handler.Function; // "RhinoHBModelToJSON"

            //var asmFile = @"D:\Dev\honeybee-rhino-plugin\src\HoneybeeRhino.Handlers\bin\Debug\net452\HoneybeeRhino.Handlers.dll";
            //var asm = Assembly.LoadFile(asmFile);
            var asm = LoadDll(module);
            var handlerType = asm.GetType(module);
            // execute
            var checkedData = InvokeCSharpFunction(handlerType, func, null);
            return checkedData;
        }

        public virtual object InvokeCSharpFunction(Type handler, string fullMethodName, object param)
        {
            var methodFound = handler.GetMethod(fullMethodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            object resultValue = methodFound.Invoke(null, new[] { param });
            return resultValue;
        }

        /// <summary>
        /// Override this for converting data with Python handlers. 
        /// </summary>
        /// <param name="module">Python module name</param>
        /// <param name="function">Python function name</param>
        /// <param name="data">Data to be checked</param>
        /// <returns>Converted data</returns>
        public abstract object InvokePythonFunction(string module, string function, object data);

        private static Assembly LoadDll(string csProjName)
        {
            try
            {
                //Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
                // project name has to be the format of NameSpace.Handlers. 
                // For example: if the name space is "HoneybeeSchema", then project name would be HoneybeeSchema.Handlers.
                var loadedDll = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(_ => _.GetName().Name == csProjName);
                // Is loaded
                if (loadedDll != null) return loadedDll;

                // dll file name or dlllink file name has to be the same as the project name, 
                // for example: HoneybeeSchema.Handlers.dll, or HoneybeeSchema.Handlers.dlllink


                var currentDir = Path.GetDirectoryName(typeof(HandlerChecker).Assembly.Location);
                var dlls = Directory.GetFiles(currentDir, $"{csProjName}.dll", SearchOption.TopDirectoryOnly);
                var foundDll = string.Empty;
                // Try to find the dll from link file
                if (dlls.Length == 0)
                {
                    var linkDlls = Directory.GetFiles(currentDir, $"{csProjName}.dlllink", SearchOption.TopDirectoryOnly);
                    if (linkDlls.Length == 0) throw new ArgumentException($"Failed to load {csProjName}.dll or dlllink from {currentDir}");
                    var remoteDllPath = File.ReadAllLines(linkDlls.First()).FirstOrDefault(_ => _.Trim().EndsWith($"{csProjName}.dll"));
                    if (remoteDllPath == null) throw new ArgumentException($"Failed to load {csProjName} from {linkDlls.First()}");
                    foundDll = remoteDllPath;
                }
                else
                {
                    foundDll = dlls.First();
                }

                var asmFile = foundDll;
                //var asmFile = @"D:\Dev\honeybee-schema-dotnet\src\HoneybeeSchemaHandler\bin\Debug\net452\HoneybeeSchemaHandler.dll";
                var asm = Assembly.LoadFile(asmFile);
                return asm;
            }
            catch (Exception ex)
            {
                throw new System.IO.FileNotFoundException($"Cannot find handler libraries.\n{ex.Message}");
            }
        }

    }
}
