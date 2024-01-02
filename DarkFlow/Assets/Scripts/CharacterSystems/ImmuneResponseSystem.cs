using UnityEngine;
using UnityEngine.UI;

public class ImmuneResponseSystem : MonoBehaviour
{
    public float maxImmuneStrength = 100f;
    private float currentImmuneStrength;
    public Image immuneBar;

    void Start()
    {
        currentImmuneStrength = maxImmuneStrength;
        UpdateImmuneBar();
    }

    void Update()
    {
        // Logic to adjust immune strength based on exposure to pathogens
        currentImmuneStrength = Mathf.Clamp(currentImmuneStrength, 0, maxImmuneStrength);
        UpdateImmuneBar();
    }

    public void StrengthenImmunity(float amount)
    {
        currentImmuneStrength += amount;
        currentImmuneStrength = Mathf.Clamp(currentImmuneStrength, 0, maxImmuneStrength);
        UpdateImmuneBar();
    }

    private void UpdateImmuneBar()
    {
        if (immuneBar != null)
        {
            immuneBar.fillAmount = currentImmuneStrength / maxImmuneStrength;
        }
    }
}
