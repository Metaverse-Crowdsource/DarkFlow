using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public StatBase nanobotInfiltration;
    public StatBase energyLevels;
    public StatBase cyberjammerStatus;
    // Add all other stats

    void UpdateUI()
    {
        // Update the UI elements based on the stats
        // For example, update bars, change colors, show/hide icons, etc.
    }

    void Start()
    {
        // Initialize your stats, if necessary
        // Example: Set initial energy levels, check if Cyberjammer is active, etc.
    }

    void Update()
    {
        // Here you would typically call UpdateUI to refresh the stats on the screen
        UpdateUI();
    }
}
