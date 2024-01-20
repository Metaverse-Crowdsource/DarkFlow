using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    private List<GameObject> weapons = new List<GameObject>();
    private int currentWeaponIndex = -1;

    public void AddWeapon(GameObject weaponPrefab)
    {
        GameObject weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        weapon.transform.SetParent(transform); // Set the player as the parent of the weapon
        weapons.Add(weapon);
        weapon.SetActive(false); // Start with the weapon inactive
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EquipNextWeapon();
        }
    }

    private void EquipNextWeapon()
    {
        if (weapons.Count == 0)
            return;

        if (currentWeaponIndex != -1)
            weapons[currentWeaponIndex].SetActive(false);

        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        weapons[currentWeaponIndex].SetActive(true);
    }
}
