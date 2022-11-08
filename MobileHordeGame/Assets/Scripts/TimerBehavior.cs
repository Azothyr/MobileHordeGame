using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerBehavior : MonoBehaviour
{
    public UnityEvent updateTextEvent;
    
    private float seconds =  0.01f;
    public BoolData canRun;
    public FloatData timer;

    private float elapsedTime;

    private WaitForSecondsRealtime wfsrtObj;

    private void Start()
    {
        wfsrtObj = new WaitForSecondsRealtime(seconds);
    }
    
    public void StartTimer()
    {
        StartCoroutine(UpdateTimer());
    }    
    
    public void StopTimer()
    {
        StopCoroutine(UpdateTimer());
    }
    
    private IEnumerator UpdateTimer()
    {
        while (canRun.value)
        {
            elapsedTime += Time.deltaTime;
            timer.SetValue(elapsedTime);
            updateTextEvent.Invoke();
            yield return null;
        }
    }
}
