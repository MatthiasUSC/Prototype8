using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : TimeControlled
{
    public float moveTime;
    public Vector2 moveOffset;
    private Vector2 origPos;
    void Start()
    {
        origPos = (Vector2)transform.position;
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        float elapsedTime = 0;
        while(elapsedTime < moveTime){
            yield return null;
            elapsedTime += Time.unscaledDeltaTime;
            float ratio = elapsedTime / moveTime;
            transform.position = (Vector3)(origPos + (ratio * moveOffset));
        }
    }
}
