using UnityEngine;
using Unity.Netcode;

public class bulletWeapon : NetworkBehaviour
{

    public float bulletSpeed = 10f; // This can be changed per weapon, the weapon will actually modify this speed itself.

    void Update()
    {
 //       if(isServer)
 //       {
 //           transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime); // Probably do this as a Rigidbody later for bullet drop. Maybe not.
 //       }
    }

    void OnCollisionEnter(Collision H)
    {
        if (H.transform.tag == "PlayerLimb")
        {
            H.transform.GetComponent<limbHealth>().Damage(100f);
            H.transform.localScale = new Vector3(0, 0, 0);
        }

    }

}
