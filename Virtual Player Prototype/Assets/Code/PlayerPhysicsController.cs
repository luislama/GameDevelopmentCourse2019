using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    bool canJump;
    bool canMoveRight;
    bool canMoveLeft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        manageMoveToLeft();
        if (Input.GetKey("left") && canMoveLeft)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( -1000f * Time.deltaTime, 0));
        }
        manageMoveToRight();
        if (Input.GetKey("right") && canMoveRight)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( 1000f * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( 0, 22500f * Time.deltaTime));
        }
    }

    private void linearStop()
    {
        var v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v =  Vector3.zero;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }

    private void manageMoveToRight()
    {
        if(gameObject.transform.position.x > 19.75f )
        {
            canMoveRight = false;
            linearStop();
        }
        else
        {
            canMoveRight = true;
        }
    }

    private void manageMoveToLeft()
    {
        if(gameObject.transform.position.x < -19.85f )
        {
            canMoveLeft = false;
            linearStop();

        }
        else
        {
            canMoveLeft = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
    }
}
