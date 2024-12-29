using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] DropBlock spawner;
    public bool gameRunning = true;
    public int presentsLost = 0;
    public int maxLost = 12;
    // Start is called before the first frame update
    void Start()
    {
        spawner.gml = this;
        spawner.genNewPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if (presentsLost >= maxLost) { 
            gameRunning= false;
        }
    }
}
