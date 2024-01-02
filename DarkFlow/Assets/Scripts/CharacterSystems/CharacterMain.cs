using UnityEngine;
using UnityEngine.InputSystem;



public class CharacterMain : MonoBehaviour
{
    private bool isJumping;
    private bool isWalking;
    public float movementSpeed = 5f;
    private Vector2 moveInput;




    [SerializeField] private string charName; // GameObject will NOT be player's name - this will.
    [SerializeField] private Health health; // Useless for now.

    private void Start()
    {

    }

    private void Update()
    {
        //OnMove;
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed * Time.deltaTime);

    }

    private void OnMove(InputValue value)
    {

        moveInput = value.Get<Vector2>();
        /*


        private void Update()
        {
            HandleMovement();
            Move();
        }

        private void Move(InputAction context)
        {
            if(context != null)
            {
                moveInput = context.ReadValue<Vector2>();
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

        */
    }
}
