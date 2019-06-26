using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    bool canJump;
    public float speed_x = 5.0f;
    public float jump_y = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject hace referencia al objeto que contiene el script
        // gameObject.GetComponent<Transform>().position = new Vector3(50f, 10f, 0);

        // obj_name.GetComponent<Transform>() = obj_name.transform
        // Asignar posicion determinada al iniciar
        // gameObject.transform.position = new Vector3(50f, 10f, 0);

        // Asignar desplazamiento al iniciar
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x+50f, gameObject.transform.position.y+10f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime = segs en renderizar ultimo frame, hace que el moviemiento no dependa de los fps del dispositivo
        // gameObject.transform.position = new Vector3(gameObject.transform.position.x+1.5f*Time.deltaTime, 0, 0);
        // position = position + delta --> translate(delta)
        // gameObject.transform.Translate(1.5f*Time.deltaTime, 0, 0);

        if(Input.GetKey("left")){
            gameObject.transform.Translate(-speed_x*Time.deltaTime, 0.0f, 0.0f);
        }
        if(Input.GetKey("right")){
            gameObject.transform.Translate(speed_x*Time.deltaTime, 0.0f, 0.0f);
        }
        ManageJump();
    }

    void ManageJump()
    {
        if(gameObject.transform.position.y <= 0.0f)
        {
            canJump = true;
        }

        if(Input.GetKey("up") && canJump && gameObject.transform.position.y<3.0f)
        {
            gameObject.transform.Translate(0.0f, jump_y*Time.deltaTime, 0.0f);
        }
        else
        {
            canJump = false;
            if(gameObject.transform.position.y>0.0f)
            {
                gameObject.transform.Translate(0.0f, -3*jump_y*Time.deltaTime, 0.0f);
            }
        }
    }
}
