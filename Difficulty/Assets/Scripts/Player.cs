using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : TimeControlled
{
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
        BasicMove();
    }

    private void BasicMove()
    {
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

  
