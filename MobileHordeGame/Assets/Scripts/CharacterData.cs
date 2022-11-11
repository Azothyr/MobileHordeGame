using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "Data/ControllerData/CharacterData/CharacterData")]

public class CharacterData : ScriptableObject
{
    public new string name;
    public ID id;
    public float health, speed, damage;
    public WeaponData weaponData;
    public BoolData canRun, gameOver;
}
