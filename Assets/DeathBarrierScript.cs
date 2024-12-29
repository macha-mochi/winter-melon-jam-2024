using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrierScript : MonoBehaviour
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            if (gml != null) gml.presentsLost++;
            Destroy(collision.gameObject);
        }
    }
}
