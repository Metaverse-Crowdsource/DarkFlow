using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    private float currentStamina;
    public Image staminaBar;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    private void Update()
    {
        // Decrease stamina logic
        if (currentStamina > 0)
        {
            currentStamina -= Time.deltaTime * 10f; // Decrease rate
            currentStamina = Mathf.Max(currentStamina, 0);
            UpdateStaminaBar();
        }
        // Regenerate stamina logic
        else
        {
            currentStamina += Time.deltaTime * 5f; // Regeneration rate
            currentStamina = Mathf.Min(currentStamina, maxStamina);
            UpdateStaminaBar();
        }
    }

    private void UpdateStaminaBar()
    {
        if(staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;
        }
    }
}
