using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerScript : MonoBehaviour
{
    [SerializeField] GameObject blue;
    [SerializeField] GameObject red;
    [SerializeField] SpringJoint2D sj;
    private Rigidbody2D rb;
    public LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        genBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void genBlock()
    {
        GameObject block = GameObject.Instantiate((Random.Range(0,2) == 1 ) ? blue : red, transform.position, transform.rotation);
        block.GetComponent<Throwable>().slingRb = rb;
        block.GetComponent<Throwable>().sj = sj;

        sj.connectedBody = block.GetComponent<Rigidbody2D>();
        //sj.connectedAnchor = new Vector2(0, 0);

        block.GetComponent<Throwable>().lr = lr;
        block.GetComponent<Throwable>().thrower = this;
        block.GetComponent<Throwable>().releaseDelay = 1 / (sj.frequency * 4);



    }
}
