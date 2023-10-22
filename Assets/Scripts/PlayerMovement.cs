using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Movement speed

    private Rigidbody2D rb;
    private Animator animator;
    private float facingDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        // Get input axes for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement to the Rigidbody
        rb.velocity = movement.normalized * moveSpeed;

        // Set the "IsWalking" parameter based on whether the player is moving
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("IsWalking", isWalking);

        // Set the parameters in the Animator to control the Blend Tree
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);

        if (horizontalInput < 0)
        {
            facingDirection = 0.25f; // Facing left
        }
        else if (horizontalInput > 0)
        {
            facingDirection = 0.5f; // Facing right
        }
        else if (verticalInput > 0)
        {
            facingDirection = 0.75f; // Facing back
        }
        else if (verticalInput < 0)
        {
            facingDirection = 0.0f; // Facing forward
        }

        // Update the Animator parameter
        animator.SetFloat("FacingDirection", facingDirection);

        // Debug output for troubleshooting
        Debug.Log("FacingDirection: " + facingDirection);
    }
}





