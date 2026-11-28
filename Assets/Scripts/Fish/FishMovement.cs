using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Fish))]
public class FishMovement : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float directionChangeInterval = 2.5f;
    [SerializeField, Min(0f)] private float fleeDetectionRadius = 3.5f;
    [SerializeField, Min(0f)] private float fleeSpeed = 2.5f;
    [SerializeField, Min(0.05f)] private float threatCheckInterval = 0.25f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D rigidbody2D;
    private Fish fish;
    private Vector2 moveDirection;
    private Vector2 fleeDirection;
    private Vector2 overrideDirection;
    private float overrideSpeed;
    private float nextDirectionChangeTime;
    private float nextThreatCheckTime;
    private bool isFleeing;
    private bool hasMovementOverride;
    private readonly Collider2D[] nearbyColliders = new Collider2D[32];

    public bool IsFleeing => isFleeing;
    public bool HasMovementOverride => hasMovementOverride;

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
        nextThreatCheckTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (fish.Category == FishCategory.SmallFish && Time.time >= nextThreatCheckTime)
        {
            RefreshThreatResponse();
            nextThreatCheckTime = Time.time + threatCheckInterval;
        }

        if (!isFleeing && Time.time >= nextDirectionChangeTime)
        {
            ChooseRandomDirection();
            nextDirectionChangeTime = Time.time + directionChangeInterval;
        }

        Vector2 direction = isFleeing
            ? fleeDirection
            : hasMovementOverride ? overrideDirection : moveDirection;
        float speed = isFleeing
            ? fleeSpeed
            : hasMovementOverride ? overrideSpeed : fish.MoveSpeed;
        rigidbody2D.linearVelocity = direction * speed;
        UpdateFacingDirection(direction);
    }

    public void SetMovementOverride(Vector2 direction, float speed)
    {
        if (direction.sqrMagnitude < 0.0001f || speed <= 0f)
        {
            ClearMovementOverride();
            return;
        }

        overrideDirection = direction.normalized;
        overrideSpeed = speed;
        hasMovementOverride = true;
    }

    public void ClearMovementOverride()
    {
        hasMovementOverride = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contactCount == 0)
        {
            return;
        }

        Vector2 normal = collision.GetContact(0).normal;
        if (isFleeing)
        {
            fleeDirection = Vector2.Reflect(fleeDirection, normal).normalized;
        }
        else if (hasMovementOverride)
        {
            overrideDirection = Vector2.Reflect(overrideDirection, normal).normalized;
        }
        else
        {
            moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
        }

        nextDirectionChangeTime = Time.time + directionChangeInterval;
        Vector2 direction = isFleeing
            ? fleeDirection
            : hasMovementOverride ? overrideDirection : moveDirection;
        UpdateFacingDirection(direction);
    }

    private void RefreshThreatResponse()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(Physics2D.DefaultRaycastLayers);
        contactFilter.useTriggers = true;
        int colliderCount = Physics2D.OverlapCircle(
            transform.position,
            fleeDetectionRadius,
            contactFilter,
            nearbyColliders);

        float nearestThreatDistanceSquared = float.PositiveInfinity;
        Vector2 nearestThreatPosition = Vector2.zero;

        for (int i = 0; i < colliderCount; i++)
        {
            Collider2D nearbyCollider = nearbyColliders[i];
            PlayerController nearbyPlayer = nearbyCollider.GetComponentInParent<PlayerController>();

            if (nearbyPlayer != null
                && nearbyPlayer.IsAlive
                && FishSizeRules.CanEat(nearbyPlayer.SizeLevel, fish.SizeLevel))
            {
                UpdateNearestThreat(
                    nearbyPlayer.transform.position,
                    ref nearestThreatDistanceSquared,
                    ref nearestThreatPosition);
                continue;
            }

            Fish nearbyFish = nearbyCollider.GetComponentInParent<Fish>();
            if (nearbyFish != null
                && nearbyFish != fish
                && FishSizeRules.CanEat(nearbyFish.SizeLevel, fish.SizeLevel))
            {
                UpdateNearestThreat(
                    nearbyFish.transform.position,
                    ref nearestThreatDistanceSquared,
                    ref nearestThreatPosition);
            }
        }

        isFleeing = !float.IsPositiveInfinity(nearestThreatDistanceSquared);
        if (isFleeing)
        {
            fleeDirection = ((Vector2)transform.position - nearestThreatPosition).normalized;
            if (fleeDirection.sqrMagnitude < 0.01f)
            {
                fleeDirection = Random.insideUnitCircle.normalized;
            }
        }
    }

    private void UpdateNearestThreat(
        Vector2 threatPosition,
        ref float nearestDistanceSquared,
        ref Vector2 nearestPosition)
    {
        float distanceSquared = ((Vector2)transform.position - threatPosition).sqrMagnitude;
        if (distanceSquared < nearestDistanceSquared)
        {
            nearestDistanceSquared = distanceSquared;
            nearestPosition = threatPosition;
        }
    }

    private void ChooseRandomDirection()
    {
        moveDirection = Random.insideUnitCircle.normalized;

        if (moveDirection.sqrMagnitude < 0.01f)
        {
            moveDirection = Vector2.right;
        }
    }

    private void UpdateFacingDirection(Vector2 direction)
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (direction.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
