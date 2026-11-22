using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));

        Vector2 movement = input.sqrMagnitude > 1f
            ? input.normalized
            : input;

        Vector2 nextPosition = rigidbody2D.position +
            movement * moveSpeed * Time.fixedDeltaTime;

        rigidbody2D.MovePosition(nextPosition);
    }
}
