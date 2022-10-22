using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData weaponData;
    public AmmoData AmmoData;
/*    
    public BoolData isFiring;
    
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
