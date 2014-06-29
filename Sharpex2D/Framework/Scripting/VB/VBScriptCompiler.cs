﻿using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Sharpex2D.Framework.Debug.Logging;

namespace Sharpex2D.Framework.Scripting.VB
{
    [Developer("ThuCommix", "developer@sharpex2d.de")]
    [Copyright("©Sharpex2D 2013 - 2014")]
    [TestState(TestState.Untested)]
    internal static class VBScriptCompiler
    {
        private static readonly Logger Logger;

        /// <summary>
        /// Initializes a new VBScriptCompiler class.
        /// </summary>
        static VBScriptCompiler()
        {
            Logger = LogManager.GetClassLogger();
        }

        /// <summary>
        ///     Compiles the source to assembly.
        /// </summary>
        /// <param name="script">The SharpScript.</param>
        /// <returns>Assembly.</returns>
        public static Assembly CompileToAssembly(VBScript script)
        {
            var cdProvider = new VBCodeProvider();
            var param = new CompilerParameters();
            param.ReferencedAssemblies.Add("System.dll");
            param.ReferencedAssemblies.Add("Sharpex2D.dll");
            param.ReferencedAssemblies.Add(Application.ExecutablePath);
            param.GenerateExecutable = false;

            CompilerResults result = cdProvider.CompileAssemblyFromSource(param, script.Content);

            bool flag = false;

            foreach (CompilerError error in result.Errors)
            {
                if (error.IsWarning)
                {
                    Logger.Warn("{0} -> {1} (Line {2})", script.Guid, error.ErrorText, error.Line);
                }
                else
                {
                    Logger.Critical("{0} -> {1} (Line {2})", script.Guid, error.ErrorText, error.Line);
                    flag = true;
                }
            }

            if (flag)
            {
                throw new ScriptException("Critical error while compiling script.");
            }

            return result.CompiledAssembly;
        }
    }
}