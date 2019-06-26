using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMace : MonoBehaviour
{
    public GameObject prefab_mace;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if( count==300 )
        {
            Instantiate(prefab_mace);
            count = 0;
        }
    }
}