using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "Data/ControllerData/CharacterData")]

public class CharacterData : ScriptableObject
{
    public new string name;
    public ID id;
    public float health, speed, damage;
    public WeaponData weaponData;
    public BoolData canRun, isFiring;
    public Vector2Data aimDirection;
    public Vector3Data v3Position;
}
