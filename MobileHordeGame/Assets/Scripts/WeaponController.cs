using System;
using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData weaponData;

    private bool rangeCheck;
    private bool canFire;

    private GameObject obj;

    private float fireRate;
    private float fireTimer;
    private float currentLifeTime;
    private float maxLifeTime;
    
    private WaitForFixedUpdate wffuObj;

    private void Start()
    {
        wffuObj = new WaitForFixedUpdate();
        rangeCheck = weaponData.rangedWeaponCheck;
        canFire = weaponData.isFiring;
        obj = weaponData.prefab;
        fireRate = weaponData.ammoData.fireRate;
        fireTimer = weaponData.ammoData.fireTimer;
        currentLifeTime = weaponData.ammoData.currentLifeTime;
        maxLifeTime = weaponData.ammoData.maxLifeTime;
    }

    void Awake()
    {

    }

    public void StartAttackCheck()
    {
        StartCoroutine(Attack());
    }
    public void StopAttackCheck()
    {
        StopCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (rangeCheck == true)
        {
            if (canFire)
            {
                fireTimer -= Time.fixedDeltaTime;
                if (fireTimer <= 0)
                {
                    fireTimer = fireRate;
                    Instantiate(obj, transform.position, transform.rotation);
                }
            }
            else if (!canFire)
            {
                if (fireTimer > 0)
                {
                    fireTimer -= Time.fixedDeltaTime;
                } 
            }
            yield return wffuObj;
        }
    }
/*    
    public AmmoController[] ammoPrefab;

    public CharacterData playerData;
    private float shotCounter;
    private float ammoSpd;
    private float reload;
    

    public Transform fireSpawn;

    void Start()
    {
        reload = playerData.reloadTime;
        
    }

    void Update()
    {

        if (isFiring)
        {
            //if we are firing the fire rate counter will count down till next available shot
            shotCounter -= Time.fixedDeltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = reload;
                //throw a random ammo out
                int index = Random.Range(0, ((ICollection) ammoPrefab).Count);
                Instantiate(ammoPrefab[index], fireSpawn.position, fireSpawn.rotation);
            }
        }
        //setting fire rate to be ready to fire if we haven't fired since FR hit 0
        else if(!isFiring)
        {
            if (shotCounter > 0)
            {
                shotCounter -= Time.fixedDeltaTime;
            }
        }
    }
    
*/
}
