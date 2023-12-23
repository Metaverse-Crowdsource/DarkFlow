using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]

public class CharacterMain : MonoBehaviour
{
    private CharacterController characterController;
    private bool isJumping;
    private bool isWalking;
    public float movementSpeed = 5f;
    private Vector2 moveInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
    }
    private void Movement(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            // Clear the move input value when the input is released
            moveInput = Vector2.zero;
        }

    }

    private void HandleMovement()
    {
        // Calculate movement direction based on input
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        // Check if the player is walking
        isWalking = moveDirection.magnitude > 0;

        // Move the character using the CharacterController
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);

    }


}
