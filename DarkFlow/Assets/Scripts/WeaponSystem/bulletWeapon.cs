using UnityEngine;


public class bulletWeapon : MonoBehaviour
{
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
