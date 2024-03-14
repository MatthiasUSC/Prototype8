using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : TimeControlled
{
    public float speed;

    private Vector2 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {

        bool isReversing = Input.GetKey(KeyCode.A);
        if (isReversing)
        {
            
            isInTheCircle = true;
        }
        else
        {
            isInTheCircle = false;
        }
    }
    public override void TimeUpdate()
    {
      
   

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

      
        transform.position = pos;
    }
}
