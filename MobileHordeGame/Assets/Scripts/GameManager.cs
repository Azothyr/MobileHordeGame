using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FloatData timeElapsed;
    public FloatData roundModifier;
    public FloatData difficultyModifier;
    public IntData difficultyBaseModifier;
    public IntData roundBaseModifier;
    public IntData round;
    

    private int timeDifficultyModifier;

    public void GameStart()
    {
        round.SetValue(1);
    }

    private void SetDifficulty()
    {
        
    }

    public void GenerateSpawnCount()
    {
        timeDifficultyModifier = (int) (timeElapsed.value / 2f);
        
    }
}
