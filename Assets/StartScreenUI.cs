using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject tutorialPopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Tutorial()
    {
        tutorialPopup.SetActive(true);
    }
}
