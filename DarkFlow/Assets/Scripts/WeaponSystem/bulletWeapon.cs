using UnityEngine;
using Unity.Netcode;

public class bulletWeapon : NetworkBehaviour
{
    [SerializeField] private bool explodeOnContact; // Placeholder for future use.

    void Update()
    {
        // Bullet movement logic (if needed)
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision object has a tag indicating it's a player limb
        if (collision.transform.tag == "PlayerLimb")
        {
            // Retrieve the BodyPartDamage component from the limb
            BodyPartDamage bodyPartDamage = collision.transform.GetComponent<BodyPartDamage>();

            // Check if the limb has the BodyPartDamage component
            if (bodyPartDamage != null)
            {
                // Apply damage to the limb
                bodyPartDamage.TakeDamage(collision.transform.name, 100f); // Replace 100f with the desired damage amount

                // Optional: Apply any other effects
                // Example: collision.transform.localScale = new Vector3(0, 0, 0);
            }
        }

        // Destroy the bullet object upon collision
        Destroy(gameObject);
    }
}
