using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Search;
using UnityEngine;
using static TimeController;

public class TimeControlled : MonoBehaviour
{
    public Vector2 velocity;
    public bool isInTheCircle = false;

    public RecordedData[] recordedData;
    public int recordCount = 0;
    public int recordIndex = 0;
    private int recordMax = 100000;


    void Awake()
    {
        recordedData = new RecordedData[recordMax];
    }
    public virtual void TimeUpdate()
    {
        
    }

 /*   private void OnTriggerEnter2D(Collider2D collision)
    {
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
    }*/


    private void Update()
    {
        //TimeUpdate();

        
    }

    public void RecordState()
    {
        
        
        RecordedData data = new RecordedData();
        data.pos = transform.position;
        data.vel = velocity;
        recordedData[recordIndex] = data;

        recordCount++;
        recordIndex = recordCount;
    }

   

 


    public void StepBack()
    {
        if(recordIndex > 0)
        {
            recordIndex--;
            RecordedData data = recordedData[recordIndex];
            transform.position = data.pos;
            velocity = data.vel;
        }
        
          
        
      
    }
}
