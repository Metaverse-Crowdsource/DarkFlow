using UnityEngine;
using UnityEngine.UI;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    private float currentHealth;
    public float regenerationRate = 5f; // Health regeneration rate per second

    public Image healthBar; // Reference to UI health bar image

    private void Start()
    {
        currentHealth = maxHealth; // Initialize health
        UpdateHealthBar(); // Update the health bar UI
    }

    private void Update()
    {
        RegenerateHealth();
    }

    private void RegenerateHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += regenerationRate * Time.deltaTime;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            UpdateHealthBar(); // Update the health bar UI whenever health changes
        }
    }

    // Public method to get the current health
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Update the health bar UI
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
