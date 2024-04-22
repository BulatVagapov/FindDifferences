using System.IO;
using UnityEngine;

public class Saver<T>
{
    public static string GetPath(string fileName)
    {
        return $"{Application.streamingAssetsPath}/{fileName}";
    }
   
    public static void TryLoad(string fileName, ref T gettingData)
    {
        string path = GetPath(fileName);
        if (File.Exists(path))
        {
            string dataString = File.ReadAllText(path);

            DataItem<T> data = JsonUtility.FromJson<DataItem<T>>(dataString);
            gettingData = data.Value;
        }
    }

    public static void Save(string fileName, T savingData)
    {
        string dataName = fileName.TrimEnd(new char[] { '.', 'j', 's', 'o', 'n' });
        DataItem<T> dataItem = new DataItem<T> { Name = dataName, Value = savingData };

        string dataString = JsonUtility.ToJson(dataItem);

        File.WriteAllText(GetPath(fileName), dataString);
    }
}
