using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(FishInteractionDetector))]
public class PlayerGrowth : MonoBehaviour
{
    [SerializeField, Min(1)] private int growthPointsPerLevel = 3;
    [SerializeField, Min(1)] private int maximumSizeLevel = 5;

    private PlayerController player;
    private FishInteractionDetector interactionDetector;
    private int growthPoints;

    public int GrowthPoints => growthPoints;
    public int GrowthPointsPerLevel => growthPointsPerLevel;
    public int MaximumSizeLevel => maximumSizeLevel;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        interactionDetector = GetComponent<FishInteractionDetector>();
    }

    private void OnEnable()
    {
        if (interactionDetector != null)
        {
            interactionDetector.FishConsumed += HandleFishConsumed;
        }
    }

    private void OnDisable()
    {
        if (interactionDetector != null)
        {
            interactionDetector.FishConsumed -= HandleFishConsumed;
        }
    }

    public bool AddGrowth(int contribution)
    {
        if (player == null)
        {
            player = GetComponent<PlayerController>();
        }

        if (player == null)
        {
            return false;
        }

        if (contribution < 1 || player.SizeLevel >= maximumSizeLevel)
        {
            return false;
        }

        growthPoints += contribution;

        if (growthPoints >= growthPointsPerLevel)
        {
            growthPoints -= growthPointsPerLevel;
            player.IncreaseSizeLevel();

            if (player.SizeLevel > maximumSizeLevel)
            {
                growthPoints = 0;
            }

            return true;
        }

        return false;
    }

    private void HandleFishConsumed(Fish fish)
    {
        AddGrowth(fish.SizeLevel);
    }
}
