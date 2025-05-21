using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    public GameObject Player;
    public float speed = 3.5f;
    Vector2 position;
    private bool stopMoving = false;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = objectToFollow.position + offset;
        if (!stopMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stopMoving = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isTouching", true);

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("bullet hit: " + collision.gameObject.name);
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stopMoving = false;
            anim.SetBool("isWalking", true);
            anim.SetBool("isTouching", false);
        }
        
    }


}
