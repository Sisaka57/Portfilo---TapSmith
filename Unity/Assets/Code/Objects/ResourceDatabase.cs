using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Math;

[Serializable]
[CreateAssetMenu]
public class ResourceDatabase : ScriptableObject
{
    public AnimationCurve ResourceCurve = AnimationCurve.Linear(0, 0, 1, 1);
    public Range LevelRange = new Range(0, 100);
    public Range GoldRange = new Range(0, 1000000);
    public List<Resource> Resources = new List<Resource>();

    public Resource GetByLevel(int level = 0)
    {
        Resource result = null;

        if (Resources != null && Resources.Count > 0)
        {
            foreach (var resource in Resources)
            {
                if (resource.ResourceLevel == level)
                    result = resource;
            }
        }

        return result;
    }

    public int GetCountByLevel(int level = 0)
    {
        int result = 0;

        if (Resources != null && Resources.Count > 0)
        {
            foreach (var resource in Resources)
            {
                if (resource.ResourceLevel == level)
                    result = resource.ResourceCount;
            }
        }

        return result;
    }

public int Cost(int level = 0)
    {
        return Mathf.RoundToInt(ResourceCurve.Evaluate((float)Mathf.Clamp(level, LevelRange.Min, LevelRange.Max) / (float)LevelRange.Max) * GoldRange.Max);
    }
}