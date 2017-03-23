using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONController : MonoBehaviour
{
    string path;
    string jsonString;

    private void Start()
    {
        path = Application.streamingAssetsPath + "/Card.Json";
        jsonString = File.ReadAllText();
        Card Yoker = JsonUtility.FromJson<Card>(jsonString);
        
    }
	
}

[System.Serializable]
public class Card
{
    public string Name;
    public int Rarity;
    public int Value;
}