using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoinContainer : MonoBehaviour
{
    public GameObject prefab_coin;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if( count==180 )
        {
            Vector3 position = new Vector3(Random.Range(-17.0f, 17.0f), gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(prefab_coin, position, Quaternion.identity);
            count = 0;
        }
    }
}
