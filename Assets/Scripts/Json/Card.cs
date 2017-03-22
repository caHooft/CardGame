using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Normal,
    Rare,
    Epic

}

[CreateAssetMenu]
[System.Serializable]
public class Card : ScriptableObject
{
    public Sprite looks;
    public string Name;
}
