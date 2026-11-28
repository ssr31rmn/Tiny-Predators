using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(FishInteractionDetector))]
public class PlayerHealth : MonoBehaviour
{
    private PlayerController playerController;
    private FishInteractionDetector interactionDetector;
    private Rigidbody2D rigidbody2D;

    public bool IsAlive { get; private set; } = true;
    public event System.Action<Fish> PlayerDied;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        interactionDetector = GetComponent<FishInteractionDetector>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (interactionDetector != null)
        {
            interactionDetector.LargerFishDetected += HandleLargerFishDetected;
        }
    }

    private void OnDisable()
    {
        if (interactionDetector != null)
        {
            interactionDetector.LargerFishDetected -= HandleLargerFishDetected;
        }
    }

    private void HandleLargerFishDetected(Fish predator)
    {
        if (!IsAlive || predator == null || !predator.gameObject.activeInHierarchy)
        {
            return;
        }

        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }

        if (playerController != null)
        {
            playerController.Die();
        }

        if (rigidbody2D != null)
        {
            rigidbody2D.linearVelocity = Vector2.zero;
        }

        IsAlive = false;
        PlayerDied?.Invoke(predator);
    }
}
