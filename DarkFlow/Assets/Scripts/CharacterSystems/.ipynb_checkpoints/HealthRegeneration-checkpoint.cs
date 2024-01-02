using UnityEngine;
using UnityEngine.UI;

public class HealthRegeneration : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // Regenerate health logic
        if (currentHealth < maxHealth)
        {
            currentHealth += Time.deltaTime * 5f; // Regeneration rate
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        if(healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
