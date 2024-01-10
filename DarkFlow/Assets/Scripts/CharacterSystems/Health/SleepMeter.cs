using UnityEngine;
using UnityEngine.UI;

public class SleepMeter : MonoBehaviour
{
    public float maxSleepiness = 100f;
    private float currentSleepiness;
    public Image sleepBar;

    void Start()
    {
        currentSleepiness = maxSleepiness;
        UpdateSleepBar();
    }

    void Update()
    {
        // Increase sleepiness over time or based on player actions
        currentSleepiness = Mathf.Clamp(currentSleepiness, 0, maxSleepiness);
        UpdateSleepBar();
    }

    public void Rest(float amount)
    {
        currentSleepiness -= amount;
        currentSleepiness = Mathf.Clamp(currentSleepiness, 0, maxSleepiness);
        UpdateSleepBar();
    }

    private void UpdateSleepBar()
    {
        if (sleepBar != null)
        {
            sleepBar.fillAmount = currentSleepiness / maxSleepiness;
        }
    }
}
