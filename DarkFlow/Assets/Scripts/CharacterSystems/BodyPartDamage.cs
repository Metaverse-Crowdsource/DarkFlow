using UnityEngine;
using UnityEngine.UI;

public class BodyPartDamage : MonoBehaviour
{
    [System.Serializable]
    public class BodyPart
    {
        public string name;
        public float health;
        public Image bodyPartImage; // Assign UI Image for each body part
    }

    public BodyPart[] bodyParts;
    public float maxHealth = 100f;

    void Start()
    {
        foreach (var part in bodyParts)
        {
            part.health = maxHealth;
            UpdateBodyPartUI(part);
        }
    }

    public void TakeDamage(string bodyPartName, float damage)
    {
        foreach (var part in bodyParts)
        {
            if (part.name.Equals(bodyPartName))
            {
                part.health -= damage;
                part.health = Mathf.Clamp(part.health, 0, maxHealth);
                UpdateBodyPartUI(part);
                ApplyEffectBasedOnDamage(part);
                break;
            }
        }
    }

    private void UpdateBodyPartUI(BodyPart part)
    {
        if (part.health <= 0)
        {
            part.bodyPartImage.color = Color.black; // Complete damage
        }
        else if (part.health < maxHealth * 0.3f)
        {
            part.bodyPartImage.color = Color.red; // Critical damage
        }
        else if (part.health < maxHealth * 0.6f)
        {
            part.bodyPartImage.color = new Color(1, 0.5f, 0); // Worse damage (orange)
        }
        else if (part.health < maxHealth)
        {
            part.bodyPartImage.color = Color.yellow; // Moderate damage
        }
        else
        {
            part.bodyPartImage.color = Color.green; // No damage
        }
    }

    private void ApplyEffectBasedOnDamage(BodyPart part)
    {
        // Here you can implement the effect each type of damage has on the player
        // For example, if a leg is damaged, you might reduce the player's speed
    }
}
