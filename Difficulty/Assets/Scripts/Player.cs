using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : TimeControlled
{
    public float moveSpeed = 5;
    public float jumpVelocity = 10;
    public GameObject bullet;
    //public TimeController timeController;

    private Vector2 pos;
    [SerializeField] bool isBulletExisting = false;
    void Start()
    {

    }



    public override void TimeUpdate()
    {
        pos = transform.position;

        pos.y += velocity.y * Time.deltaTime;
        velocity.y += TimeController.gravity * Time.deltaTime;

        if (pos.y < 1)
        {
            pos.y = 1;
            velocity.y = 0;
        }

        BasicMove();


        transform.position = pos;
    }

    private void BasicMove()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y = jumpVelocity;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!isBulletExisting)
            {
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

              
                Vector3 launchDirection = (mouseWorldPosition - transform.position).normalized;

                
                GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity);

                Bullet bulletScript = projectile.GetComponent<Bullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetDirection(launchDirection);
                }

                isBulletExisting = true;
            }
        }
    }
}

  
