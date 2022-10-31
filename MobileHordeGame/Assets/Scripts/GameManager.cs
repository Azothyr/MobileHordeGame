using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatData time;
    public FloatData roundModifier;
    public FloatData difficultyModifier;
    public IntData difficultyBase;
    public IntData roundBase;
    

    private int timeModifier;
    
    public void spawnRate()
    {
        timeModifier = (int) (time.value / 2f);
        
    }
}
