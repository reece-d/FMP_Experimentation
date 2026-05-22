using UnityEngine;

/// <summary>
/// Handles top-down 2D player movement and rotation.
/// Works with Rigidbody2D for smooth physics-based motion.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Units per second

    [Header("Rotation Settings")]
    [SerializeField] private bool rotateTowardsMouse = true; // If false, rotates towards movement direction

    private Rigidbody2D rb;
    private Vector2 movementInput;

    private Animator _animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // --- INPUT HANDLING ---
        // Old Input System (works without setup)
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput = movementInput.normalized; // Prevent faster diagonal movement

        // --- ROTATION ---
        if (rotateTowardsMouse)
        {
            RotateTowardsMouse();
        }
        else if (movementInput.sqrMagnitude > 0.01f)
        {
            RotateTowardsMovement();
        }
    }

    private void FixedUpdate()
    {
        // --- MOVEMENT ---
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        SetAnimation();
    }

    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero;

        _animator.SetBool("isMoving", isMoving);
    }

    /// <summary>
    /// Rotates the player to face the mouse cursor.
    /// </summary>
    /// 

   
    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Offset for sprite facing up
        rb.rotation = angle;
    }

    /// <summary>
    /// Rotates the player to face the movement direction.
    /// </summary>
    private void RotateTowardsMovement()
    {
        float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}