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
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 7.2f, 5.0f);
            Instantiate(prefab_coin, position, Quaternion.identity);
            count = 0;
        }
    }
}
