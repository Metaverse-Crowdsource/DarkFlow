using UnityEngine;
using UnityEngine.UI;


public class RegenerativeTissueStatus : MonoBehaviour
{
    public float regenerationLevel; // Current regeneration level
    public float maxRegeneration = 100f; // Maximum possible regeneration level
    public float regenerationRate = 5f; // Rate at which tissue regenerates per second

    void Update()
    {
        // Example logic to increase regeneration level
        if (regenerationLevel < maxRegeneration)
        {
            regenerationLevel += Time.deltaTime * regenerationRate;
            regenerationLevel = Mathf.Min(regenerationLevel, maxRegeneration); // Cap the regeneration level
        }

        // Update UI or other game elements based on regenerationLevel
    }
}
