using UnityEngine;
using UnityEngine.UI;

public class CyberjammerStatus : MonoBehaviour
{
    private bool isJamming = false;

    void Update()
    {
        // Example: Toggle jamming on key press
        if (Input.GetKeyDown(KeyCode.J)) // Assuming 'J' key to toggle
        {
            isJamming = !isJamming;
            UpdateJammingState();
        }
    }

    private void UpdateJammingState()
    {
        if (isJamming)
        {
            // Code to activate jamming effects
        }
        else
        {
            // Code to deactivate jamming effects
        }
    }
}
