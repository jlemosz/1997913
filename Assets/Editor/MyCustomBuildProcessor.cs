using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

class MyCustomBuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder
    {
        get { return 0; }
    }

    public void OnPreprocessBuild(BuildReport report)
    {
#if UNITY_CLOUD_BUILD
        string arguments = "status --header --machinereadable";
        string executablePath;

	    executablePath = System.Environment.GetEnvironmentVariable("PLASTIC_CM_PATH");
	    var plasticConfPath = System.Environment.GetEnvironmentVariable("PROJECT_DIRECTORY");
	    arguments += $" --clientconf=\"{Path.Combine(plasticConfPath, "client.conf")}\" --tokensconf=\"{ Path.Combine(plasticConfPath, "tokens.conf")}\"";
        
        Debug.Log($"PLASTIC CM PATH = {executablePath}");
        Debug.Log($"PATH TO CONF FILE = {plasticConfPath}");
        Debug.Log($"ARGUMENTS = {arguments}");

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        });
#endif
    }
}
