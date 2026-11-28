using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Fish))]
public class FishMovement : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float directionChangeInterval = 2.5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;
    private Fish fish;
    private Vector2 moveDirection;
    private float nextDirectionChangeTime;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        fish = GetComponent<Fish>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        ChooseRandomDirection();
    }

    private void OnEnable()
    {
        nextDirectionChangeTime = Time.time + directionChangeInterval;
    }

    private void FixedUpdate()
    {
        if (Time.time >= nextDirectionChangeTime)
        {
            ChooseRandomDirection();
            nextDirectionChangeTime = Time.time + directionChangeInterval;
        }

        rigidbody2D.linearVelocity = moveDirection * fish.MoveSpeed;
        UpdateFacingDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount == 0)
        {
            return;
        }

        Vector2 normal = collision.GetContact(0).normal;
        moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
        nextDirectionChangeTime = Time.time + directionChangeInterval;
        UpdateFacingDirection();
    }

    private void ChooseRandomDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;

        if (moveDirection.sqrMagnitude < 0.01f)
        {
            moveDirection = Vector2.right;
        }
    }

    private void UpdateFacingDirection()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (moveDirection.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
