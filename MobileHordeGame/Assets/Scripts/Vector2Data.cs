using System;
using UnityEngine;

[CreateAssetMenu (fileName = "Vector2Data", menuName = "Data/SingleValueData/Vector2Data")]
public class Vector2Data : ScriptableObject
{
    public Vector2 value;

    public void SetValue(float X, float Y)
    {
        value = new Vector2(X, Y);
    }
    
    public Vector2 GetValue()
    {
        return value;
    }
    
}
