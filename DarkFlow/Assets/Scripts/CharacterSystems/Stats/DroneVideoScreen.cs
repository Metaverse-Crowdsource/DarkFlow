using UnityEngine;
using UnityEngine.UI;
public class DroneVideoScreen : MonoBehaviour
{
    public Camera droneCamera;
    public RenderTexture droneFeed;

    void Start()
    {
        droneCamera.targetTexture = droneFeed;
    }

    // Update the UI with the live feed
}
