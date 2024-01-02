using UnityEngine;
using UnityEngine.UI;

public class BioToxicityMeter : MonoBehaviour
{
    public float maxBioToxicity = 100f;
    private float currentBioToxicity = 0f;
    public Image bioToxicityBar; // Assign this in the Inspector

    void Update()
    {
        // Update logic, if any, goes here
    }

    public void IncreaseToxicity(float amount)
    {
        currentBioToxicity += amount;
        currentBioToxicity = Mathf.Clamp(currentBioToxicity, 0, maxBioToxicity);
        UpdateToxicityUI();
    }

    public void DecreaseToxicity(float amount)
    {
        currentBioToxicity -= amount;
        currentBioToxicity = Mathf.Clamp(currentBioToxicity, 0, maxBioToxicity);
        UpdateToxicityUI();
    }

    private void UpdateToxicityUI()
    {
        bioToxicityBar.fillAmount = currentBioToxicity / maxBioToxicity;
    }
}
