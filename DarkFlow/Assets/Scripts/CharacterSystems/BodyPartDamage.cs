using UnityEngine;
using UnityEngine.UI;

public class BodyPartDamage : MonoBehaviour
{
    [System.Serializable]
    public class BodyPart
    {
        public string name;
        public float health;
        public Image silhouetteImage; // Assign UI Image for each body part
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
        Color color = Color.green;
        if (part.health < maxHealth * 0.3f)
        {
            color = Color.red; // Severe damage
        }
        else if (part.health < maxHealth * 0.6f)
        {
            color = new Color(1, 0.5f, 0); // Orange for moderate damage
        }

        part.silhouetteImage.color = color;
    }

    private void ApplyEffectBasedOnDamage(BodyPart part)
    {
        if (part.name == "Leg" && part.health < maxHealth * 0.5f)
        {
            // Implement logic for limping
        }
        else if (part.name == "Arm" && part.health < maxHealth * 0.5f)
        {
            // Implement logic for reduced accuracy
        }
        // Add more conditions for other body parts and their specific effects
    }
}
