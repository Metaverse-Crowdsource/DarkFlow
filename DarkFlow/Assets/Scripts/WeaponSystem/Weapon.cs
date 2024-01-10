using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

// This class is used to define weapons in the game. It includes properties for visual appearance, audio, and functionality.
public class Weapon : NetworkBehaviour {
    // Enum for different types of weapons available in the game.
    public enum WeaponType {
        Knife,
        Sword,
        Revolver,
        SemiHandgun,
        Shotgun,
        Rifle,
        RPG,
        SMG1 // SMG1 added for submachine guns.
    }

    // Enum for different types of ammo that might have different effects or damage.
    public enum AmmoType {
        Neurotech,
        Energy,
        BioWeapon,
        Biotech,
        Radioactive,
        Ballistic,
        Fuel
    }

    // Dictionary to store base damage values for different ammo types.
    private Dictionary<AmmoType, float> baseDamage = new Dictionary<AmmoType, float>();

    // Public variables can be set in the editor to configure each weapon instance.
    public WeaponType weaponType;
    public AmmoType ammoType;

    [Header("Weapon Appearance")]
    // Reference to the GameObject that represents the weapon in the game world.
    public GameObject weaponTransform;
    // The icon that represents the weapon in UI.
    public Sprite weaponIcon;

    [Header("Weapon Identity")]
    // The name and description for the weapon.
    public string weaponName;
    [TextArea(4, 10)]
    public string weaponDescription;
    // The amount of damage this weapon does.
    public float weaponDamage;
    // Rarity flag for special weapons.
    public bool isRareWeapon;

    [Header("Ammo")]
    // The projectile prefab that this weapon fires. It must have the BulletWeapon script attached.
    public GameObject weaponProjectile;
    // The point from which projectiles are fired.
    public Transform firePoint;
    // The amount of ammo currently loaded in the weapon.
    public float ammoInWeapon;
    // The amount of ammo the player is carrying.
    public float ammoCarried;

    [Header("Weapon Audio")]
    // The audio source from which gun sounds are played.
    public AudioSource weaponAudioSource;
    // Array of audio clips that can be played when the weapon is used.
    public AudioClip[] weaponSounds;

    [Header("Market")]
    // The price of the weapon in-game currency if sold to an NPC.
    public float weaponCostQuint;

    [Header("SMG1 Specifics")]
    // Specific properties for the SMG1 weapon type.
    public int smg1AmmoCount = 30;
    public int smg1RoundDamage = 10;

    // At the start, initialize the ammo based on weapon type and set the damage for SMG1.
    void Start() {
        InitializeAmmo();
        if (weaponType == WeaponType.SMG1) {
            ammoInWeapon = smg1AmmoCount;
            weaponDamage = smg1RoundDamage;
        }
    }

    // Initializes base damage for each ammo type.
    void InitializeAmmo() {
        // Base damages are set here but could be moved to an external configuration for easier balancing.
        baseDamage[AmmoType.Neurotech] = 1.5f;
        // Other ammo types and their damages...
    }

    // Update is called once per frame and listens for input to fire the weapon.
    void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame && weaponProjectile) {
            PreFire();
        }
    }

    // PreFire checks if the weapon has ammo and then performs the shoot action.
    void PreFire() {
        // If there is ammo in the weapon, shoot and play the corresponding sound.
        if (ammoInWeapon > 0) {
            ShootWeapon();
            ammoInWeapon--;
            PlayWeaponSound();
        } else {
            Debug.Log(weaponName + " has no ammo."); // Could be replaced with a UI message or sound.
        }
    }

    // Instantiates the projectile and applies force to it to simulate shooting.
    void ShootWeapon() {
        // Instantiate the bullet and set its damage based on the weapon's damage.
        var bullet = Instantiate(weaponProjectile, firePoint.position, firePoint.rotation);
        var bulletScript = bullet.GetComponent<bulletWeapon>();
        if (bulletScript != null) {
            bulletScript.damage = smg1RoundDamage;
        }
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * 10f, ForceMode.Impulse);
    }

    // Plays a random sound from the weaponSounds array.
    void PlayWeaponSound() {
        // Randomly select a sound to play for variability.
        if (weaponSounds.Length > 0) {
            int randInt = Random.Range(0, weaponSounds.Length);
            AudioClip weaponSound = weaponSounds[randInt];
            weaponAudioSource.PlayOneShot(weaponSound);
        }
    }
}
