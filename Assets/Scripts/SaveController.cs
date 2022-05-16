using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private Save sv = new Save();
    private string path;

    public void SaveGame(Save sv)
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }

    public Save GetSave()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "SaveSTC.json");
#else
        path = Path.Combine(Application.dataPath, "SaveSTC.json");
#endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
        }
        return sv;
    }
}

[Serializable]
public class Save
{
    public int Record;
    public int Coin;
    public int ChoosedSkin = 0;

    //Инвентарь скинов
    public bool Cucmberg = true; //id = 0
    public bool Banana; // id = 1
    //
}
