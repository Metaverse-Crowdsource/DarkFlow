using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBodyRotate : MonoBehaviour
{
    public float rotationSensitivity = 100f;
    private PlayerInput playerInput;

    void Awake()
    {
        // Get the PlayerInput component from the GameObject
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Read the mouse delta using the new input system
        float mouseX = playerInput.CameraLook.MouseX.ReadValue<float>() * rotationSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
