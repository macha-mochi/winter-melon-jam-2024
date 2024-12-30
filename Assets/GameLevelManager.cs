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
    [SerializeField] GameObject verifyScreen;
    bool verifying = false;
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
        else if (!verifying && currentPresents >= neededPresents) {
            gameRunning = false;
            verifyScreen.SetActive(true);
            StartCoroutine(checkWin());
            verifying = true;
        }
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1.0f);
    }
    private IEnumerator checkWin()
    {
        yield return new WaitForSeconds(3);
        if(currentPresents >= neededPresents)
        {
            verifyScreen.SetActive(false);
            winScreen.SetActive(true);
        }
    }
}
