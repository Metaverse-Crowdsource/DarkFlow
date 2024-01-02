using UnityEngine;
using UnityEngine.UI;

public class ThirstMeter : MonoBehaviour
{
    public float maxThirst = 100f;
    private float currentThirst;
    public Image thirstBar;

    void Start()
    {
        currentThirst = maxThirst;
        UpdateThirstBar();
    }

    void Update()
    {
        // Decrease thirst over time or based on player actions
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
        UpdateThirstBar();
    }

    public void ConsumeWater(float amount)
    {
        currentThirst += amount;
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
        UpdateThirstBar();
    }

    private void UpdateThirstBar()
    {
        if (thirstBar != null)
        {
            thirstBar.fillAmount = currentThirst / maxThirst;
        }
    }
}

