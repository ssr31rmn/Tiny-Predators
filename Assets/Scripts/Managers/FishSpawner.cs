using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject smallFishPrefab;
    [SerializeField] private GameObject mediumFishPrefab;
    [SerializeField] private GameObject predatorPrefab;
    [SerializeField, Min(0)] private int smallFishWeight = 60;
    [SerializeField, Min(0)] private int mediumFishWeight = 30;
    [SerializeField, Min(0)] private int predatorWeight = 10;
    [SerializeField, Min(0)] private int initialFishCount = 8;
    [SerializeField, Min(0)] private int maximumFishCount = 16;
    [SerializeField, Min(0.1f)] private float spawnInterval = 2.5f;
    [SerializeField] private Vector2 spawnAreaMinimum = new Vector2(-8f, -4.5f);
    [SerializeField] private Vector2 spawnAreaMaximum = new Vector2(8f, 4.5f);
    [SerializeField, Min(0f)] private float minimumDistanceFromPlayer = 2f;
    [SerializeField, Min(0f)] private float minimumSeparationRadius = 0.8f;
    [SerializeField, Min(1)] private int placementAttempts = 20;

    private readonly List<Fish> spawnedFish = new List<Fish>();
    private readonly Collider2D[] nearbyColliders = new Collider2D[32];
    private PlayerController player;

    public int ActiveFishCount
    {
        get
        {
            RemoveInactiveFish();
            return spawnedFish.Count;
        }
    }

    private void Start()
    {
        if (!ValidateConfiguration())
        {
            enabled = false;
            return;
        }

        player = FindAnyObjectByType<PlayerController>();
        TrackExistingFish();

        int initialCount = Mathf.Min(initialFishCount, maximumFishCount - ActiveFishCount);
        for (int i = 0; i < initialCount; i++)
        {
            if (!TrySpawnFish())
            {
                break;
            }
        }

        StartCoroutine(SpawnRoutine());
    }

    private bool ValidateConfiguration()
    {
        if (smallFishPrefab == null || mediumFishPrefab == null || predatorPrefab == null)
        {
            Debug.LogError("FishSpawner requires Small Fish, Medium Fish, and Predator prefabs.", this);
            return false;
        }

        if (smallFishPrefab.GetComponent<Fish>() == null
            || mediumFishPrefab.GetComponent<Fish>() == null
            || predatorPrefab.GetComponent<Fish>() == null)
        {
            Debug.LogError("Every FishSpawner prefab must have a Fish component on its root.", this);
            return false;
        }

        if (spawnAreaMinimum.x >= spawnAreaMaximum.x
            || spawnAreaMinimum.y >= spawnAreaMaximum.y)
        {
            Debug.LogError("FishSpawner spawn area minimum must be below its maximum.", this);
            return false;
        }

        if (smallFishWeight + mediumFishWeight + predatorWeight <= 0)
        {
            Debug.LogError("FishSpawner needs at least one positive fish spawn weight.", this);
            return false;
        }

        if (maximumFishCount == 0)
        {
            Debug.LogError("FishSpawner maximum fish count must be greater than zero.", this);
            return false;
        }

        return true;
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(spawnInterval);
        while (true)
        {
            yield return wait;
            TrySpawnFish();
        }
    }

    private bool TrySpawnFish()
    {
        RemoveInactiveFish();
        if (spawnedFish.Count >= maximumFishCount)
        {
            return false;
        }

        GameObject prefab = ChooseFishPrefab();
        if (!TryFindSpawnPosition(out Vector2 position))
        {
            Debug.LogWarning("FishSpawner could not find a clear spawn position in the configured area.", this);
            return false;
        }

        GameObject spawnedObject = Instantiate(prefab, position, Quaternion.identity);
        Fish spawnedFishComponent = spawnedObject.GetComponent<Fish>();
        if (spawnedFishComponent == null)
        {
            Destroy(spawnedObject);
            Debug.LogError("Spawned fish prefab lost its Fish component.", this);
            return false;
        }

        spawnedFish.Add(spawnedFishComponent);
        Physics2D.SyncTransforms();
        return true;
    }

    private GameObject ChooseFishPrefab()
    {
        int totalWeight = smallFishWeight + mediumFishWeight + predatorWeight;
        int selection = Random.Range(0, totalWeight);

        if (selection < smallFishWeight)
        {
            return smallFishPrefab;
        }

        selection -= smallFishWeight;
        if (selection < mediumFishWeight)
        {
            return mediumFishPrefab;
        }

        return predatorPrefab;
    }

    private bool TryFindSpawnPosition(out Vector2 position)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(Physics2D.DefaultRaycastLayers);
        contactFilter.useTriggers = true;

        for (int attempt = 0; attempt < placementAttempts; attempt++)
        {
            position = new Vector2(
                Random.Range(spawnAreaMinimum.x, spawnAreaMaximum.x),
                Random.Range(spawnAreaMinimum.y, spawnAreaMaximum.y));

            if (player != null
                && player.IsAlive
                && ((Vector2)player.transform.position - position).sqrMagnitude
                    < minimumDistanceFromPlayer * minimumDistanceFromPlayer)
            {
                continue;
            }

            Physics2D.SyncTransforms();
            int overlapCount = Physics2D.OverlapCircle(
                position,
                minimumSeparationRadius,
                contactFilter,
                nearbyColliders);
            if (overlapCount == 0)
            {
                return true;
            }
        }

        position = Vector2.zero;
        return false;
    }

    private void TrackExistingFish()
    {
        Fish[] existingFish = FindObjectsByType<Fish>();
        foreach (Fish fish in existingFish)
        {
            if (fish.gameObject.scene == gameObject.scene)
            {
                spawnedFish.Add(fish);
            }
        }
    }

    private void RemoveInactiveFish()
    {
        spawnedFish.RemoveAll(fish => fish == null || !fish.gameObject.activeInHierarchy);
    }
}
