using UnityEngine;

// Create a ScriptableObject that represents the health of an enemy.
[CreateAssetMenu(fileName = "EnemyHealth", menuName = "ScriptableObjects/EnemyHealth", order = 1)]
public class EnemyHealth : ScriptableObject
{
    public int maxHealth = 5; // Health points, as per our requirement
    public int currentHealth;

    // Call this method to initialize the health when you spawn the enemy.
    public void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Here we can add the logic for the enemy's death, like playing an animation.
        // Actual destruction of the game object should be handled by the script that uses this ScriptableObject.
        // For now, this method will simply log a message.
        Debug.Log("Enemy has died.");
    }
}
