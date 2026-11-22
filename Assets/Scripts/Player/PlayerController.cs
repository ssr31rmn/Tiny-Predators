using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        float horizontal =
            Input.GetKey(KeyCode.A) ? -1f :
            Input.GetKey(KeyCode.D) ? 1f :
            Input.GetAxisRaw("Horizontal");

        float vertical =
            Input.GetKey(KeyCode.S) ? -1f :
            Input.GetKey(KeyCode.W) ? 1f :
            Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(horizontal, vertical);

        Vector2 movement = input.sqrMagnitude > 1f
            ? input.normalized
            : input;

        if (movement.x < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x > 0f)
        {
            spriteRenderer.flipX = false;
        }

        transform.position += (Vector3)(movement * moveSpeed * Time.deltaTime);

        rigidbody2D.linearVelocity = Vector2.zero;
    }
}
