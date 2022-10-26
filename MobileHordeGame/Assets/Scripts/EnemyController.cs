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
    
    private WaitForFixedUpdate wffuObj= new WaitForFixedUpdate();
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        speed = enemyData.speed;
        damage = enemyData.damage;
        health = enemyData.health;
        canRun = enemyData.canRun;
        playerLocation = enemyData.v3Position.GetValue();
    }
    
    public void StartPursuit()
    {
        StartCoroutine(Pursuit());
    }
    
    private IEnumerator Pursuit()
    {
        while (canRun)
        {
            playerLocation = enemyData.v3Position.GetValue();
            moveDirection = new Vector2(playerLocation.x, playerLocation.y);
            enemyRB.MovePosition(enemyRB.position + moveDirection * (speed * Time.deltaTime));
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            yield return wffuObj;
        }
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

