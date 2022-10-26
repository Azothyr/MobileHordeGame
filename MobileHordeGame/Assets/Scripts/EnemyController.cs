using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private string[] powerUpTags = {"DMGPowerUp", "MvSPDPowerUp", "FrPowerUp", "Heal"};
    
    private Rigidbody2D enemyRB;
    private float speed;

    private float damage;
    private float health;
    

    public CharacterData enemyData;
    
    private WaitForFixedUpdate wffuObj= new WaitForFixedUpdate();
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        speed = enemyData.speed;
        damage = enemyData.damage;
        health = enemyData.health;
    }
    
    private void StartPursuit()
    {
        //StartCoroutine();
    }
    /*
    private void Update()
    {
        
        
        if (player != null)
        {
            transform.LookAt(player.transform.position);
            enemyRB.velocity = (transform.forward.normalized * moveSpeed);
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
    
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

