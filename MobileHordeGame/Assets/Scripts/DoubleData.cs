using UnityEngine;

[CreateAssetMenu (fileName = "DoubleData", menuName = "Data/SingleValueData/DoubleData")]
public class DoubleData : ScriptableObject
{
    public double value;

    public void SetValue(double num)
    {
        value = num;
    }
    
    public void UpdateValue(double num)
    {
        value += num;
    }
}