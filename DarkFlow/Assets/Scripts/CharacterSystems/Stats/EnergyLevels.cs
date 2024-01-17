using UnityEngine;
using UnityEngine.UI;

public class EnergyLevels : MonoBehaviour
{
    public float maxEnergy = 100f;
    private float currentEnergy;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        // Decrease energy over time or based on actions
        // currentEnergy -= ...

        // Update UI
        // ...
    }
}
