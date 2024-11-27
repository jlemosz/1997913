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
        string arguments = "status --header --machinereadable";
        string executablePath;
        
        Debug.Log($"RUNTIME PLATFORM: {Application.platform}");

        if (Application.platform == RuntimePlatform.Android)
        {
#if UNITY_CLOUD_BUILD
	        executablePath = System.Environment.GetEnvironmentVariable("PLASTIC_CM_PATH");
	        var plasticConfPath = System.Environment.GetEnvironmentVariable("PROJECT_DIRECTORY");
	        arguments += $" --clientconf=\"{Path.Combine(plasticConfPath, "client.conf")}\" --tokensconf=\"{ Path.Combine(plasticConfPath, "tokens.conf")}\"";
            
            Debug.Log($"PLASTIC CM PATH = {executablePath}");
            Debug.Log($"PATH TO CONF FILE = {plasticConfPath}");
            Debug.Log($"ARGUMENTS = {arguments}");
#else
            // Local Mac
            executablePath = "/usr/local/bin/cm";
#endif
        }
        else
        {
            // On Windows, cm.exe is in %PATH%. This works both on a local Windows computer
            // and on Unity Build Automation.
            executablePath = "cm";
        }

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        });
    }
}
