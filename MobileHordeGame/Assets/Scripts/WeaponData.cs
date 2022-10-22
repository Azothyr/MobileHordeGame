using UnityEngine;

[CreateAssetMenu (fileName = "WeaponData", menuName = "Data/ControllerData/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string name;
    public BoolData isFiring;
    public AmmoData ammoData;
}
