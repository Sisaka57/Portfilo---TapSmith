using UnityEngine;
using UnityEngine.UI;

public enum GridDirection { X, Y };

[ExecuteInEditMode]
[RequireComponent(typeof(GridLayoutGroup))]
public class GridController : MonoBehaviour
{
    public int ItemRows = 3;
    public int ItemColumns = 3;

    public float Width = 0f;

    private GridLayoutGroup gridLayout;

    private void Start()
    {
        if (gridLayout == null)
            gridLayout = GetComponent<GridLayoutGroup>();
    }

    private void Update()
    {
        if (gridLayout != null)
        {
            float containerWidth = ((RectTransform)transform).rect.width - (gridLayout.padding.left + gridLayout.padding.right);
            float containerHeight = ((RectTransform)transform).rect.height - (gridLayout.padding.top + gridLayout.padding.bottom);
            float itemWidth = (containerWidth - (gridLayout.spacing.x * (ItemColumns-1))) / ItemColumns;
            float itemHeight = (containerHeight - (gridLayout.spacing.y * (ItemRows - 1))) / ItemRows;
            gridLayout.cellSize = new Vector2(itemWidth, itemHeight);
        }
    }
}
