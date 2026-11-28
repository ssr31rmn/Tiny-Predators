using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class FishInteractionDetector : MonoBehaviour
{
    public event System.Action<Fish> FishConsumed;

    public enum SizeRelation
    {
        None,
        PlayerCanEat,
        EqualSize,
        FishIsLarger
    }

    private PlayerController player;
    private Fish detectedFish;

    public Fish DetectedFish => detectedFish;
    public bool HasDetectedFish => detectedFish != null;
    public SizeRelation RelationToDetectedFish =>
        detectedFish == null ? SizeRelation.None : GetRelation(detectedFish.SizeLevel);

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectFish(collision.collider);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DetectFish(collision.collider);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Fish fish) && fish == detectedFish)
        {
            detectedFish = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DetectFish(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        DetectFish(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fish fish) && fish == detectedFish)
        {
            detectedFish = null;
        }
    }

    public SizeRelation GetRelation(int fishSizeLevel)
    {
        if (player == null)
        {
            player = GetComponent<PlayerController>();
        }

        if (FishSizeRules.CanEat(player.SizeLevel, fishSizeLevel))
        {
            return SizeRelation.PlayerCanEat;
        }

        if (player.SizeLevel == fishSizeLevel)
        {
            return SizeRelation.EqualSize;
        }

        return SizeRelation.FishIsLarger;
    }

    private void DetectFish(Collider2D other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            detectedFish = fish;

            if (RelationToDetectedFish == SizeRelation.PlayerCanEat && fish.TryConsume())
            {
                detectedFish = null;
                FishConsumed?.Invoke(fish);
            }
        }
    }
}
