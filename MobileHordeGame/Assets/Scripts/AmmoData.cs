using UnityEngine;

[CreateAssetMenu (fileName = "AmmoData", menuName = "Data/ControllerData/AmmoData")]
public class AmmoData : ScriptableObject
{
    public GameObject prefab;
    public bool rangedAmmo;
    public float speed, damage, currentLifeTime, maxLifeTime, fireRate, fireTimer;
    public Vector2Data attackDirection;
    public Vector3Data playerLocation;
}