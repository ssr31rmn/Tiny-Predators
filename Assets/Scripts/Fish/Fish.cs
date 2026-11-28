using UnityEngine;

public enum FishCategory
{
    SmallFish,
    MediumFish,
    Predator
}

public class Fish : MonoBehaviour
{
    [SerializeField] private FishCategory category;
    [SerializeField, Min(0)] private int sizeLevel;
    [SerializeField, Min(0)] private int scoreValue;
    [SerializeField, Min(0f)] private float moveSpeed;

    public event System.Action<Fish> Consumed;

    public bool IsConsumed { get; private set; }

    public FishCategory Category => category;
    public int SizeLevel => sizeLevel;
    public int ScoreValue => scoreValue;
    public float MoveSpeed => moveSpeed;
    public bool IsPredator => category == FishCategory.Predator;

    public bool TryConsume()
    {
        if (!gameObject.activeInHierarchy || IsConsumed)
        {
            return false;
        }

        IsConsumed = true;
        Consumed?.Invoke(this);
        gameObject.SetActive(false);

        if (Application.isPlaying)
        {
            Destroy(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        return true;
    }
}

public static class FishSizeRules
{
    public static bool CanEat(int predatorSizeLevel, int targetSizeLevel)
    {
        return predatorSizeLevel > targetSizeLevel;
    }
}
