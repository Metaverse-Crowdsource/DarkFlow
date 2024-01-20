using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Knife,
        Sword,
        Revolver,
        SemiHandgun,
        Shotgun,
        Rifle,
        RPG,
        SMG1
    }

    public enum AmmoType
    {
        Neurotech,
        Energy,
        BioWeapon,
        Biotech,
        Radioactive,
        Ballistic,
        Fuel
    }

    private Dictionary<AmmoType, float> baseDamage = new Dictionary<AmmoType, float>();

    public WeaponType weaponType;
    public AmmoType ammoType;

    [Header("Weapon Appearance")]
    public GameObject weaponTransform;
    public Sprite weaponIcon;

    [Header("Weapon Identity")]
    public string weaponName;
    [TextArea(4, 10)]
    public string weaponDescription;
    public float weaponDamage;
    public bool isRareWeapon;

    [Header("Ammo")]
    public GameObject weaponProjectile;
    public Transform firePoint;
    public float ammoInWeapon;
    public float ammoCarried;

    [Header("Weapon Audio")]
    public AudioSource weaponAudioSource;
    public AudioClip[] weaponSounds;

    [Header("Market")]
    public float weaponCostQuint;

    [Header("SMG1 Specifics")]
    public int smg1AmmoCount = 30;
    public int smg1RoundDamage = 10;

    [Header("Linear Shooting")]
    public float raycastDistance = 100f;
    public LayerMask hitLayer;

    // Reference to the enemy's health scriptable object
    public BioMonsterSquadMemberEnemyNPCHealth enemyHealth;

    void Start()
    {
        InitializeAmmo();
        if (weaponType == WeaponType.SMG1)
        {
            ammoInWeapon = smg1AmmoCount;
            weaponDamage = smg1RoundDamage;
        }
    }

    void InitializeAmmo()
    {
        baseDamage[AmmoType.Neurotech] = 1.5f;
        // Initialize other ammo types and their damages...
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PreFire();
        }
    }

    void PreFire()
    {
        if (ammoInWeapon > 0)
        {
            ShootWeapon();
            ammoInWeapon--;
            PlayWeaponSound();
        }
        else
        {
            Debug.Log(weaponName + " has no ammo.");
        }
    }

    void ShootWeapon()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, hitLayer))
        {
            GameObject hitObject = hit.collider.gameObject;
            
            // Check if the hit object has an enemy health scriptable object
            BioMonsterSquadMemberEnemyNPCHealth enemy = hitObject.GetComponent<BioMonsterSquadMemberEnemyNPCHealth>();
            if (enemy != null)
            {
                // Calculate damage based on the weapon and apply it to the enemy's health
                enemy.TakeDamage((int)weaponDamage);
            }
        }

        // Play shooting animation or effects here.
    }

    void PlayWeaponSound()
    {
        if (weaponSounds.Length > 0)
        {
            int randInt = Random.Range(0, weaponSounds.Length);
            AudioClip weaponSound = weaponSounds[randInt];
            weaponAudioSource.PlayOneShot(weaponSound);
        }
    }
}
