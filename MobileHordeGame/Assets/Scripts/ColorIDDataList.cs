using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ColorIDDataList", menuName = "IDs/ColorIDDataList")]
public class ColorIDDataList : ScriptableObject
{
    public List<ColorID> colorIDList;

    public ColorID currentColor;

    private int num;

    public void SetCurrentColorRandomly()
    {
        num = Random.Range(0, colorIDList.Count);
        currentColor = colorIDList[num];
    }
}
