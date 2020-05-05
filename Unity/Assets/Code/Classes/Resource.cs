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
    public ResourceType ResourceType = ResourceType.Wood;
    public Sprite ResourceIcon;
    public int ResourceCount = 0;
}
