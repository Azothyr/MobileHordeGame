using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool canRun;
    private float damage;
    public float health;
    private Vector2 moveDirection;
    private Vector3 playerLocation;
    

    public EnemyData enemyData;
    public Rigidbody2D enemyRB;
    public NavAgentBehaviour navAgentBehaviour;
    
    private WaitForFixedUpdate wffuObj= new WaitForFixedUpdate();
    private void Awake()
    {
        navAgentBehaviour = GetComponent<NavAgentBehaviour>();
        enemyRB = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
        }
    }
}

