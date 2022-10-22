using UnityEngine;

[CreateAssetMenu (fileName = "AmmoData", menuName = "Data/ControllerData/AmmoData")]
public class AmmoData : ScriptableObject
{
    public float speed, damage, currentLifeTime, maxLifeTime, fireRate, fireTimer;
    public GameObject prefab;
}