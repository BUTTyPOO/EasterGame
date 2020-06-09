using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    GameObject camera;
    Vector3 cam_offset = new Vector3(0f, 2.52f, -4.0f);
    Vector3 desiredPos;
    Vector3 smoothPos;
    float camSpeed = .01f;
    Rigidbody rb;
    float eggSpeed = 800f;
    float jumpHeight = 500f;
    public bool followingEgg;
    public bool canInput = true;
    GameObject brokeEgg;
    float t = 0f;
    float rate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 3000;
        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");
        if(camera.name == "Main Camera");
        {
            followingEgg = true;
        }
        Cursor.visible = false;
        brokeEgg = GameObject.Find("brokenEgg");
        brokeEgg.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            shatter();
        }
    }
    void LateUpdate()
    {
        if(followingEgg)
        {
            desiredPos = gameObject.transform.position + cam_offset;
            camSpeed *= Time.deltaTime;
            smoothPos = Vector3.Lerp(camera.transform.position, desiredPos, t);
            t += Time.deltaTime * rate;
            //camera.transform.position = gameObject.transform.position + cam_offset;
            camera.transform.position = smoothPos;
        }
        
    }
    void FixedUpdate() 
    {
        if(canInput)
        {
            movement();
        }
    }
    void movement()
    {
       //if(canInput)
       //{
            if(Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * eggSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * eggSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.forward * eggSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-Vector3.forward * eggSpeed * Time.deltaTime);
            }
            if(Input.GetKeyDown("space"))
            {
                rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime);
            }
        //}
    }
    public void shatter()
    {
        brokeEgg.SetActive(true);
        brokeEgg.transform.position = this.transform.position;
        gameObject.SetActive(false);
    }
}
