using UnityEngine;
using UnityEngine.UI;

public class NanobotInfiltration : MonoBehaviour
{
    public Image nanobotMeter; // Assign this in the inspector

    private float infiltrationLevel = 0f; // Range 0 to 1

    void Update()
    {
        // Update the infiltration level based on game events
        // infiltrationLevel = ...

        // Update UI
        nanobotMeter.fillAmount = infiltrationLevel;
    }
}
