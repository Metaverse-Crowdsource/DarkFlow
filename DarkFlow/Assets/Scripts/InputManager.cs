using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.MovementActions onFoot;

    private PlayerMotor motor;

    void Awake()
    {
        // Instantiate the PlayerInput class
        playerInput = new PlayerInput();
        // Get the Movement action map
        onFoot = playerInput.Movement;

        // Get the PlayerMotor component attached to the GameObject
        motor = GetComponent<PlayerMotor>();
    }

    void FixedUpdate()
{
    // Read the value from our movement actions as floats
    float forwardInput = onFoot.Forward.ReadValue<float>();
    float rightInput = onFoot.Right.ReadValue<float>();
    
    // Construct a Vector2 from the forward and right input values
    Vector2 movementInput = new Vector2(rightInput, forwardInput);
    
    // Tell the player motor to move using the value from our movement action.
    motor.ProcessMove(movementInput);
}


    private void OnEnable()
    {
        // Enable the Movement action map when the GameObject is enabled
        onFoot.Enable();
    }

    private void OnDisable()
    {
        // Disable the Movement action map when the GameObject is disabled
        onFoot.Disable();
    }
}
