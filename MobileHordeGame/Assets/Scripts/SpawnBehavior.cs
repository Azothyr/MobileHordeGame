using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SpawnBehavior : MonoBehaviour
{
    public UnityEvent spawnEvent, endSpawnEvent;
    public Instancer instancer;
    public Vector3Data playerV3, spawnLocation;
    public BoolData canRun;
    public IntData spawnCount, enemiesAlive, roundNum, roundSpawnIncrease, spawnBase, difficultySpawnModifier;
    public FloatData timeElapsed, roundSpawnModifier;
    public float distanceMin, distanceMax, spawnDelay;

    private float lowerRangeMin, upperRangeMax, lowerRangeMax, upperRangeMin, num1, num2;
    private int timeDifficultyModifier, roundModifier, count;
    private Vector3 spawnV3, randomV3, playerLoc;
    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();
    private WaitForSeconds wfsObj;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(spawnDelay);
    }

    public void StartSpawning()
    {
        GenerateSpawnCount();
        StartCoroutine(Spawn());
    }    
    
    public void StopSpawning()
    {
        StopCoroutine(Spawn());
    }
    
    private Vector3 GenerateSpawnV3Value(float rangeFromObjectMin, float rangeFromObjectMax)
    {
        lowerRangeMin = (-1 * rangeFromObjectMax);
        upperRangeMax = rangeFromObjectMax;
        lowerRangeMax = (-1 * rangeFromObjectMin);
        upperRangeMin = rangeFromObjectMin;
        
        while (!(num1 >= lowerRangeMin && num1 <= lowerRangeMax || 
                 num1 >= upperRangeMin && num1 <= upperRangeMax))
        {
            num1 = Random.Range(lowerRangeMin, upperRangeMax);
        }       
        
        while (!(num2 >= lowerRangeMin && num2 <= lowerRangeMax || 
                 num2 >= upperRangeMin && num2 <= upperRangeMax))
        {
            num2 = Random.Range(lowerRangeMin, upperRangeMax);
        }
        playerV3.GetValue();
        
        num1 += playerV3.value.x;
        num2 += playerV3.value.y;
        randomV3 = new Vector3(num1,num2,0);

        num1 = new float();
        num2 = new float();
        
        return randomV3;
    }

    private void GenerateSpawnCount()
    {
        if (roundNum.value == 1)
        {
            spawnCount.SetValue(spawnBase);
        }
        else if (roundNum.value > 1)
        {
            timeDifficultyModifier = (int) ((timeElapsed.value / 60) * difficultySpawnModifier.value);
            roundModifier = (int) ((roundNum.value * roundSpawnIncrease.value) * roundSpawnModifier.value);
            count = spawnBase.value + timeDifficultyModifier + roundModifier;
            spawnCount.SetValue(count);
        }
    }
    private IEnumerator Spawn()
    {
        while (canRun.value && spawnCount.value > 0)
        {
            spawnV3 = GenerateSpawnV3Value(distanceMin, distanceMax);
            spawnLocation.SetValue(spawnV3.x,spawnV3.y,spawnV3.z);
            instancer.CreateInstance(spawnLocation);
                
            enemiesAlive.UpdateValue(1);
            spawnCount.UpdateValue(-1);
            spawnEvent.Invoke();
            yield return wfsObj;
        }
        endSpawnEvent.Invoke();
    }
}
