using UnityEngine;

[RequireComponent(typeof(FishInteractionDetector))]
public class ScoreManager : MonoBehaviour
{
    private FishInteractionDetector interactionDetector;
    private int currentScore;

    public int CurrentScore => currentScore;
    public event System.Action<int> ScoreChanged;

    private void Awake()
    {
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

    public void AddScore(int amount)
    {
        if (amount < 0)
        {
            return;
        }

        if (amount == 0)
        {
            return;
        }

        currentScore += amount;
        ScoreChanged?.Invoke(currentScore);
    }

    public void ResetScore()
    {
        if (currentScore == 0)
        {
            return;
        }

        currentScore = 0;
        ScoreChanged?.Invoke(currentScore);
    }

    private void HandleFishConsumed(Fish fish)
    {
        if (fish == null || !fish.IsConsumed)
        {
            return;
        }

        AddScore(fish.ScoreValue);
    }
}
