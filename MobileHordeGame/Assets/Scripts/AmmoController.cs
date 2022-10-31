using System.Collections;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public PlayerData playerData;

    private bool isFiring;
    private bool piercing= false; 
    private float currentLifeTime;
    private float maxLifeTime;
    private float speed;
    private float damage;
    //private float knockBack = .01f;
    private Vector2 inputFireDirection;
    private Vector2 fireDirection;
    private Vector3 playerLocation;
    
    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();

    private void Awake()
    {
        isFiring = playerData.weaponData.isFiring;
        maxLifeTime = playerData.weaponData.ammoData.maxLifeTime;
        currentLifeTime = maxLifeTime;
        speed = playerData.weaponData.ammoData.speed;
        damage = playerData.weaponData.ammoData.damage;
        StartAmmoCheck();
    }
    
    public void StartAmmoCheck()
    {
        StartCoroutine(Ammo());
    }
    
    public void StopAmmoCheck()
    {
        StopCoroutine(Ammo());
    }

    private IEnumerator Ammo()
    {
        fireDirection = playerData.weaponData.ammoData.attackDirection.GetValue();
            
        while (isFiring)
        {
            transform.Translate(fireDirection * (speed * Time.deltaTime));
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime <= 0)
            {
                Destroy(gameObject);
            }
            
            yield return wffuObj;
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            //playerLocation = playerData.v3Position.value;
            
            enemy.DamageEnemy(damage);
            
            /*Vector2 awayFromPlayer = (other.transform.position - playerLocation).normalized;
            enemy.enemyRB.AddForce(awayFromPlayer * knockBack, ForceMode2D.Impulse);*/
            
            if (!piercing)
            {
                Destroy(gameObject);
            }
        }
    }
}
