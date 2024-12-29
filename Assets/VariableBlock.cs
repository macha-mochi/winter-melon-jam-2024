using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableBlock : MonoBehaviour
{

    [SerializeField] VariableTile[] ps;
    [SerializeField] bool polarized;
    // Start is called before the first frame update
    void Start()
    {
        if (polarized) { 
            foreach (var tile in ps)
            {
                tile.noRand = true;
            }
            List<int> arr = new List<int>();
            for(int i = 0; i < 4; i++) arr.Add(i);
            arr.RemoveAt(Random.Range(0, arr.Count));
            arr.RemoveAt(Random.Range(0, arr.Count));
            Debug.Log(arr.Count);
            bool set = false;
            for (int i = 0; i < 4; i++) {
                if (arr.Contains(i))
                {
                    if (!set)
                    {
                        ps[i].setType(-1);
                        set = true;
                    }
                    else
                    {
                        ps[i].setType(1);

                    }

                }
                else
                {
                    ps[i].setType(0);
                }
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
