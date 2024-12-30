using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledScript : MonoBehaviour
{

    GameLevelManager gml;
    // Start is called before the first frame update
    void Start()
    {
        gml = FindAnyObjectByType<GameLevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gml.gameRunning) {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);
        }
    }
}
