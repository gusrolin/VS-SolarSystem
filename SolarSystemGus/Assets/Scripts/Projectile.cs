using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;

    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check if the projectile collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Debug log to check if the manager reference is available
            Debug.Log("Checking GameManagement manager...");


            if (GameManagement.manager != null)
            {
                GameManagement.manager.AddScore(1);  // Add 1 point when an enemy is hit
                Debug.Log("Score added!");  // Check if the score was added
            }
            else
            {
                Debug.LogWarning("GameManagement manager is null!");  // This should not happen
            }

            // Destroy the enemy GameObject
            Destroy(collision.gameObject);
            
            Debug.Log("Enemy Killed");

            
        }



        this.destroyed.Invoke();
        Destroy(this.gameObject);
        
    }


}
