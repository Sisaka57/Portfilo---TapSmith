using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager i;

    public List<ScreenController> Scenes = new List<ScreenController>();
    private int CurrentScene;

    public IntEvent OnSceneChange = new IntEvent();
    public IntEvent OnTouch = new IntEvent();

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        ChangeScene(0);
    }

    public ScreenController GetCurrentScreen()
    {
        return Scenes[CurrentScene];
    }

    public void ChangeScene(int i)
    {
        if (Scenes != null && Scenes.Count > 0)
        {
            foreach (var scene in Scenes)
            {
                scene.SetVisible(false);
            }

            CurrentScene = i;
            Scenes[CurrentScene].SetVisible(true);
            if(OnSceneChange != null)
                OnSceneChange.Invoke(CurrentScene);
        }
    }

    public void Touch()
    {
        if(OnTouch != null)
            OnTouch.Invoke(CurrentScene);
    }

    public void RefreshVisualResource(ResourceType type)
    {
        if (type == ResourceType.Wood)
        {
            Scenes[1].Refresh(type);
        }
    }

    public void AddVisualResource(ResourceType type, Resource resource)
    {
        if (type == ResourceType.Wood)
        {
            Scenes[1].AddVisualResource(type, resource);
        }
        else
        {
            Scenes[2].AddVisualResource(type, resource);
        }
    }
}
