using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    [SerializeField] int pole; //0 or 1
    [SerializeField] float attractForce;
    [SerializeField] float repelForce;
    [SerializeField] float forceRange;

    Collider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, forceRange);
        for(int i = 0; i < colliders.Length; i++)
        {
            PhysicsTest other = colliders[i].gameObject.GetComponent<PhysicsTest>();
            if (other != null)
            {
                if(this.transform.parent != null && other.transform.parent != null && this.transform.parent == other.transform.parent)
                {
                    //same object, don't do anything

                }
                else
                {
                    if (other.pole != this.pole)
                    {
                        //attract
                        Vector2 dir = this.transform.position - other.transform.position;
                        float mag = dir.magnitude;
                        dir = dir.normalized;
                        Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();
                        if(rb != null && ((repelForce / (mag * mag))) < 100000) rb.AddForce(dir * (attractForce/ (mag*mag)));
                        //Debug.Log((attractForce / (mag * mag)));
                    }
                    else
                    {
                        //repel
                        Vector2 dir = other.transform.position - this.transform.position;
                        float mag = dir.magnitude;

                        dir = dir.normalized;
                        Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();
                        //Debug.Log(((repelForce / (mag * mag))));
                        if (rb != null && ((repelForce / (mag * mag))) < 100000)  rb.AddForce(dir * (repelForce/ (mag*mag)));
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
