using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    private TextMeshProUGUI scoreText;  // Use TextMeshProUGUI instead of Text

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();  // Get the TextMeshProUGUI component
    }

    // Update is called once per frame
    void Update()
    {
        // Fetch the current score from GameManagement and update the text
        scoreText.text = "Score: " + GameManagement.manager.currentScore;
    }
}
