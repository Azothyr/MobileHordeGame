using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu (fileName = "Vector3Data", menuName = "Data/SingleValueData/Vector3Data")]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValue(float X, float Y, float Z)
    {
        value = new Vector3(X, Y, Z);
    }
    
    public Vector3 GetValue()
    {
        return value;
    }
}
