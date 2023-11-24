using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Assign this to the transform that should rotate with mouse movement.

    private PlayerInput playerInput;
    private float xRotation = 0f;

    void Awake()
    {
        playerInput = new PlayerInput();
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void Update()
    {
        // Force the cursor to stay locked and hidden every frame
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Get the mouse delta for each axis separately. Multiply by sensitivity and the time between frames.
        float mouseX = playerInput.CameraLook.MouseX.ReadValue<float>() * mouseSensitivity * Time.deltaTime;
        float mouseY = playerInput.CameraLook.MouseY.ReadValue<float>() * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp rotation to prevent flipping.

        // Apply rotation. Rotate around the y-axis for mouseX and x-axis for mouseY.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

}
