using UnityEngine;
using UnityEngine.UI;

public class BloodLossStatus : MonoBehaviour
{
    public float maxBlood = 100f;
    private float currentBlood;
    public Image bloodBar;

    void Start()
    {
        currentBlood = maxBlood;
        UpdateBloodBar();
    }

    void Update()
    {
        // Logic to decrease blood based on player injuries
        currentBlood = Mathf.Clamp(currentBlood, 0, maxBlood);
        UpdateBloodBar();
    }

    public void ReceiveInjury(float amount)
    {
        currentBlood -= amount;
        currentBlood = Mathf.Clamp(currentBlood, 0, maxBlood);
        UpdateBloodBar();
    }

    private void UpdateBloodBar()
    {
        if (bloodBar != null)
        {
            bloodBar.fillAmount = currentBlood / maxBlood;
        }
    }
}
