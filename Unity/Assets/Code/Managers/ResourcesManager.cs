using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager i;

    public ResourceDatabase WoodDatabase;
    public ResourceDatabase MetalDatabase;

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (ScreenManager.i != null)
        {
            if (WoodDatabase != null && WoodDatabase.Resources != null && WoodDatabase.Resources.Count > 0)
            {
                foreach (var resource in WoodDatabase.Resources)
                {
                    ScreenManager.i.AddVisualResource(ResourceType.Wood, resource);
                }
            }

            if (MetalDatabase != null && MetalDatabase.Resources != null && MetalDatabase.Resources.Count > 0)
            {
                foreach (var resource in MetalDatabase.Resources)
                {
                    ScreenManager.i.AddVisualResource(ResourceType.Metal, resource);
                }
            }
        }
    }

    public int Cost(ResourceType type, int CurrentLevel = 0)
    {
        if (type == ResourceType.Wood)
        {
            return WoodDatabase.Cost(CurrentLevel);
        }
        else
        {
            return MetalDatabase.Cost(CurrentLevel);
        }
    }

    public void AddCount(ResourceType type, int level)
    {
        if (type == ResourceType.Wood)
        {
            WoodDatabase.GetByLevel(level).ResourceCount++;
        }
        else
        {
            MetalDatabase.GetByLevel(level).ResourceCount++;
        }
    }

    public List<Resource> GetResources(ResourceType type)
    {
        if (type == ResourceType.Wood)
        {
            return WoodDatabase.Resources;
        }
        else
        {
            return MetalDatabase.Resources;
        }
    }

    public Resource GetByLevel(ResourceType type, int level = 0)
    {
        if (type == ResourceType.Wood)
        {
            return WoodDatabase.GetByLevel(level);
        }
        else
        {
            return MetalDatabase.GetByLevel(level);
        }
    }

    public int GetCountByLevel(ResourceType type, int level = 0)
    {
        if (type == ResourceType.Wood)
        {
            return WoodDatabase.GetCountByLevel(level);
        }
        else
        {
            return MetalDatabase.GetCountByLevel(level);
        }
    }
}
