using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static float gravity = -100;
    public struct RecordedData
    {
        public Vector2 pos;
        public Vector2 vel;

    }

    /*public RecordedData[,] recordedData;
    int recordMax = 100000;
    int recordCount;
    int recordIndex;*/
    public bool wasSteepingBack = false;


    public TimeControlled[] timeObjects;

    void UpdateTimeObjects()
    {
        timeObjects = GameObject.FindObjectsOfType<TimeControlled>();



    }




    void Start()
    {
        UpdateTimeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeObjects();


        bool stepBack = Input.GetKey(KeyCode.Space);

        if (stepBack)
        {
            for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                if (timeObject.isInTheCircle)
                {
                    timeObject.StepBack();
                }
                else {
                    timeObject.TimeUpdate();
                }
            }
        }

        else
        {
            for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                timeObject.TimeUpdate();
                timeObject.recordCount = timeObject.recordIndex;
                timeObject.RecordState();
            }

            
        }



        /*  else if (stepForward)
  {
      wasSteepingBack = true;
      if(recordIndex < recordCount -1)
      {
          recordIndex++;
          for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
          {
              TimeControlled timeObject = timeObjects[objectIndex];
              RecordedData data = recordedData[objectIndex, recordIndex];
              timeObject.transform.position = data.pos;
              timeObject.velocity = data.vel;
          }
      }
  }*/

        //ForwardTime, not sure if necessary

    }
}
