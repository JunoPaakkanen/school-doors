using UnityEngine;

public class SimpleItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;      // List of item prefabs to spawn
    public float[] spawnChances;          // Array of chances for each item to spawn (in percentage)
    public float noSpawnChance = 20f;     // The chance (in percentage) that no item will spawn
    public Vector3 customRotation = new Vector3(0, 90, 0);  // Custom rotation to apply when spawning

    void Start()
    {
        // Call the spawn method when the game starts
        SpawnRandomItem();
    }

    void SpawnRandomItem()
    {
        // Ensure there are item prefabs and spawn chances
        if (itemPrefabs.Length == 0 || spawnChances.Length != itemPrefabs.Length)
        {
            Debug.LogWarning("Item prefabs and spawn chances must be assigned and have the same length.");
            return;
        }

        // Normalize the spawn chances
        float totalChance = 0f;
        foreach (float chance in spawnChances)
        {
            totalChance += chance;
        }

        // Debugging: Log the total chance
        Debug.Log("Total Spawn Chance: " + totalChance);

        // Ensure the total chance is valid (i.e., greater than 0)
        if (totalChance <= 0)
        {
            Debug.LogError("Total spawn chance is zero or negative. Cannot spawn items.");
            return;
        }

        // First, check if the no-spawn chance is greater than a random threshold
        float noSpawnThreshold = Random.Range(0f, 100f);
        if (noSpawnThreshold <= noSpawnChance)
        {
            Debug.Log("No item spawned (No spawn chance triggered).");
            return; // Exit the method early if no item is to be spawned
        }

        // Pick a random value between 0 and the total chance
        float randomValue = Random.Range(0f, totalChance);
        Debug.Log("Random Value: " + randomValue);

        // Loop through the spawn chances to find the right item to spawn
        float cumulativeChance = 0f;
        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            cumulativeChance += spawnChances[i];
            Debug.Log($"Item {i}: Cumulative Chance = {cumulativeChance}");

            // If the random value is less than or equal to the cumulative chance, spawn this item
            if (randomValue <= cumulativeChance)
            {
                // Spawn the selected item at the current position with the custom rotation
                Instantiate(itemPrefabs[i], transform.position, Quaternion.Euler(customRotation));
                Debug.Log($"Spawned Item {i}: {itemPrefabs[i].name}");
                return; // Exit the loop once an item is spawned
            }
        }
    }
}
