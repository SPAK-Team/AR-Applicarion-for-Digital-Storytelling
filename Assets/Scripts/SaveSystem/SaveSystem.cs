using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static string playerName;
    
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavePlayer/" + player.getName() + ".fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }





    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/SavePlayer/"+playerName+".fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found  in " + path);
            return null;
        }
    }



    public static void SaveMinigameRecord(string name, string gameType, string storyType,List<string> correctSum, List<string> wrongSum)
    {
        int max_number = 0;
        if (gameType == "minigame")
        {
            max_number = 20;
        }
        else
        {
            max_number = 5;
        }


        string path = Application.persistentDataPath + "/MinigameRecords";
        string fileName = name+"-"+gameType+"-"+storyType+".txt";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string[] contains = Directory.GetFiles(path, "*"+fileName+ "*");
        // Debug.Log(contains.Length);
        int number = contains.Length + 1;
        fileName = path+"/"+number.ToString("D3") + "-" + fileName;
        Debug.Log(fileName);
        StreamWriter writer = new StreamWriter(fileName, true);
       
            
        // Correct Set
        writer.WriteLine("Correct : "+ correctSum.Count.ToString()+"/"+max_number.ToString());
        foreach(string line in correctSum)
        {
            writer.WriteLine(line);

        }

        // Incorrect Set
        writer.WriteLine("Incorrect : " + wrongSum.Count.ToString() + "/" + max_number.ToString());
        foreach (string line in wrongSum)
        {
            writer.WriteLine(line);

        }


        writer.Close();

    }
}
