using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f; // Adjust this value for walking speed
    public float runSpeed = 6f; // Adjust this value for running speed

    private float movementSpeed; // Current movement speed (walk or run)
    public float RotationSpeed = 100;
    private CharacterController characterController;
    private Vector3 currentDirection;
    public Transform PlayerMesh;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementSpeed = walkSpeed; // Start with walking speed
        currentDirection = transform.forward;
    }

    private void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Apply movement speed based on whether the player is walking or running
        Vector3 velocity = moveDirection.normalized * movementSpeed;


        // Rotate the player based on horizontal input
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            float targetRotation = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            Quaternion toRotate = Quaternion.Euler(0f, targetRotation, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, RotationSpeed * Time.deltaTime);
        }

        // Move the character controller
        characterController.Move(velocity * Time.deltaTime);

        // Check if the player is running and adjust movement speed accordingly
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        //// Rotate the player to face the next direction midpoint
        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
        //    currentDirection = moveDirection;
        //}

        //// Check for forward input and move towards the midpoint between current and next direction
        //if (Input.GetKey(KeyCode.W) && moveDirection != Vector3.zero)
        //{
        //    Vector3 nextDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        //    Vector3 targetDirection = (currentDirection + nextDirection).normalized;
        //    transform.rotation = Quaternion.LookRotation(targetDirection);
        //    characterController.Move(targetDirection * movementSpeed * Time.deltaTime);
        //}
    }
}
