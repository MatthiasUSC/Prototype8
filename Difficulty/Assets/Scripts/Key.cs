using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Key : TimeControlled
{
    // Start is called before the first frame update
    public bool isGrounded;
    private Vector2 pos;
    public GameObject groundCheck1;
    public bool ifTogather = false;
    public Player player;

    private void Update()
    {
        if (player.isInTheCircle && isInTheCircle)
        {
            ifTogather = false;
            player.hasKey = false;
        }
    }
    public override void TimeUpdate()
    {
        if (ifTogather)
        {
            transform.position = player.key.position;
        }
        if (!ifTogather)
        {
            // Ground check
            isGrounded = false;

            RaycastHit2D hit1 = Physics2D.Raycast(groundCheck1.transform.position, Vector3.down, 0.1f);
            if (hit1.collider != null)
            {
                if (hit1.collider.transform.tag == "Ground" || hit1.collider.transform.tag == "Danger")
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


            transform.position = pos;
        }

      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ifTogather = true;
        }

      

        if (collision.gameObject.tag == "TimeSphere")
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





}
