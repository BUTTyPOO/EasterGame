using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameMan.instance.death();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemy")
        {
            Debug.Log("KAKAKAK");
            Destroy(col.gameObject);
        }
    }
}
