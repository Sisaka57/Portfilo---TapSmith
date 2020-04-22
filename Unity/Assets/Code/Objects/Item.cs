using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite ItemIcon;
    public string ItemName;
    public string ItemDescription;
}