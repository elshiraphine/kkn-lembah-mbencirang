using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 10;

    }

    // Update is called once per frame
    void Update()
    {


        //transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min), transform.position.y, transform.position.z);
        transform.Rotate(0, 0, Time.deltaTime * tiltAngle);

    }

}
