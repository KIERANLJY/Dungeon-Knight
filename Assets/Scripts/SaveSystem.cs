using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerHealth _player)
    {
        BinaryFormatter _formatter = new BinaryFormatter();
        string _path = Application.persistentDataPath + "/player.data";
        FileStream _stream = new FileStream(_path, FileMode.Create);
        PlayerData _data = new PlayerData(_player);
        _formatter.Serialize(_stream, _data);
        _stream.Close();
        Debug.Log("Player data has been saved.");
    }

    public static PlayerData LoadPlayer()
    {
        string _path = Application.persistentDataPath + "/player.data";
        if (File.Exists(_path))
        {
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _stream = new FileStream(_path, FileMode.Open);
            PlayerData _data = _formatter.Deserialize(_stream) as PlayerData;
            _stream.Close();
            return _data;
        }
        else
        {
            Debug.LogError("Save file not found in " + _path);
            return null;
        }
    }
}
