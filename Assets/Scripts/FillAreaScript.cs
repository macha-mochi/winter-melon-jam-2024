using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillAreaScript : MonoBehaviour
{
    private HashSet<GameObject> presents = new HashSet<GameObject>();
    GameLevelManager gml;
    // Start is called before the first frame update
    void Start()
    {
        gml = FindAnyObjectByType<GameLevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gml.currentPresents = presents.Count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile") {
            presents.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            presents.Remove(collision.gameObject);
        }
    }
}
