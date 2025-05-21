using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Vector2 movement;
    private GameObject soldier;
    public CharacterBehavior characterBehavior;
    private SpriteRenderer render;
    public float moveSpeed = 20f;
    public int direction = 1;
    private bool fired = false;
    public bool firingRight;
    //public GameObject Bullet;
    public Transform child;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GetComponent<SpriteRenderer>().enabled = false;
        soldier = GameObject.Find("Soldier");
        characterBehavior = soldier.GetComponent<CharacterBehavior>();

        if (characterBehavior.facingRight)
        {
            firingRight = true;
        }
        else
        {
            firingRight = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        /*  if (Input.GetKey(KeyCode.A))
          {

              // render.flipY = true;
              //transform.localScale = new Vector3(-1, 1, 1);
              int direction = -1;
              Vector3 scale = transform.localScale;
              scale.x = Mathf.Abs(scale.x) * direction;
              transform.localScale = scale;

          }
          else if (Input.GetKey(KeyCode.D))
          {


              // render.flipY = false;
              //transform.localScale = new Vector3(1, 1, 1);
              int direction = 1;
              Vector3 scale = transform.localScale;
              scale.x = Mathf.Abs(scale.x) * direction;
              transform.localScale = scale;

          }
          if (Input.GetKey(KeyCode.Space) && !fired)
          {

              GetComponent<SpriteRenderer>().enabled = true;
              transform.Translate(Vector2.right * direction * Time.deltaTime);
              fired = true;
          }*/
        if (fired)
        {
            //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (fired)
        {
            //Instantiate(Bullet);
        }

    }
    public void InstantiateBullet()
    {
       // Instantiate(Bullet, child);
    }
    
}