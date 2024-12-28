using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject fourByOne;
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
            Instantiate(red, pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(blue, pos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(fourByOne, pos, Quaternion.identity);
        }
    }
}
