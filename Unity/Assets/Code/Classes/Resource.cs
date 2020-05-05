using System;
using UnityEngine;

public enum ResourceType
{
    Wood,
    Metal
};

[Serializable]
public class Resource
{
    public Sprite ResourceIcon;
    public int ResourceLevel = 0;
    public int ResourceCount = 0;
}
