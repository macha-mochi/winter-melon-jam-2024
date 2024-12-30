using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] DropBlock spawner;
    public bool gameRunning = true;
    public int presentsLost = 0;
    public int maxLost = 12;
    [SerializeField] TMP_Text lost;
    [SerializeField] GameObject lossScreen;
    [SerializeField] TMP_Text gifts;
    public int currentPresents;
    public int neededPresents;
    [SerializeField] GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        spawner.gml = this;
        spawner.genNewPiece();
    }

    // Update is called once per frame
    void Update()
    {
        lost.text = presentsLost.ToString();
        gifts.text = currentPresents.ToString() + "/" + neededPresents.ToString();
        if (presentsLost >= maxLost)
        {
            gameRunning = false;
            lossScreen.SetActive(true);
        }
        else if (currentPresents >= neededPresents) {
            gameRunning = false;
            winScreen.SetActive(true);
        }
    }

    public void restart()
    {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1.0f);
    }
}
