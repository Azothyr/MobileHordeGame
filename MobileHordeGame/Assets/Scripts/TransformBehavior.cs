using System.Collections;
using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
    public Vector3Data v3Data;
    public BoolData canRun;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    
    public void SetPosition()
    {
        SetV3Value();
    }

    private void SetV3Value()
    {
        v3Data.value = transform.position;
    }

    public void StartRunSetStart()
    {
        StartCoroutine(SendTransform());
    }
    
    private IEnumerator SendTransform()
    {
        while (canRun.value)
        {
            SetV3Value();
            yield return new WaitForFixedUpdate();
        }
    }
    
    public void ResetToZero()
    {
        transform.position = Vector3.zero;
    }
    
    
}
