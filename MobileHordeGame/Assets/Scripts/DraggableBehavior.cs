using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehavior : MonoBehaviour
{
    private Camera cameraObj;
    public bool draggable;
    public Vector3 position, offset;
    public UnityEvent startDragEvent, endDragEvent;
    
    void Start()
    {
        cameraObj = Camera.main;
    }

    public IEnumerator OnMouseDown()
    {
        //creates offset length data between where the object is in relation to the world - the length data
        //between where the mouse is from the camera (camera is 0 0 0)
        offset = transform.position - cameraObj.ScreenToWorldPoint(Input.mousePosition);
        draggable = true;
        startDragEvent.Invoke();
        yield return new WaitForFixedUpdate();
        
        while (draggable)
        {
            //waits for a fixed update before performing next steps
            yield return new WaitForFixedUpdate();
            //Gets the mouse position on drag (does not move object just supplies data which is not offset)
            //and then adds the offset
            position = cameraObj.ScreenToWorldPoint(Input.mousePosition) + offset;
            //Applies the mouse position (gotten from line above & the defined offset) to the vector of the object
            transform.position = position;
            //Debug.Log("Drag");
        }
    }

    private void OnMouseUp()
    {
        draggable = false;
        endDragEvent.Invoke();
    }
}
