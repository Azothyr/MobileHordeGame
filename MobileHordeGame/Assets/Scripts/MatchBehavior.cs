using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        //Debug.Log(idObj);
        //Debug.Log(other.GetComponent<IDContainerBehavior>().idObj);
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj == null)
            yield break;

        var otherID = tempObj.idObj;
        if (otherID == idObj)
        {
            matchEvent.Invoke();
            //Debug.Log("Matched");
        }
        else
        {
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            noMatchDelayedEvent.Invoke();
            //Debug.Log("No Match");
        }
    }
}
