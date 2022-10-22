using UnityEngine;

[CreateAssetMenu (fileName = "FloatData", menuName = "Data/SingleValueData/FloatData")]
public class FloatData : ScriptableObject
{
    public float value;

    public void SetValue(float num)
    {
        value = num;
    }
    
    public void UpdateValue(float num)
    {
        value += num;
    }
}