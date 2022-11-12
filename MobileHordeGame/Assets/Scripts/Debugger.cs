using UnityEngine;

[CreateAssetMenu (fileName = "Debugger", menuName = "Debugger")]
public class Debugger : ScriptableObject
{
       public void OnDebug(string obj)
       {
              Debug.Log(obj);
       }
       
       public void OnDebug(float obj)
       {
              Debug.Log(obj);
       }
       
       public void OnDebug(bool obj)
       {
              Debug.Log(obj);
       }
       
       public void OnDebug(object obj)
       {
              Debug.Log(obj);
       }
       
       public void OnDebug(int obj)
       {
              Debug.Log(obj);
       }
}