using UnityEngine;
using UnityEngine.UI;

public class RadiationMeter : MonoBehaviour
{
    public float maxRadiation = 100f;
    private float currentRadiation = 0f;
    public Image radiationBar; // Assign this in the Inspector

    void Update()
    {
        // Update logic, if any, goes here
    }

    public void IncreaseRadiation(float amount)
    {
        currentRadiation += amount;
        currentRadiation = Mathf.Clamp(currentRadiation, 0, maxRadiation);
        UpdateRadiationUI();
    }

    public void DecreaseRadiation(float amount)
    {
        currentRadiation -= amount;
        currentRadiation = Mathf.Clamp(currentRadiation, 0, maxRadiation);
        UpdateRadiationUI();
    }

    private void UpdateRadiationUI()
    {
        radiationBar.fillAmount = currentRadiation / maxRadiation;
    }
}

