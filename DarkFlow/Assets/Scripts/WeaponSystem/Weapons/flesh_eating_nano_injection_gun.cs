using UnityEngine;

[CreateAssetMenu(fileName = "NanoInjectionGun", menuName = "Weapons/NanoInjectionGun")]
public class NanoInjectionGunAttributes : ScriptableObject
{
    [Header("Weapon Attributes")]
    public string weaponName = "Flesh-Eating Nano-Injection Gun";
    [TextArea(4, 10)]
    public string weaponDescription = "Injects nanobots that consume flesh from within, leaving the victim in agonizing pain as their body is slowly devoured.";
    
    public float damagePerShot = 10f; // Damage inflicted per shot
    public float initialContinuousDamageRate = 2f; // Initial rate of continuous damage
    public float damageIncreasePerShot = 1.5f; // Increase in damage rate per shot
    public string ammunitionType = "Nanotech Ammunition";
}
