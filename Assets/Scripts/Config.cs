using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config 
{
    static private Config instance;
    static private string configPath = System.Environment.GetEnvironmentVariable("HOME") + "\\PanzerFPV.ini";

    private INIParser ini;

    public static Config Instance
    {
        get {
            if (instance == null) {
                instance = new Config();
            }
            return instance;
        }
    }

    private Config() {
        ini = new INIParser();
        ini.Open(configPath);
    }

    static public string ReadValue(string sectionName, string key, string default_value) {
        return Instance.ini.ReadValue(sectionName, key, default_value);
    }
}
