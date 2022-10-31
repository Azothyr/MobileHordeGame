using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num;
    
    public void CreateInstance(Vector3Data obj)
    {
        Instantiate(prefab,obj.value, Quaternion.identity);
    }
}
