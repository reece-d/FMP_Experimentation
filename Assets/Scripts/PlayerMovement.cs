
   using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this GameObject.");
        }
    }

    void Update()
    {
        // Get input from keyboard or controller
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Rotate player only if moving
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // Convert direction vector to angle
            rb.rotation = angle; // Rotate the Rigidbody2D
        }
    }
}