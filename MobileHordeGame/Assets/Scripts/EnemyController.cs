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
    
    public void StartPursuit()
    {
        StartCoroutine(Pursuit());
    }
    
    private IEnumerator Pursuit()
    {
        while (enemyData.canRun.value)
        { 
            navAgentBehaviour.SetV3ToPlayer();
            
            yield return wffuObj;
        }
        navAgentBehaviour.SetToCurrentLocation();
        GameOverCheck();
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

    private void GameOverCheck()
    {
        if (enemyData.gameOver.value)
        {
            deathEvent.Invoke();
        }
    }
}

