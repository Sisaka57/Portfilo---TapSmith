using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public GameObject ResourceItemPrefab;
    public Transform ResourceItemContainer;

    public List<ResourceItemController> ResourceItems = new List<ResourceItemController>();

    public void SetVisible(bool value)
    {
        if(gameObject.activeInHierarchy != value)
            gameObject.SetActive(value);
    }

    public void AddVisualResource(ResourceType type, Resource resource)
    {
        GameObject o = (GameObject) Instantiate(ResourceItemPrefab, ResourceItemContainer, false);
        var item = o.GetComponent<ResourceItemController>();
        item.Init(type, resource, () => { GameManager.i.SelectLevel(resource.ResourceLevel); });
        ResourceItems.Add(item);
    }

    public void Refresh(ResourceType type)
    {
        if (ResourceItems != null && ResourceItems.Count > 0)
        {
            foreach (var item in ResourceItems)
            {
                if (type == ResourceType.Wood)
                {
                    if (GameManager.i.WoodLevel >= item.CurrentLevel)
                    {
                        item.SetCount(ResourcesManager.i.GetCountByLevel(item.CurrentType, item.CurrentLevel));
                    }
                }
            }
        }
    }
}