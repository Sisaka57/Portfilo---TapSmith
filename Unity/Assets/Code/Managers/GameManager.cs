using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    public ResourceType SelectedResource;

    public int WeaponLevel = 0;
    public int WoodLevel = 0;
    public int MetalLevel = 0;
    public int SelectedWeapon = 0;
    public int SelectedWood = 0;
    public int SelectedMetal = 0;

    private void Awake()
    {
        i = this;
    }

    public void Start()
    {
        if (ScreenManager.i != null)
        {
            ScreenManager.i.OnSceneChange.AddListener((scene) =>
            {
                if (scene == 1)
                {
                    SelectedResource = ResourceType.Wood;
                }

                if (scene == 2)
                {
                    SelectedResource = ResourceType.Metal;
                }
            });
            ScreenManager.i.OnTouch.AddListener(Touch);
        }
    }

    public void SelectLevel(int i)
    {
        if (SelectedResource == ResourceType.Wood)
        {
            SelectedWood = i;
        }
    }

    private void Touch(int screen)
    {
        if (screen == 1)
        {
            ResourcesManager.i.AddCount(ResourceType.Wood, SelectedWood);
            ScreenManager.i.RefreshVisualResource(ResourceType.Wood);
        }

        if (screen == 2)
        {

        }
    }
}
