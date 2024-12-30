using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VariableTile : MonoBehaviour
{
    [SerializeField] public bool noRand;
    private MagnetBehaviour mb;
    private SpriteRenderer sr;
    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    [SerializeField] Sprite white;

    private void Awake()
    {
        mb = GetComponent<MagnetBehaviour>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
     
        if (!noRand) {
            int rand = Random.Range(0, 3);
            if (rand == 1)
            {
                mb.charge = 10;
                Color c = new Color(255 / 255.0f, 90 / 255.0f, 90 / 255.0f);
                sr.color = c;
            }
            else if (rand == 2)
            {
                mb.charge = -10;
                Color c = new Color(97 / 255.0f, 124 / 255.0f, 255 / 255.0f);
                sr.color = c;


            }
        }
    }

    public void setType(int charge) {
        if (charge == -1)
        {
            mb.charge = -10;
            sr.sprite = blue;
            sr.gameObject.GetComponentInChildren<Light2D>().color = Color.white;
            sr.gameObject.GetComponentInChildren<Light2D>().lightCookieSprite = blue;

        }
        else if (charge == 1)
        {
            mb.charge = 10;
            sr.sprite = red;
            sr.gameObject.GetComponentInChildren<Light2D>().color = Color.white;
            sr.gameObject.GetComponentInChildren<Light2D>().lightCookieSprite = red;


        }
        else {
            mb.charge = 0;
            Color c = Color.white;
            sr.sprite = white;
            sr.gameObject.GetComponentInChildren<Light2D>().color = Color.white;
            sr.gameObject.GetComponentInChildren<Light2D>().lightCookieSprite = white;
            sr.gameObject.GetComponentInChildren<Light2D>().intensity = 1.5f;


        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
