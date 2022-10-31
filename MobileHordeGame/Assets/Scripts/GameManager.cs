using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IntData time;
    public IntData difficultyBase;
    public IntData difficultyModifier;
    public IntData roundBase;
    public FloatData roundModifier;

    private int timeModifier;
    
    public void spawnRate()
    {
        timeModifier = time.value / 2;
        
    }
}
