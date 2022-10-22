using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "Data/ControllerData/CharacterData")]

public class CharacterData : ScriptableObject
{ 
    public float health, speed, damage;
    public BoolData canRun;
    public bool isFiring;
    public Vector2Data aimDirection;
    public Vector3Data v3Position;
}
