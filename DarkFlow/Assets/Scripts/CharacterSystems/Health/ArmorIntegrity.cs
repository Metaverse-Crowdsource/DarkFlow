using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class ArmorIntegrity : MonoBehaviour
{
    public float maxIntegrity = 100f;
    private float currentIntegrity;

    public Image integrityBar; // UI Image to represent armor integrity visually

    void Start()
    {
        currentIntegrity = maxIntegrity;
        UpdateArmorUI(); // Initialize UI
    }

    void Update()
    {
        // Optional: Add any continuous logic, if required
    }

    public void TakeDamage(float damage)
    {
        currentIntegrity -= damage;
        currentIntegrity = Mathf.Clamp(currentIntegrity, 0, maxIntegrity);
        UpdateArmorUI();
    }

    public void RepairArmor(float repairAmount)
    {
        currentIntegrity += repairAmount;
        currentIntegrity = Mathf.Clamp(currentIntegrity, 0, maxIntegrity);
        UpdateArmorUI();
    }

    private void UpdateArmorUI()
    {
        if (integrityBar != null)
        {
            integrityBar.fillAmount = currentIntegrity / maxIntegrity;
        }
        // If using Text UI, update the text to display currentIntegrity
    }
}
