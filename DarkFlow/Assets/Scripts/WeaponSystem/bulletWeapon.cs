using UnityEngine;
using Unity.Netcode;

public class bulletWeapon : NetworkBehaviour {
    public int damage; // Damage the bullet will apply

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("NPC")) {
            var enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
