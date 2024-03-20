using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static UnityEditor.PlayerSettings;

public class Player : TimeControlled
{
    public GameObject bullet;
    public KeyCode jump;
    public GameObject groundCheck1;
    public GameObject groundCheck2;
    public bool isGrounded = false;
    public float jumpVelocity = 10;
    public float moveSpeed;
    public Transform key;
    public bool hasKey;

    //public TimeController timeController;
    //[SerializeField] bool isBulletExisting = false;
    private Vector2 pos;

    public Queue<GameObject> bullets = new Queue<GameObject>();
    private GameObject currentBullet; // 当前场景中的projectile

    //private GameObject existingBullet;
    void Start()
    {
        
    }

    private void Update()
    {
        Spawn();
    }

    public override void TimeUpdate()
    {
        /*  if (Input.GetKey(jump) && isGrounded)
          {
              GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
              //isGrounded = false;
          }*/
        RaycastHit2D hit1 = Physics2D.Raycast(groundCheck1.transform.position, Vector3.down, 0.1f);
        if (hit1.collider != null)
        {
            if (hit1.collider.transform.tag == "Danger")
            {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
        

        // Ground check
        isGrounded = false;

        //hit1 = Physics2D.Raycast(groundCheck1.transform.position, Vector3.down, 0.1f);
        if (hit1.collider != null)
        {
            if (hit1.collider.transform.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheck2.transform.position, Vector3.down, 0.1f);
        if (hit2.collider != null)
        {
            if (hit2.collider.transform.tag == "Ground")
            {
                isGrounded = true;
            }
        }

        pos = transform.position;

            pos.y += velocity.y * Time.deltaTime;
            velocity.y += TimeController.gravity * Time.deltaTime;
        
        
     

        if (isGrounded == true)
        {
            //pos.y = transform.position.y;
            velocity.y = 0;
        }


        

        BasicMove();

        transform.position = pos;
    }

    private void BasicMove()
    {

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            velocity.y = jumpVelocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Key")
        {
            //Destroy(col.gameObject);
            hasKey = true;
        }

        if (col.tag == "Door")
        {
            if (hasKey)
            {
                // End game?
                Debug.Log("Won");
                int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextIndex);
            }
        }

        if (col.gameObject.tag == "TimeSphere")
        {
            Debug.Log("inthezone");
            isInTheCircle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TimeSphere")
        {
            isInTheCircle = false;
        }
    }

    private void Spawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 如果已经存在一个projectile，则先销毁它
            if (currentBullet != null)
            {
                Destroy(currentBullet);
            }

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - Camera.main.transform.position.z));

            //Vector3 launchDirection = (mouseWorldPosition - transform.position).normalized;

            // 创建并设置新的projectile
            currentBullet = Instantiate(bullet, mouseWorldPosition, Quaternion.identity);

            /*  Bullet bulletScript = currentBullet.GetComponent<Bullet>();
              if (bulletScript != null)
              {
                  bulletScript.SetDirection(launchDirection);
              }*/
        }

        if (Input.GetMouseButtonDown(1))
        {
            // 如果已经存在一个projectile，则先销毁它
            if (currentBullet != null)
            {
                Destroy(currentBullet);
            }
        }
    }
}


  
