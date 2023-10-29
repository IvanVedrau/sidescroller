using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private Vector3 StartPosition;

    private float Width;
    public float Speed = 6.0f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartPosition = transform.position;

        Width = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            
        transform.position += Vector3.left * 5.0f * Time.deltaTime;

        if (transform.position.x < StartPosition.x - Width)
        {
            transform.position = StartPosition;
        }
        }
    }
}
