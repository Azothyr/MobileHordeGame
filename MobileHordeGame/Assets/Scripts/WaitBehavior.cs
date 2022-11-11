using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaitBehavior : MonoBehaviour
{
    public UnityEvent endWait;
    public IntData intData;
    
    private int waitAmount;
    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();
    
    public void startWaitForSecondsEvent(int seconds)
    {
        StartCoroutine(WaitForSecondsEvent(seconds));
    }
    
    public void startWaitForZeroIntDataEvent()
    {
        StartCoroutine(WaitForZeroIntDataEvent(intData));
    }
    
    private IEnumerator WaitForZeroIntDataEvent(IntData obj)
    {
        waitAmount = obj.value;
        
        while (waitAmount > 0)
        {
            waitAmount = obj.value;
            yield return wffuObj;
        }
        endWait.Invoke();
    }
    
    private IEnumerator WaitForSecondsEvent(int num)
    {
        waitAmount = num;
        
        while (waitAmount > 0)
        {
            waitAmount--;
            yield return wffuObj;
        }
        
        endWait.Invoke();
    }
}
