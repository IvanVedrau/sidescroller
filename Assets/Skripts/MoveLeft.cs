using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{ 
    public float Speed = 5.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

   
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) 
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("ScoreTrigger"))
        {
            Destroy(gameObject);
        }

    }
}
