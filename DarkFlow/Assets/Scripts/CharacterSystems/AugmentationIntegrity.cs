using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class AugmentationIntegrity : MonoBehaviour
{
    public float maxIntegrity = 100f;
    private float currentIntegrity;
    
    public Image integrityBar; // UI element to represent integrity visually

    void Start()
    {
        currentIntegrity = maxIntegrity;
        UpdateAugmentationUI(); // Initialize UI
    }

    void Update()
    {
        // Optional: Add any continuous logic, if required
    }

    public void TakeDamage(float damage)
    {
        currentIntegrity -= damage;
        currentIntegrity = Mathf.Clamp(currentIntegrity, 0, maxIntegrity);
        CheckForMalfunctions();
        UpdateAugmentationUI();
    }

    public void RepairAugmentation(float repairAmount)
    {
        currentIntegrity += repairAmount;
        currentIntegrity = Mathf.Clamp(currentIntegrity, 0, maxIntegrity);
        UpdateAugmentationUI();
    }

    private void CheckForMalfunctions()
    {
        if (currentIntegrity <= 0)
        {
            // Handle augmentation malfunction, e.g., disable certain abilities
        }
    }

    private void UpdateAugmentationUI()
    {
        if (integrityBar != null)
        {
            integrityBar.fillAmount = currentIntegrity / maxIntegrity;
        }
    }
}

