using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leveltext; 
    public void Load(int level)
    {
       if(level <= PlayerPrefs.GetInt("MaxLevel")) SceneManager.LoadScene(level);
       else { StartCoroutine(reject()); }
    }

    private IEnumerator reject()
    {
        string temp = leveltext.text;
        leveltext.text = "Not Unlocked";
        yield return new WaitForSeconds(2);
        leveltext.text = temp;
    }
}
