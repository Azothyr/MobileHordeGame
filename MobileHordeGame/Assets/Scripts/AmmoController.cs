using System;
using System.Collections;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public WeaponData weaponData;
    public Vector3Data playerV3;

    private bool isFiring;
    private float currentLifeTime;
    private float maxLifeTime;
    private float speed;
    private Vector2 inputFireDirection;
    private Vector2 fireDirection;
    private Vector3 playerLocation;
    
    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();

    private void Awake()
    {
        isFiring = weaponData.isFiring;
        maxLifeTime = weaponData.ammoData.maxLifeTime;
        currentLifeTime = maxLifeTime;
        speed = weaponData.ammoData.speed;
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
        fireDirection = weaponData.ammoData.attackDirection.GetValue();
            
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
    /*
    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Karen"))
        {
            playerLocation = Vector3Data.GetValue();
            other.gameObject.GetComponent<EnemyController>().DmgEnemy(dmgToGive);
            
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - playerLocation;
            enemyRigidbody.AddForce(awayFromPlayer * knockStrength, ForceMode.Force);
            
            Destroy(gameObject);
        }
    }
    */
}
