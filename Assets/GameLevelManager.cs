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
        lost.text = presentsLost.ToString() + "/" + maxLost.ToString();
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

        StartCoroutine(gotonextlvl());

    }

    private IEnumerator gotonextlvl() {
        SledScript ss = FindAnyObjectByType<SledScript>();
        while (ss.gameObject.transform.position.x > -30) {
            ss.gameObject.transform.position = Vector3.MoveTowards(ss.gameObject.transform.position, new Vector3(-30f, ss.gameObject.transform.position.y, ss.gameObject.transform.position.z),80f*Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        playSled();
        yield return new WaitForSeconds(1.5f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
        Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1), Color.black, 1.0f);
    }

    public void mainMenu() {
        Initiate.Fade("Level Select", Color.black, 1.0f);
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
            PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex + 1);
            verifyScreen.SetActive(false);
            winScreen.SetActive(true);
        }
        else
        {
            gameRunning = true;
            verifyScreen.SetActive(false);
            verifying = false;
        }
    }

    void playSled() { 
        SledScript ss = FindAnyObjectByType<SledScript>();
        ss.gameObject.GetComponent<Animator>().applyRootMotion = false;
        ss.gameObject.GetComponent<Animator>().SetBool("sledgo", true);
    }
}
