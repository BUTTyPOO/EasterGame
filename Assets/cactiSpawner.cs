using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactiSpawner : MonoBehaviour
{
    bool inRange;
    public GameObject cactus;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("releaseCac", 1.0f, 1.5f);
    }
    void releaseCac()
    {
        if(inRange)
        {
            Instantiate(cactus,gameObject.transform.position,
            new Quaternion(0, 0, Random.Range(-30f, 30f), 0));
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
