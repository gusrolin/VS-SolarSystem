using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgainGame : MonoBehaviour
{
    public void PlayAgainGame()
    {
        SceneManager.LoadScene(1); // Loads the scene with index 1
    }
}
