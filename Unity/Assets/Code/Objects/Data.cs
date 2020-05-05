using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public int WeaponLevel = 0;
    public int WoodLevel = 0;
    public int MetalLevel = 0;
    public int SelectedWeapon = 0;
    public int SelectedWood = 0;
    public int SelectedMetal = 0;
}