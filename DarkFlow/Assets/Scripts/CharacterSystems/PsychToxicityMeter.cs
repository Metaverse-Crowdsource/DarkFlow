using UnityEngine;
using UnityEngine.UI;

public class PsychToxicityMeter : MonoBehaviour
{
    public float maxPsychToxicity = 100f;
    private float currentPsychToxicity = 0f;
    public Image psychToxicityBar; // Assign this in the Inspector

    void Update()
    {
        // Update logic, if any, goes here
    }

    public void IncreaseToxicity(float amount)
    {
        currentPsychToxicity += amount;
        currentPsychToxicity = Mathf.Clamp(currentPsychToxicity, 0, maxPsychToxicity);
        UpdateToxicityUI();
    }

    public void DecreaseToxicity(float amount)
    {
        currentPsychToxicity -= amount;
        currentPsychToxicity = Mathf.Clamp(currentPsychToxicity, 0, maxPsychToxicity);
        UpdateToxicityUI();
    }

    private void UpdateToxicityUI()
    {
        psychToxicityBar.fillAmount = currentPsychToxicity / maxPsychToxicity;
    }
}
