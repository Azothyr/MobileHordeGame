using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent deathEvent;
    
    private bool canRun;
    private float damage;
    private float health;
    private Vector2 moveDirection;
    private Vector3 playerLocation;
    

    public EnemyData enemyData;
    public NavAgentBehaviour navAgentBehaviour;
    
    private WaitForFixedUpdate wffuObj= new WaitForFixedUpdate();
    private void Awake()
    {
        navAgentBehaviour = GetComponent<NavAgentBehaviour>();
        //enemyData.speed;
        damage = enemyData.damage;
        health = enemyData.health;
        StartPursuit();
    }

    private void CanRunCheck()
    {
        canRun = enemyData.canRun.value;
    }
    
    public void StartPursuit()
    {
        StartCoroutine(Pursuit());
    }
    
    private IEnumerator Pursuit()
    {
        CanRunCheck();
        while (canRun)
        { 
            navAgentBehaviour.SetV3ToPlayer();
            
            CanRunCheck();
            yield return wffuObj;
        }
        navAgentBehaviour.SetToCurrentLocation();
        }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.DamagePlayer(damage);
        }
    }
    
    public void DamageEnemy(float damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
        {
            deathEvent.Invoke();
        }
    }
}

