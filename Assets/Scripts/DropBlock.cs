using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField] GameObject[] spawns;
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector3(worldPos.x, worldPos.y, 0);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(spawns[0], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(spawns[1], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(spawns[2], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(spawns[3], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(spawns[4], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(spawns[5], pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Instantiate(spawns[6], pos, Quaternion.identity);
        }
    }
}
