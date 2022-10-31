using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBehavior : MonoBehaviour
{
    public Instancer instancer;
    public Vector3Data playerV3, spawnLocation;
    public BoolData canRun;
    public FloatData time;
    public IntData spawnCount, enemiesAlive;
    public float distanceMin, distanceMax, spawnDelay;
    
    public GameObject prefab;

    private float lowerRangeMin, upperRangeMax, lowerRangeMax, upperRangeMin, num1, num2;
    private Vector3 spawnV3, randomV3;

    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();
    private WaitForSeconds wfsObj;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(spawnDelay);
        spawnCount.value = 5;
    }

    private void CanRunCheck()
    {
        canRun.GetValue();
    }
    
    public void StartSpawning()
    {
        StartCoroutine(Spawn());
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
        
        num1 += playerV3.value.x;
        num2 += playerV3.value.x;
        randomV3 = new Vector3(num1,num2,0);

        num1 = new float();
        num2 = new float();
        
        return randomV3;
    }
    
    private IEnumerator Spawn()
    {
        while (canRun.value)
        {
            if (spawnCount.value > 0)
            {
                spawnV3 = GenerateSpawnV3Value(distanceMin, distanceMax);
                spawnLocation.SetValue(spawnV3.x,spawnV3.y,spawnV3.z);
                instancer.CreateInstance(spawnLocation);
                
                spawnCount.UpdateValue(-1);
            }
            yield return wfsObj;
        }
    }
    
}
