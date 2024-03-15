using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;

    public float maxHorizontalSpeed;
    public float horizontalAccel;

    public GameObject groundCheck1;
    public GameObject groundCheck2;
    public bool isGrounded = false;
    
    public float jumpVelocity = 10;

    void Start()
    {
        
    }

    void Update(){
        if(Input.GetKey(jump) && isGrounded){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpVelocity);
        }
    }

    void FixedUpdate()
    {
        // Ground check
        isGrounded = false;
        RaycastHit2D hit1 = Physics2D.Raycast(groundCheck1.transform.position, Vector3.down, 0.1f);
        if(hit1.collider != null){
            if(hit1.collider.transform.tag == "Ground"){
                isGrounded = true;
            }
        }
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheck2.transform.position, Vector3.down, 0.1f);
        if(hit2.collider != null){
            if(hit2.collider.transform.tag == "Ground"){
                isGrounded = true;
            }
        }

        // Physics Controls
        float horizontalVel = GetComponent<Rigidbody2D>().velocity.x;
        float horizontalForce = horizontalAccel * GetComponent<Rigidbody2D>().mass;
        if(Input.GetKey(left)){
            if(horizontalVel >= -maxHorizontalSpeed){
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * horizontalForce);
            }
        }

        if(Input.GetKey(right)){
            if(horizontalVel <= maxHorizontalSpeed){
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalForce);
            }
        }

        // Slowing down automatically on ground (friction)
        float dragThreshold = 0.5f;
        if(!Input.GetKey(left) && !Input.GetKey(right) && isGrounded){
            if(horizontalVel > dragThreshold){
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * horizontalForce);
            } else if (horizontalVel < -dragThreshold){
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalForce);
            }

            if(Mathf.Abs(horizontalVel) < dragThreshold){
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
