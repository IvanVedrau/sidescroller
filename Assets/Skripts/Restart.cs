using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject gameOverUI;
    
    // Start is called before the first frame update
    public void RestartLevel()
    {
        Time.timeScale = 1;
        GameManager.health = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreManager.scoreCount = 0;
    }

    
}
