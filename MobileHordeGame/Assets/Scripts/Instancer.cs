using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;
    private int num;

    public void CreateInstance()
    {
        Instantiate(prefab);
    }

    public void CreateInstance(Vector3Data obj)
    {
        //Quaternion.Identity means that we are not going to rotate the object at all. Rotate values at 0.
        Instantiate(prefab, obj.value, Quaternion.identity);
    }

    public void CreateInstanceFromList(Vector3DataList obj)
    {
        foreach (var t in obj.vector3DList)
        {
            Instantiate(prefab, t.value, Quaternion.identity);
        }
    }
    
    public void CreateInstanceFromListCounting(Vector3DataList obj)
    {
        Instantiate(prefab, obj.vector3DList[num].value, Quaternion.identity);
        num++;
        if (num == obj.vector3DList.Count)
        {
            num = 0;
        }
    }   
    
    public void CreateInstanceListRandomly(Vector3DataList obj)
    {
        /*Cannot use "using system" to use random.range, you must do "using UnityEngine" and if that is still not
         working use "using UnityEngine; using Random = UnityEngine.Random;" Make sure to remove using system.*/
        num = Random.Range(0, obj.vector3DList.Count - 1);
        Instantiate(prefab, obj.vector3DList[num].value, Quaternion.identity);
    }
}
