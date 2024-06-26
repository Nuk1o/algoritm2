using UnityEngine;
using System.Security.Cryptography;
using System.Text;
/*
 *  Скрипт защиты реестра
 *  Registry protection script
 */
public class SafePlayerPrefs : MonoBehaviour
{
    private string GetHash(SHA256 hash, string input)
    {
        byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    public void Save(string key, string _namePrefs)
    {
        try
        {
            using SHA256 hash = SHA256.Create();
            string _prefs = PlayerPrefs.GetString(_namePrefs);
            string _hash = GetHash(hash, _prefs);
            PlayerPrefs.SetString("CHECKSUM" + key, _hash);
        }
        catch
        {
            Debug.Log("Error Save");
        }
    }
    public bool HasBeenEdited (string key, string _namePrefs)
    {
        try
        {
            if (! PlayerPrefs.HasKey("CHECKSUM" + key))
                return true;

            string checksumSaved = PlayerPrefs.GetString("CHECKSUM" + key);
            using SHA256 hash = SHA256.Create();
            string _prefs = PlayerPrefs.GetString(_namePrefs);
            string checksumReal = GetHash(hash, _prefs);
            return checksumSaved.Equals(checksumReal);
        }
        catch
        {
            Debug.Log("HasBeenEdited");
        }
        return false;
    }
}
