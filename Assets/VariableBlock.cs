using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableBlock : MonoBehaviour
{

    [SerializeField] VariableTile p1;
    [SerializeField] VariableTile p2;
    [SerializeField] VariableTile p3;
    [SerializeField] VariableTile p4;
    [SerializeField] bool polarized;
    // Start is called before the first frame update
    void Start()
    {
        if (polarized) { 
            p1.noRand = true;
            p2.noRand = true;
            p3.noRand = true;
            p4.noRand = true;

            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                p1.setType(true);
                p2.setType(true);
                p3.setType(false);
                p4.setType(false);
            }
            else {
                p1.setType(false);
                p2.setType(false);
                p3.setType(true);
                p4.setType(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
