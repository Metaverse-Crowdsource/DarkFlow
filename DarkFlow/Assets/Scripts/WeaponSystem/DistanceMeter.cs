using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceMeter : MonoBehaviour
{
    private GameObject meterObject;
    private TextMeshProUGUI distanceText;
    private Camera playerCamera;
    private float offset = 50f; // Offset value to position the text to the right

    public void SetUp(GameObject prefab, Camera camera)
    {
        if (meterObject == null)
        {
            playerCamera = camera;
            meterObject = Instantiate(prefab, transform); // Use the current object as the parent
            distanceText = meterObject.GetComponent<TextMeshProUGUI>();
            distanceText.color = Color.red; // Set text color to red
        }
    }

    public void UpdateDistance(float distance, Transform enemyTransform)
    {
        if (meterObject != null)
        {
            Vector3 viewportPosition = playerCamera.WorldToViewportPoint(enemyTransform.position);
            bool isEnemyOnScreen = viewportPosition.z > 0 && viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1;

            if (isEnemyOnScreen)
            {
                Vector3 screenPos = playerCamera.WorldToScreenPoint(enemyTransform.position);
                screenPos.x += offset; // Adjust the position to the right of the enemy
                meterObject.transform.position = screenPos;
                distanceText.text = $"{distance:0.0}m";
                meterObject.SetActive(true);
            }
            else
            {
                // Optional: Handle off-screen enemies by positioning the text at the edge of the screen
                // or simply hide the text
                meterObject.SetActive(false); // Hides the text for off-screen enemies
            }
        }
    }

    public void HideDistance()
    {
        if (meterObject != null)
        {
            meterObject.SetActive(false); // Hide the text when there's no target
        }
    }

    private void Update()
    {
        if (meterObject != null)
        {
            // Ensure the meter always faces the camera
            meterObject.transform.forward = playerCamera.transform.forward;
        }
    }

    private void OnDestroy()
    {
        // Clean up the UI element when the enemy is destroyed
        if (meterObject != null)
        {
            Destroy(meterObject);
        }
    }
}
