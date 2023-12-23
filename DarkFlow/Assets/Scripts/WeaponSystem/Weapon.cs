using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : NetworkBehaviour // This is the Base Weapon class. We will have another script that will get these values.
{
    [Tooltip("Select the type of weapon this will be. This will not change your variables, but will effect how the weapon acts.")]
    public enum WeaponType // What type of weapon is it? We're going to need to know. 
    {
        Knife,
        Sword,
        Revolver,
        SemiHandgun,
        Shotgun,
        Rifle,
        RPG
    }

    public WeaponType weaponType;

    [Header("Weapon Appearance")]
    [Space]
    public GameObject weaponTransform;
    public Sprite weaponIcon;
    [Space]
    [Header("Weapon Identity")]
    [Space]
    public string weaponName;
    [TextArea(4,10)]
    public string weaponDescription;
    public float weaponDamage;
    public bool isRareWeapon;
    [Space]
    [Header("Ammo")]
    [Space]
    [Tooltip("The projectile -MUST- have the BulletWeapon script attached to the Transform.")]
    public GameObject weaponProjectile;
    public Transform firePoint;
    public float ammoInWeapon;
    public float ammoCarried; // Eventually will read the player's inventory for what they are carrying.
    [Space]
    [Header("Weapon Audio")]
    [Space]
    public AudioSource weaponAudioSource; // Audio comes from the weapon - Not a sound manager.
    [Tooltip("Blades should have multiple, Guns one or two.")]
    public AudioClip[] weaponSounds; // For bladed weapons to have multiple sounds, Firearms will usually have one, at most two.
    [Space]
    [Header("Market")]
    [Space]
    [Tooltip("If I sell it to an NPC, how much will I likely get?")]
    public float weaponCostPizzo; // How much does this cost in the market / can it be sold to a shop for?

    private void Start()
    {
        if (!weaponProjectile) 
        {
            if (weaponType != Weapon.WeaponType.Knife)
            {
                Debug.Log(weaponName + " does not have a projectile to fire!");
            }
            if (weaponType != Weapon.WeaponType.Sword)
            {
                Debug.Log(weaponName + " does not have a projectile to fire!");
            }
        }
    }

    private void Update()
    {
        FireKey(); // Appearance keeps Update looking cleaner and allows references to find anything that use this key. - Sona
    }

    public void FireKey()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && weaponProjectile)
        {
            PreFire();
        }
    }

    private void PreFire() // This will be the check that runs before the gun actually goes off. *Slaps roof* You can fit so many checks in here.
    {
        if (weaponType == Weapon.WeaponType.SemiHandgun) // Starting with SemiHandgun for now. Most guns will copy off of this in some way.
        {
            if (weaponProjectile) // Make sure we have a projectile, so it doesn't error out.
            {
                if (ammoInWeapon > 0) // Make sure we HAVE ammunition in the weapon.
                {
                    ShootWeapon(); // SHOTS FIRED!
                    ammoInWeapon--; // Minus one.
                }
                else
                {
                    Debug.Log(weaponName + " has no ammo."); // We can eventually trigger a reload or trigger clicking sound here.
                }
            }
        }
    }


    private void ShootWeapon() // Simple and pretty call. See how nice it looks?
    {
        GameObject bullet = Instantiate(weaponProjectile, transform.position, transform.rotation); // Test stuff.
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * 10f, ForceMode.Impulse); // Test stuff.
    }



}
