using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceItemController : MonoBehaviour
{
    public ResourceType CurrentType;
    public int CurrentLevel;
    [SerializeField]
    private Button UIButton;
    [SerializeField]
    private Image UIIcon;
    [SerializeField]
    private TextMeshProUGUI UILabel;

    public void Init(ResourceType type, Resource resource, Action callback)
    {
        CurrentType = type;
        CurrentLevel = resource.ResourceLevel;
        UIIcon.sprite = resource.ResourceIcon;
        if (CurrentType == ResourceType.Wood)
        {
            if (GameManager.i.WoodLevel >= CurrentLevel)
            {
                UILabel.text = resource.ResourceCount.ToString();
                UILabel.color = Color.white;
                UIButton.onClick.AddListener(() =>
                {
                    GameManager.i.SelectLevel(CurrentLevel);
                    UILabel.text = ResourcesManager.i.GetCountByLevel(CurrentType, CurrentLevel).ToString();
                });
            }
            else
            {
                UILabel.text = ResourcesManager.i.Cost(CurrentType, CurrentLevel).ToString();
                UILabel.color = Color.yellow;
            }
        }
    }

    public void SetCount(int count)
    {
        UILabel.text = count.ToString();
    }
}
