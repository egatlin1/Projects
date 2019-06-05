using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Rain_Saving
{



    public static void SaveFRain ( Rain_GameManager manager )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Rain.fun";
        FileStream strm = new FileStream(path, FileMode.Create);

        Rain_Data rainData = new Rain_Data(manager);

        formatter.Serialize(strm, rainData);
        strm.Close();

    }


    public static Rain_Data LoadRain ()
    {
        string path = Application.persistentDataPath + "/Rain.fun";
        if ( File.Exists(path) )
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream strm = new FileStream(path, FileMode.Open);

            Rain_Data data = formatter.Deserialize(strm) as Rain_Data;

            strm.Close();

            return data;
        }
        else
        {
            return null; // No save file exists
        }
    }


}
