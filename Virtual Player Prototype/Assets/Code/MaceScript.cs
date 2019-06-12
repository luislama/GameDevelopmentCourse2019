using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    private Transform obj_trasform;
    bool toRight;
    bool toLeft;


    private void Awake()
    {
        obj_trasform = this.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().position = new Vector3(-23.0f, 0.0f, 0.0f);
        toRight = true;
        toLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toRight)
        {
            if (gameObject.transform.position.x < 19.75f)
            {
                gameObject.transform.Translate(10.0f*Time.deltaTime, 0, 0);
            }
            else
            {
                linearStop();
                toRight = false;
                toLeft = true;
            }
        }
        if (toLeft)
        {
            if (gameObject.transform.position.x > -19.85f )
            {
                gameObject.transform.Translate(-10.0f*Time.deltaTime, 0, 0);
            }
            else
            {
                linearStop();
                toLeft = false;
                toRight = true;
            }
        }
    }

    private void linearStop()
    {
        var v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v =  Vector3.zero;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Mace")
        {
            Destroy(gameObject);
        }
    }
}
