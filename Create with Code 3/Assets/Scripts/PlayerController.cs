using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool gameOver = false;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public ParticleSystem particleExplosion;
    public ParticleSystem particleDirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool playerReachedStartPoint = false;


    private Animator animator;
    private Rigidbody playerRB;
    private int timesJumped = 0;
    private AudioSource playerAudio;
    private float startAnimatonSpeed = 3f;
    private Vector3 startAnimationPos = new Vector3(-10, 0, -2);
    private Vector3 startPosition = new Vector3(0,0,-2);
    private float distanceForStart;
    private float startTime;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        distanceForStart = Vector3.Distance(startAnimationPos, startPosition);
        startTime = Time.time;
    }

    void Update()
    {
        if (!playerReachedStartPoint)
        {
            float distCovered = (Time.time - startTime) * startAnimatonSpeed;
            float fractionOfJourney = distCovered / distanceForStart;
            transform.position = Vector3.Lerp(startAnimationPos, startPosition, fractionOfJourney);
            if (transform.position == startPosition)
            {
                playerReachedStartPoint = true;
                print("Game started");
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && timesJumped < 2 && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            particleDirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            if (timesJumped == 1)
            {
                animator.SetTrigger("Jump_trig");
                animator.ResetTrigger("Jump_trig");
            }
            else
                animator.SetTrigger("Jump_trig");
            timesJumped++;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            timesJumped = 0;
            particleDirt.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 6f, ForceMode.Impulse);
            gameOver = true;
            print("Game over!");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            particleExplosion.Play();
            particleDirt.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
