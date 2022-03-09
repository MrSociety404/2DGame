using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;
    public bool isClimbing;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;

    float horizontalMovement;
    float verticalMovement;

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed ;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement * Time.deltaTime, verticalMovement * Time.deltaTime);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if (!isClimbing)
        {
            // Horizontal move
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if(isJumping == true)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        } 
        else
        {
            // Vetical move
            Vector3 targetVelocity = new Vector2(rb.velocity.x, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

}
