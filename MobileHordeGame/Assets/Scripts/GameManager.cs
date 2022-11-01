using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatData time;
    public FloatData roundModifier;
    public FloatData difficultyModifier;
    public IntData difficultyBaseModifier;
    public IntData roundBaseModifier;
    public IntData round;
    

    private int timeDifficultyModifier;

    public void GameStart()
    {
        round.value = 1;
    }

    private void SetDifficulty()
    {
        
    }

    public void GenerateSpawnCount()
    {
        timeDifficultyModifier = (int) (time.value / 2f);
        
    }
}
