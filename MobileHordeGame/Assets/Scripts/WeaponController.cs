using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData weaponData;

    private bool rangeCheck;
    private bool canFire;

    private GameObject objPrefab;

    private float fireRate;
    private float fireTimer;

    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();

    private void Awake()
    {
        rangeCheck = weaponData.rangedWeaponCheck;
        canFire = weaponData.isFiring.value;
        objPrefab = weaponData.prefab;
        fireRate = weaponData.ammoData.fireRate;
        fireTimer = weaponData.ammoData.fireTimer;
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
        while (rangeCheck)
        {
            if (canFire)
            {
                fireTimer -= Time.fixedDeltaTime;
                if (fireTimer <= 0)
                {
                    fireTimer = fireRate;
                    Instantiate(objPrefab, transform.position, quaternion.identity);
                }
            }
            else if (!canFire)
            {
                if (fireTimer > 0)
                {
                    fireTimer -= Time.fixedDeltaTime;
                } 
            }
            canFire = weaponData.isFiring.value;
            yield return wffuObj;
        }
        /*
        while (!rangeCheck)
        {
            if (canFire)
            {
                fireTimer -= Time.fixedDeltaTime;
                if (fireTimer <= 0)
                {
                    fireTimer = fireRate;
                }
            }
            else if (!canFire)
            {
                if (fireTimer > 0)
                {
                    fireTimer -= Time.fixedDeltaTime;
                } 
            }
            canFire = weaponData.isFiring.value;
            yield return wffuObj;
        }
        */
    }
}
