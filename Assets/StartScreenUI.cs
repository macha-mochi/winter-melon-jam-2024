using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject tutorialPopup;

    public void Play()
    {
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
