using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class SaveSystem
{
    private const string Path = "/saves";
    private const string extention = ".sav";
    public static bool SaveData(string SaveName, object saveData){
        BinaryFormatter formatter = GetBinnaryFormatter();
        if(!Directory.Exists(Application.persistentDataPath + Path)){
            Directory.CreateDirectory(Application.persistentDataPath + Path);
        }
        string path = Application.persistentDataPath + Path + "/" + SaveName + extention;
        FileStream file = File.Create(path);
        formatter.Serialize(file, saveData);
        file.Close();
        Debug.Log("Datos guardados exitosamente");
        return true;
    }
    public static object LoadData(string path)
    {
        path = Application.persistentDataPath + Path + "/" + path + extention;
        if (!File.Exists(path)){
            Debug.Log(path);
            return null;
        }
        BinaryFormatter formatter = GetBinnaryFormatter();
        FileStream file = File.Open(path, FileMode.Open);
        try{
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch {
            Debug.LogErrorFormat("Filed no exist at (0)", path);
            file.Close();
            return null;
        }

    }
    public static BinaryFormatter GetBinnaryFormatter(){
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
