using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilattingMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float length = 24.0f; // Desired length of the ping-pong
        float bottomFloor = -12.0f; // The low position of the ping-pong
        pos.x = Mathf.PingPong(3*Time.time, length) + bottomFloor;
        transform.position = pos; // new position
    }
}
