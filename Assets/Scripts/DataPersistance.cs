using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    private Data data;

    private string path = Application.dataPath + "/Json/SaveData.json";

    public void SetPlayerData(string one, string two, int first, int second)
    {
        data = new Data();
        data.playerOneName = one;
        data.playerTwoName = two;
        data.playerOneSprite = first; 
        data.playerTwoSprite = second;
    }


    public void SaveData()
    {

        string pathaux = path;
        string json = JsonUtility.ToJson(data);
        using StreamWriter writer = new StreamWriter(pathaux);
        writer.Write(json);

    }

    public Data LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        Data dat = JsonUtility.FromJson<Data>(json);

        return dat;

    }


}
