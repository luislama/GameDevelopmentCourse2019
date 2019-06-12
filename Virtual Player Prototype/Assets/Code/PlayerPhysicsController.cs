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
        gameObject.transform.localScale = new Vector3(3.0f, 3.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        manageMoveToLeft();
        if (Input.GetKey("left") && canMoveLeft)
        {
            // gameObject.GetComponent<Animator>().SetBool("jump",false);
            gameObject.GetComponent<Animator>().SetBool("run",true);
            gameObject.transform.localScale = new Vector3(-3.0f, 3.0f, 0.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( -1000f * Time.deltaTime, 0));
        }
        manageMoveToRight();
        if (Input.GetKey("right") && canMoveRight)
        {
            // gameObject.GetComponent<Animator>().SetBool("jump",false);
            gameObject.GetComponent<Animator>().SetBool("run",true);
            gameObject.transform.localScale = new Vector3(3.0f, 3.0f, 0.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( 1000f * Time.deltaTime, 0));
        }
        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("run",false);

        }
        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Animator>().SetBool("run",false);
            // gameObject.GetComponent<Animator>().SetBool("jump",true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2( 0, 30000f * Time.deltaTime));
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
            // gameObject.GetComponent<Animator>().SetBool("jump",false);
            canJump = true;
        }
        else
        {
            // gameObject.GetComponent<Animator>().SetBool("jump",true);
            // gameObject.GetComponent<Animator>().SetBool("run",false);
        }
        if (collision.transform.tag == "Mace")
        {
            var  scale = this.transform.localScale;
            if (scale.y > 0)
            {
                gameObject.transform.localScale = new Vector3(3.0f, -scale.y, 0.0f);
            }
        }
    }
}
