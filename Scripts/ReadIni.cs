using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ReadIni : MonoBehaviour{
    private static string path = Path.Combine(Application.persistentDataPath, "hundirlaflota.ini");

    private static Dictionary<string, Dictionary<string, string>> IniDictionary =
        new Dictionary<string, Dictionary<string, string>>();

    private static bool Initialized = false;

    /// <summary>
    /// Sections list
    /// </summary>
    public enum Section{
        PlayerSettings
    }

    /// <summary>
    /// Keys list
    /// </summary>
    public enum Key{
        ScreenWidth,
        ScreenHeight,
        Locale,
        Level,
        Difficult,
        SoundLevel,
        MusicLevel
    }

    public static bool FirstRead(){
        if (File.Exists(path)){
            using (StreamReader sr = new StreamReader(path)){
                string line;
                string theSection = "";
                string theKey = "";
                string theValue = "";
                while (!string.IsNullOrEmpty(line = sr.ReadLine())){
                    line.Trim();
                    if (line.StartsWith("[") && line.EndsWith("]")){
                        theSection = line.Substring(1, line.Length - 2);
                    }
                    else{
                        string[] ln = line.Split(new char[]{'='});
                        theKey = ln[0].Trim();
                        theValue = ln[1].Trim();
                    }
                    if (theSection == "" || theKey == "" || theValue == "")
                        continue;
                    PopulateIni(theSection, theKey, theValue);
                }
            }
        }
        return true;
    }

    private static void PopulateIni(string _Section, string _Key, string _Value){
        if (IniDictionary.ContainsKey(_Section)){
            if (IniDictionary[_Section].ContainsKey(_Key)){
                IniDictionary[_Section][_Key] = _Value;
            }
            else{
                IniDictionary[_Section].Add(_Key, _Value);
            }
        }
        else{
            Dictionary<string, string> neuVal = new Dictionary<string, string>();
            neuVal.Add(_Key, _Value);
            IniDictionary.Add(_Section, neuVal);
        }
    }

    /// <summary>
    /// Write data to INI file. Section and Key no in enum.
    /// </summary>
    /// <param name="_Section"></param>
    /// <param name="_Key"></param>
    /// <param name="_Value"></param>
    public static void IniWriteValue(string _Section, string _Key, string _Value){
        if (!Initialized){
            FirstRead();
        }
        PopulateIni(_Section, _Key, _Value);
    }

    /// <summary>
    /// Write data to INI file. Section and Key bound by enum
    /// </summary>
    /// <param name="section"></param>
    /// <param name="key"></param>
    /// <param name="_Value"></param>
    public static void IniWriteValue(Section section, Key key, string _Value){
        IniWriteValue(section.ToString(), key.ToString(), _Value);
    }

    public static void WriteIni(){
        if (!File.Exists(path)){
            UpdateIni();
        }
    }

    public static void UpdateIni(){
        using (StreamWriter sw = new StreamWriter(path)){
            foreach (KeyValuePair<string, Dictionary<string, string>> section in IniDictionary){
                sw.WriteLine("[" + section.Key + "]");
                foreach (KeyValuePair<string, string> key in section.Value){
                    // value must be in one line
                    string value = key.Value;
                    value = value.Replace(Environment.NewLine, " ");
                    value = value.Replace("\r\n", " ");
                    sw.WriteLine(key.Key + " = " + value);
                }
            }
        }
    }

    /// <summary>
    /// Read data from INI file. Section and Key bound by enum
    /// </summary>
    /// <param name="section"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string IniReadValue(Section section, Key key){
        if (!Initialized){
            FirstRead();
        }
        return IniReadValue(section.ToString(), key.ToString());
    }

    /// <summary>
    /// Read data from INI file. Section and Key no in enum.
    /// </summary>
    /// <param name="_Section"></param>
    /// <param name="_Key"></param>
    /// <returns></returns>
    public static string IniReadValue(string _Section, string _Key){
        if (!Initialized){
            FirstRead();
        }
        if (IniDictionary.ContainsKey(_Section)){
            if (IniDictionary[_Section].ContainsKey(_Key)){
                return IniDictionary[_Section][_Key];
            }
        }
        return null;
    }
}