using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    Animator animator;

    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    private bool grounded;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpForce = 4;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;

    private Vector2 velocity;
    public float timer;

    private void Awake()
    {
        timer = -1;
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Running", true);
        animator.SetBool("Jump_Key_Pressed", false);
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer = timer + Time.deltaTime;
        }
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {

            velocity.x = Mathf.Lerp(rb2D.velocity.x, speed * moveInput, walkAcceleration * Time.deltaTime);
            animator.SetBool("Running", true);
        }
        else
        {
            velocity.x = Mathf.Lerp(rb2D.velocity.x, 0, groundDeceleration * Time.deltaTime);
            animator.SetBool("Running", false);
        }

        rb2D.AddForce(velocity - rb2D.velocity);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jump_Key_Pressed", true);
            timer = 0.0f;
        }     
        
        if (timer >= 1)
        {
            animator.SetBool("Jump_Key_Pressed", false);
            timer = -1;
        }
    }
}
