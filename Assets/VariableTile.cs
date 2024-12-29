using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VariableTile : MonoBehaviour
{
    [SerializeField] public bool noRand;
    private MagnetBehaviour mb;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        mb = GetComponent<MagnetBehaviour>();
        sr = GetComponent<SpriteRenderer>();
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

    public void setType(bool isBlue) {
        if (isBlue) {
            mb.charge = -10;
            Color c = new Color(97 / 255.0f, 124 / 255.0f, 255 / 255.0f);
            sr.color = c;
        }
        else
        {
            mb.charge = 10;
            Color c = new Color(255 / 255.0f, 90 / 255.0f, 90 / 255.0f);
            sr.color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
