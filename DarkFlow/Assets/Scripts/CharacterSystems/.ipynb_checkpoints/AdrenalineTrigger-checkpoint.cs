using UnityEngine;
using UnityEngine.UI;

public class AdrenalineTrigger : MonoBehaviour
{
    private float adrenalineLevel = 0f;
    public float adrenalineTriggerThreshold = 20f; // Threshold for adrenaline boost
    public Image adrenalineBar;
    HealthRegeneration healthScript;

    private void Start()
    {
        healthScript = GetComponent<HealthRegeneration>();
    }

    private void Update()
    {
        if (healthScript.currentHealth <= adrenalineTriggerThreshold && adrenalineLevel < 100f)
        {
            adrenalineLevel += Time.deltaTime * 50f; // Increase adrenaline
            UpdateAdrenalineBar();
        }
        else
        {
            adrenalineLevel = 0f;
            UpdateAdrenalineBar();
        }
    }

    private void UpdateAdrenalineBar()
    {
        if(adrenalineBar != null)
        {
            adrenalineBar.fillAmount = adrenalineLevel / 100f;
        }
    }
}