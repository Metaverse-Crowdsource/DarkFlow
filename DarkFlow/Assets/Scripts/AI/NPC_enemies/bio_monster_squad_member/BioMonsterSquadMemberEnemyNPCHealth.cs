using UnityEngine;

[CreateAssetMenu(fileName = "BioMonsterSquadMemberEnemyNPCHealth", menuName = "Health/BioMonsterSquadMemberEnemyNPCHealth", order = 1)]
public class BioMonsterSquadMemberEnemyNPCHealth : ScriptableObject
{
    public int maxHealth = 100; // Maximum health points for this enemy type
    public int currentHealth; // Current health of the enemy

    // Call this method to initialize the health when you spawn the enemy.
    public void InitializeHealth()
    {
        currentHealth = maxHealth;
    }

    // Method to take damage and update the current health.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle the enemy's death.
    void Die()
    {
        // Here you can add the logic for the enemy's death, like playing an animation or dropping items.
        // Actual destruction of the game object should be handled by the script that uses this ScriptableObject.
        // For now, this method will simply log a message.
        Debug.Log("BioMonsterSquadMemberEnemyNPC has died.");
    }
}
