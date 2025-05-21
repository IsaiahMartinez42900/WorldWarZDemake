using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    private AudioSource walkSound;
    private bool isGrounded = true;
    public bool facingRight = true;
    public float moveSpeed = 5f;
    public float runSpeed = 8.5f;
    public float jumpForce = 1f;
    private Animator anim;
    private SpriteRenderer render;
    public GameObject bullet;
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        walkSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            PlaywalkingSound();
            anim.SetBool("isWalking", true);
            facingRight = false;
            render.flipX = true;
        }
       
        
      else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            PlaywalkingSound();
            anim.SetBool("isWalking", true);
            facingRight = true;
            render.flipX = false;
        }
        else {
            StopwalkSound();
            anim.SetBool("isWalking", false);
        }
      if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            if (isGrounded == false)
            {
                walkSound.Stop();
            }
        }
      if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A))) {

            transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
      else if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            anim.SetBool("isRunning", true);
        }
      else
        {
            anim.SetBool("isRunning", false);
        }
      if (Input.GetKeyDown(KeyCode.Space))
        {
            fireBullet();
            anim.SetBool("isShooting", true);
            anim.SetBool("isRunning", false);
            runSpeed = 5f;
        }
      else
        {
            anim.SetBool("isShooting", false);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    private void PlaywalkingSound()
    {
        if (!walkSound.isPlaying)
        {
            walkSound.Play();
        }
        
    }

    private void fireBullet()
    {
        Instantiate(bullet, spawnPoint.position, Quaternion.identity);
    }
    private void StopwalkSound()
    {
        if (walkSound.isPlaying)
        {
            walkSound.Stop();
        }
    }
}

