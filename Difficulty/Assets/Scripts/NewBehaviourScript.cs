using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript: MonoBehaviour
    {
        public static float gravity = -100;
        public struct RecordedData
        {
            public Vector2 pos;
            public Vector2 vel;

        }

        public RecordedData[,] recordedData;
        int recordMax = 100000;
        int recordCount;
        int recordIndex;
        public bool wasSteepingBack = false;


        public TimeControlled[] timeObjects;

        void UpdateTimeObjects()
        {
            timeObjects = GameObject.FindObjectsOfType<TimeControlled>();

            RecordedData[,] newRecordedData = new RecordedData[timeObjects.Length, recordMax];

            int minObjectsLength = Mathf.Min(timeObjects.Length, recordedData != null ? recordedData.GetLength(0) : 0);


            for (int i = 0; i < minObjectsLength; i++)
            {
                for (int j = 0; j < recordCount; j++)
                {
                    newRecordedData[i, j] = recordedData[i, j];
                }
            }
            recordedData = newRecordedData;

        }




        void Start()
        {
            UpdateTimeObjects();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTimeObjects();

            //bool pause = Input.GetKey(KeyCode.S);
            //bool stepForward = Input.GetKey(KeyCode.D);
            bool stepBack = Input.GetKey(KeyCode.A);


            if (stepBack)
            {
                wasSteepingBack = true;

                if (recordIndex > 0)
                {
                    recordIndex--;

                    for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                    {

                        TimeControlled timeObject = timeObjects[objectIndex];
                        if (timeObject.isInTheCircle)
                        {
                            RecordedData data = recordedData[objectIndex, recordIndex];
                            timeObject.transform.position = data.pos;
                            timeObject.velocity = data.vel;
                        }



                    }
                }



            }


            else
            {
                if (wasSteepingBack)
                {
                    recordCount = recordIndex;
                    wasSteepingBack = false;

                }

                for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
                {
                    TimeControlled timeObject = timeObjects[objectIndex];
                    RecordedData data = new RecordedData();
                    data.pos = timeObject.transform.position;
                    data.vel = timeObject.velocity;
                    recordedData[objectIndex, recordCount] = data;
                }

                recordCount++;
                recordIndex = recordCount;


                foreach (TimeControlled timeObject in timeObjects)
                {
                    timeObject.TimeUpdate();
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
