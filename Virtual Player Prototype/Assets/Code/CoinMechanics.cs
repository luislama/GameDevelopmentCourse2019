﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("ASDASDASD");
    //     if (other.gameObject.tag == "thing")
    //     {
    //         Debug.Log(" the object!!!!! ");
    //         Destroy(this);
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "thing")
        {
            Destroy(gameObject);
        }
    }
}
