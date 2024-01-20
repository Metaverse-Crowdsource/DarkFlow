using UnityEngine;

[CreateAssetMenu(fileName = "BioMonsterSquadMemberEnemyNPC", menuName = "NPCs/BioMonsterSquadMemberEnemyNPC", order = 1)]
public class BioMonsterSquadMemberEnemyNPC : ScriptableObject
{
    [Header("Bio Monster Squad Member Enemy NPC")]
    [Space]
    public string enemyName; // NPC's name
    [TextArea(4, 10)]
    public string enemyDescription; // NPC's description
    public bool isHostile = true; // Whether this NPC is hostile
    public string enemyDialogue; // Dialogue when interacting with the NPC
    public GameObject dropOnDeath; // Item to drop when the NPC is defeated
    public float detectionRadius = 10f; // Radius within which the enemy can detect the player
    public float attackRange = 10f; // Range at which the enemy can start shooting
    public float attackCooldown = 2f; // Cooldown between shots
    public int damage = 10; // Damage inflicted by the enemy's shots
    public GameObject bulletPrefab; // Prefab of the bullet to shoot
    public float bulletSpeed = 10f; // Speed of the bullets

    // Add any other specific properties or behaviors for this enemy NPC here
}
