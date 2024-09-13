using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{

    public static GameManagement manager;

    public int currentScore = 0; //Store the current score here

    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
            Debug.Log("GameManagement initialized");
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    // Method to add score
    public void AddScore(int points)
    {
        currentScore += points;
        Debug.Log("Current Score: " + currentScore);

    }

    // Method to reset score (optional, if you want to reset at the beginning of a game)
    public void ResetScore()
    {
        currentScore = 0;
    }

}
