using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    public float maxHunger = 100f;
    private float currentHunger;
    public Image hungerBar;

    void Start()
    {
        currentHunger = maxHunger;
        UpdateHungerBar();
    }

    void Update()
    {
        // Decrease hunger over time or based on player actions
        // Example: currentHunger -= Time.deltaTime * hungerRate;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        UpdateHungerBar();
    }

    public void ConsumeFood(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        UpdateHungerBar();
    }

    private void UpdateHungerBar()
    {
        if (hungerBar != null)
        {
            hungerBar.fillAmount = currentHunger / maxHunger;
        }
    }
}
