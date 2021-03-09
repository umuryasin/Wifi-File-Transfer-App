﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Parameters
{
    //private static readonly string parametersPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BuggyCompany\\BuggyFileTransfer\\Parameters.dat";
    private static readonly string parametersPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\FileTransferParameters.dat";

    public static string SavingPath;
    public static string DeviceName;
    public static bool DidInitParameters = false;
    public static bool IsUsingFirstTime;
    public static void Init()
    {
        var param = new ParametersBag();
        try
        {
            param.Load(parametersPath);
            SavingPath = param.SavingPath;
            DeviceName = param.DeviceName;
            DidInitParameters = true;
        }
        catch
        {
            IsUsingFirstTime = true;
            SavingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\";
            DeviceName = "MyDevice";
            Save();
        }
    }
    public static void Save()
    {
        if (!DidInitParameters)
        {
            System.Diagnostics.Debug.WriteLine("Init parameters first!");
            return;
        }
        var param = new ParametersBag();
        param.SavingPath = SavingPath;
        param.DeviceName = DeviceName;
        param.Save(parametersPath);
    }
}
