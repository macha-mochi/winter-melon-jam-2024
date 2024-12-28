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
               if(other.pole != this.pole)
               {
                    //attract
                    Vector2 dir = this.transform.position - other.transform.position;
                    other.GetComponent<Rigidbody2D>().AddForce(dir * attractForce);
                }
                else
                {
                    //repel
                    Vector2 dir = other.transform.position - this.transform.position;
                    other.GetComponent<Rigidbody2D>().AddForce(dir * repelForce);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
