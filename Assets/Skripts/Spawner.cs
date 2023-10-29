using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject MyScoreCounter;
    private float startDelay = 2;
    private float repeatDelay= 2;
    private Vector3 spawnPos = new Vector3(30, 0.56f, 0.13f);
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        
    }
    void Update()
    {
        
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
    {
            Instantiate(Obstacle, spawnPos, Obstacle.transform.rotation);
            Instantiate(MyScoreCounter, spawnPos+new Vector3(1,1.5f,0), MyScoreCounter.transform.rotation);
        }
}
}
