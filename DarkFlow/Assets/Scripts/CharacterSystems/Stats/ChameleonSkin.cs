using UnityEngine;
using UnityEngine.UI;


public class ChameleonSkinStatus : MonoBehaviour
{
    public Color currentColor;
    public Image skinStatusIcon; // UI element representing the chameleon skin status
    private bool isActive;

    // Assuming you have methods to activate or deactivate the skin
    // These could be triggered by player input or game events
    public void ActivateSkin()
    {
        isActive = true;
        UpdateSkinColor(); // Update the color when activated
    }

    public void DeactivateSkin()
    {
        isActive = false;
        UpdateSkinColor(); // Revert color when deactivated
    }

    void Update()
    {
        // Example check for state changes (can be replaced with actual game logic)
        if (Input.GetKeyDown(KeyCode.C)) // Toggle skin on pressing 'C'
        {
            if (isActive)
                DeactivateSkin();
            else
                ActivateSkin();
        }

        // Additional updates based on game logic
    }

    private void UpdateSkinColor()
    {
        if (isActive)
        {
            // Change to active color
            currentColor = GetActiveColor();
        }
        else
        {
            // Revert to default color
            currentColor = Color.white; // Assuming white is the default color
        }

        // Update UI element
        if (skinStatusIcon != null)
        {
            skinStatusIcon.color = currentColor;
        }
    }

    private Color GetActiveColor()
    {
        // Define how you determine the active color
        // This is a placeholder for your actual color logic
        return Color.green; // Example color
    }
}
