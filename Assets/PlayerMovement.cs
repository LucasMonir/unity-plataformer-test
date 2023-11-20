using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    readonly float moveForce = 2;
    readonly float jumpForce = 5;
    bool facingRight = true;
    public GameObject platform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void HandleMovement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        rb.AddForce(horizontalAxis * moveForce * transform.right,
          ForceMode2D.Force);

        var IsWalking = rb.velocity.magnitude > 0.01f;
        animator.SetBool("IsWalking", IsWalking);

        bool right = horizontalAxis > 0 && !facingRight;
        bool left = horizontalAxis < 0 && facingRight;

        if (right)
            Flip();
        if (left)
            Flip();
    }

    private void Flip()
    {
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spawn")
        {
            System.Random rn = new System.Random();
            float distance = rn.Next(5, 8);
            float height = rn.Next(-4, 3);

            Vector3 position = transform.position;
            position.x = distance;
            position.y = height;
            Instantiate(platform, new Vector3(transform.position.x + distance, height, 0), Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
