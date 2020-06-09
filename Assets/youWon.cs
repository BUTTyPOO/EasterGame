using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youWon : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        gameMan.instance.youWon();
    }
}
