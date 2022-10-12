using UnityEngine;

public class ColorMatchBehavior : MatchBehavior
{
    public ColorIDDataList ColorIDDataListObj;

    private void Awake()
    {
        idObj = ColorIDDataListObj.currentColor;
    }

    public void ChangeColor(SpriteRenderer renderer)
    {
        var newColor = idObj as ColorID;
        renderer.color = newColor.value;
    }
}
