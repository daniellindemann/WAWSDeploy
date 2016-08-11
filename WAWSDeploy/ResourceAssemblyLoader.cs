using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WAWSDeploy
{
	/// <summary>
	/// Allows to reference DLLs which are Resources. That way the referenced DLL does not have to be distributed along YADA
	/// </summary>
	internal class ResourceAssemblyLoader
	{
		internal static void OnAssemblyResolve()
		{
			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				var assemblyInfo = new AssemblyName(args.Name);
				switch (assemblyInfo.Name + ".dll")
				{
					case "Args.dll":
						return Assembly.Load(Properties.Resources.Args);
					case "Microsoft.Web.Deployment.dll":
						return Assembly.Load(Properties.Resources.Microsoft_Web_Deployment);
				}

				// the assembly is not found as resource. return null to let the framework try other places
				return null;
			};
		}
	}
}
