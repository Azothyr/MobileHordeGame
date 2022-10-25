using System;
using System.Collections;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public WeaponData weaponData;

    private bool isFiring;
    private float currentLifeTime;
    private float maxLifeTime;
    private float speed;
    private Vector2 inputFireDirection;
    private Vector2 fireDirection;
    
    private WaitForFixedUpdate wffuObj;

    private void Awake()
    {
        wffuObj = new WaitForFixedUpdate();
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
            Debug.Log(fireDirection);
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
    void Update()
    {
        //transform.Translate(Vector3.forward * (spd * Time.deltaTime));
        //Destroy ammo after (ammoTTL) sec
        ammoTTL -= Time.deltaTime;
        if (ammoTTL <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //Destroy Karen on hit
        if (other.gameObject.CompareTag("Karen"))
        {
            other.gameObject.GetComponent<EnemyController>().DmgEnemy(dmgToGive);
            
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - player.transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * knockStrength, ForceMode.Force);
            
            Destroy(gameObject);
        }
    }
*/
}
