using System;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public WeaponData weaponData;

    private bool isFiring;

    private void Awake()
    {
        isFiring = weaponData.isFiring;
    }
    /*
    public float spd;
    private float spinSpeed;
    private float ammoTTL;
    private int dmgToGive;
    private float knockStrength;

    public PlayerData playerData;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();


    }

    void Update()
    {
        //transform.Rotate(Vector3.forward * (spinSpeed * Time.deltaTime));
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
