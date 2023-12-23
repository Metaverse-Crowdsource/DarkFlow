using UnityEngine;
using Unity.Netcode;

public class bulletWeapon : NetworkBehaviour
{

    [SerializeField] private bool explodeOnContact; // Does nothing right now. Primarily for grenades and rockets.

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

        Destroy(this.gameObject);

    }

}
