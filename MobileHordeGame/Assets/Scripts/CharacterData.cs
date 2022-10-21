using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "Data/CharacterData")]

public class CharacterData : ScriptableObject
{ 
    public float health, speed, damage;
    public Vector3Data v3Position;
}
