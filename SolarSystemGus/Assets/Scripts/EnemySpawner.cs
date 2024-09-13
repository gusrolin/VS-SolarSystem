using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to spawn
    public Transform spawnPoint;    // The point where enemies will spawn
    public float spawnInterval = 2f; // Time between spawns (in seconds)

    // Movement variables
    public float moveSpeed = 2f;  // Speed of vertical movement
    public float moveRange = 2f;  // How far up and down the spawner moves

    private Vector3 initialPosition;  // The initial position of the spawner

    private void Start()
    {
        // Store the initial position of the spawner
        initialPosition = spawnPoint.position;

        // Start the spawning coroutine
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        // Move the spawn point up and down using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        spawnPoint.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    private IEnumerator SpawnEnemies()
    {
        // Infinite loop to spawn enemies at regular intervals
        while (true)
        {
            // Instantiate an enemy at the spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
