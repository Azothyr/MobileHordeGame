using UnityEngine;

[CreateAssetMenu (fileName = "BoolData", menuName = "Data/SingleValueData/BoolData")]
public class BoolData : ScriptableObject
{
    public bool value;

    public void SetTrue()
    {
        value = true;
    }
    
    public void SetFalse()
    {
        value = false;
    }

    public bool GetValue()
    {
        return value;
    }
}
