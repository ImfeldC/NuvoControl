using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuvoControl.Common
{
    /// <summary>
    /// This class contains helper methods th retrieve infromatin about the application context.
    /// </summary>
    public class AppInfoHelper
    {
        /// <summary>
        /// Returns the assembly version.
        /// </summary>
        /// <returns></returns>
        static public string getAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        /// <summary>
        /// Returns the deployment (publish) version, if available; otherwise "(n/a)" is returned.
        /// </summary>
        /// <returns></returns>
        static public string getDeploymentVersion()
        {
            string deploymentVersion="";
            try
            {
                // TODO Although ClickOnce is supported on .NET 5+, apps do not have access to the System.Deployment.Application namespace. For more details see https://github.com/dotnet/deployment-tools/issues/27 and https://github.com/dotnet/deployment-tools/issues/53.
                deploymentVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch( Exception )
            {
                deploymentVersion = "(n/a)";
            }
            return deploymentVersion;
        }
    }
}
