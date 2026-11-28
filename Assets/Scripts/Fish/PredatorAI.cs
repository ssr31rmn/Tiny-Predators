using UnityEngine;

[RequireComponent(typeof(Fish))]
[RequireComponent(typeof(FishMovement))]
public class PredatorAI : MonoBehaviour
{
    [SerializeField, Min(0f)] private float detectionRadius = 6f;
    [SerializeField, Min(0f)] private float chaseSpeed = 3.5f;
    [SerializeField, Min(0.05f)] private float targetCheckInterval = 0.25f;

    private Fish fish;
    private FishMovement fishMovement;
    private PlayerController target;
    private float nextTargetCheckTime;
    private readonly Collider2D[] nearbyColliders = new Collider2D[32];

    public PlayerController CurrentTarget => target;
    public bool IsChasing => target != null;

    private void Awake()
    {
        fish = GetComponent<Fish>();
        fishMovement = GetComponent<FishMovement>();
    }

    private void OnEnable()
    {
        nextTargetCheckTime = Time.time;
    }

    private void OnDisable()
    {
        if (fishMovement != null)
        {
            fishMovement.ClearMovementOverride();
        }

        target = null;
    }

    private void FixedUpdate()
    {
        if (fish.Category != FishCategory.Predator)
        {
            target = null;
            fishMovement.ClearMovementOverride();
            return;
        }

        if (target != null && !IsValidTarget(target))
        {
            target = null;
        }

        if (Time.time >= nextTargetCheckTime)
        {
            target = FindNearestValidTarget();
            nextTargetCheckTime = Time.time + targetCheckInterval;
        }

        if (target == null)
        {
            fishMovement.ClearMovementOverride();
            return;
        }

        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        if (direction.sqrMagnitude < 0.0001f)
        {
            fishMovement.ClearMovementOverride();
            return;
        }

        fishMovement.SetMovementOverride(direction, chaseSpeed);
    }

    private PlayerController FindNearestValidTarget()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(Physics2D.DefaultRaycastLayers);
        contactFilter.useTriggers = true;
        int colliderCount = Physics2D.OverlapCircle(
            transform.position,
            detectionRadius,
            contactFilter,
            nearbyColliders);

        PlayerController nearestTarget = null;
        float nearestDistanceSquared = float.PositiveInfinity;

        for (int i = 0; i < colliderCount; i++)
        {
            PlayerController candidate =
                nearbyColliders[i].GetComponentInParent<PlayerController>();
            if (candidate == null || !IsValidTarget(candidate))
            {
                continue;
            }

            float distanceSquared =
                ((Vector2)candidate.transform.position - (Vector2)transform.position).sqrMagnitude;
            if (distanceSquared < nearestDistanceSquared)
            {
                nearestTarget = candidate;
                nearestDistanceSquared = distanceSquared;
            }
        }

        return nearestTarget;
    }

    private bool IsValidTarget(PlayerController candidate)
    {
        if (candidate == null || !candidate.IsAlive)
        {
            return false;
        }

        float detectionRadiusSquared = detectionRadius * detectionRadius;
        float distanceSquared =
            ((Vector2)candidate.transform.position - (Vector2)transform.position).sqrMagnitude;

        return distanceSquared <= detectionRadiusSquared
            && FishSizeRules.CanEat(fish.SizeLevel, candidate.SizeLevel);
    }
}
