using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject tutorialPopup;

    public void Play()
    {
        if(PlayerPrefs.GetInt("MaxLevel") <=1) PlayerPrefs.SetInt("MaxLevel", 2);
        SceneManager.LoadScene(1);
    }
    public void Tutorial()
    {
        tutorialPopup.SetActive(true);
    }
    public void closeTutorial()
    {
        tutorialPopup.SetActive(false);
    }
}
