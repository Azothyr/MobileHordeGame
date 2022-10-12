using UnityEngine;

public class ColorIDBehavior : IDContainerBehavior
{
    public ColorIDDataList ColorIDDataListObj;

    private void Awake()
    {
        idObj = ColorIDDataListObj.currentColor;
    }
}
