using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private string[] powerUpTags = {"DMGPowerUp", "MvSPDPowerUp", "FrPowerUp", "Heal"};
    
    private Rigidbody2D enemyRB;
    private bool canRun;
    private float speed;
    private float damage;
    private float health;
    private Vector2 moveDirection;
    private Vector3 playerLocation;
    

    public CharacterData enemyData;
    public NavAgentBehaviour navAgentBehaviour;
    
    private WaitForFixedUpdate wffuObj= new WaitForFixedUpdate();
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        navAgentBehaviour = GetComponent<NavAgentBehaviour>();
        speed = enemyData.speed;
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
            
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            CanRunCheck();
            yield return wffuObj;
        }
        navAgentBehaviour.SetToCurrentLocation();
        }
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DmgPlayer(dmgToGive);
        }
        if (((IList)powerUpTags).Contains(other.gameObject.tag))
        {
            Destroy(other.gameObject);
        }
    }
    
    public void DamageTaken(float num)
    {
        currentHealth -= num;
    }*/
}

