using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;  // Speed at which the enemy follows the player
    public float stopDistance = 0.5f; // How close the enemy needs to get before stopping

    private Transform player;  // Reference to the player's transform
    private Rigidbody2D rb;

    void Start()
    {
        // Automatically find the player by tag
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            // Calculate direction and move towards player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Pass the player GameObject to the KillPlayer method
            KillPlayer(collision.gameObject);
        }
    }

    void KillPlayer(GameObject player)
    {
        // Handle player "death" logic here
        Debug.Log("Player Killed");
        // Destroy the player
        Destroy(player);

        SceneManager.LoadScene(3); // Loads the scene with index 3
    }
}
