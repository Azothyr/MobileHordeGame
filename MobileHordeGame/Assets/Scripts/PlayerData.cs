using UnityEngine;

[CreateAssetMenu (fileName = "CharacterData", menuName = "Data/ControllerData/CharacterData/PlayerData")]
public class PlayerData : CharacterData
{
    public BoolData isFiring;
    public Vector2Data aimDirection;
    public Vector3Data v3Position;
}
