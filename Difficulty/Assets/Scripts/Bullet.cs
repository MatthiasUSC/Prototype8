using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject zone;

    private Vector2 direction;


    private void Start()
    {
        //zone.SetActive(false);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {

        //bool isReversing = Input.GetKey(KeyCode.A);
        if (Input.GetMouseButtonDown(1))
        {
            // ÇÐ»»zoneµÄ¼¤»î×´Ì¬
            zone.SetActive(!zone.activeSelf);
            if (zone.activeSelf)
            {
                //Debug.Log("Zone is now active.");
            }
            else
            {
                //Debug.Log("Zone is now inactive.");
            }
        }

        /*   if (isReversing)
           {

               isInTheCircle = true;
           }
           else
           {
               isInTheCircle = false;
           }*/
    }
 /*   public override void TimeUpdate()
    {
      
   

      *//*  Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

      
        transform.position = pos;*//*  Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

      
        transform.position = pos;*//*
    }*/
}
