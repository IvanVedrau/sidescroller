using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb = null;//for this gameobject rigid body component
    private Animator playerAnim;
    private AudioSource playerAudio;
    

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float JumpForce = 10;
    public float gravityModifier;
    public bool isonground = true;
    public bool gameOver;
   

    void Start()
    {
        Physics.gravity *= gravityModifier;

         rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonground && !gameOver )
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isonground = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);


        }
        
    }
    

private void OnCollisionEnter(Collision collision)
    {
        isonground = true;
        if(collision.gameObject.CompareTag("Ground"))
        {
            isonground = true;
            dirtParticle.Play();  
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.health -= 1;
        }
        if (GameManager.health == 0) 
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Score!!!");
            ScoreManager.scoreCount += 1;





        }
    }

}



