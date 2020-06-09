using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    float speed;
    public Transform pointA, pointB;
    // Start is called before the first frame update
    
    void LateUpdate()
    {
        speed = 1 * Time.deltaTime;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, speed);
    }
    
    
}
