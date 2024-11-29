using System;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MyCustomBuildProcessor : IPreprocessBuildWithReport
{
    public int callbackOrder => 1;

    public void OnPreprocessBuild(BuildReport report)
    {
        //string executablePath;
        //string arguments = "status --header --machinereadable";

        //executablePath = System.Environment.GetEnvironmentVariable("PLASTIC_CM_PATH");
	    
        /*
        var plasticConfPath = System.Environment.GetEnvironmentVariable("PROJECT_DIRECTORY");
	    arguments += $" --clientconf=\"{Path.Combine(plasticConfPath, "client.conf")}\" --tokensconf=\"{ Path.Combine(plasticConfPath, "tokens.conf")}\"";
	    */
        
        /*
        var plasticConfPath = Directory.GetCurrentDirectory();
        arguments += $" --clientconf=\"{Path.Combine(plasticConfPath, "client.conf")}\" --tokensconf=\"{Path.Combine(plasticConfPath, "tokens.conf")}\"";
        */
        
        var unityPath = System.Environment.GetEnvironmentVariable("UNITY_EXE");
        Debug.Log($"UNITY.APP PATH = {unityPath}");
        
        var currentDirectory = Directory.GetCurrentDirectory();
        Debug.Log($"CURRENT DIRECTORY = {currentDirectory}");
        
        /*
        Debug.Log($"PLASTIC CM PATH = {executablePath}");
        Debug.Log($"PATH TO CONF FILE = {plasticConfPath}");
        Debug.Log($"ARGUMENTS = {arguments}");
        */

        /*
        var process = Process.Start(new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        });
        */
    }
}
