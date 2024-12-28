using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatformCircle : MonoBehaviour
{
    [SerializeField] float attractForce;
    [SerializeField] float repelForce;
    [SerializeField] float forceRange;
    [SerializeField] GameObject[] reds;
    [SerializeField] GameObject[] blues;

    Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, forceRange);
        for(int i = 0; i < colliders.Length; i++)
        {
            PhysicsTest other = colliders[i].gameObject.GetComponent<PhysicsTest>();
            if (other != null)
            {
                GameObject mag = null;
                int color = closestMagnet(other.gameObject, mag);

                if (other.pole != color)
                {
                    //attract
                    Vector2 dir = this.transform.position - other.transform.position;
                    float dist = dir.magnitude;
                    dir = dir.normalized;
                    Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();
                    if (rb != null && ((attractForce / (dist * dist))) < 100000) rb.AddForce(dir * (attractForce / (dist * dist)));
                }
                else
                {
                    //repel
                    Vector2 dir = other.transform.position - this.transform.position;
                    float dist = dir.magnitude;
                    dir = dir.normalized;
                    Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();
                    if (rb != null && ((repelForce / (dist * dist))) < 100000) rb.AddForce(dir * (repelForce / (dist * dist)));
                }
            }
        }
    }

    GameObject closestRed(GameObject other)
    {
        GameObject cr = reds[0];
        float minDist = Vector2.Distance(cr.transform.position, other.transform.position);
        for (int j = 1; j < reds.Length; j++)
        {
            if (Vector2.Distance(reds[j].transform.position, other.transform.position) < minDist)
            {
                cr = reds[j];
            }
        }
        return cr;
    }
    GameObject closestBlue(GameObject other)
    {
        GameObject cb = blues[0];
        float minDist = Vector2.Distance(cb.transform.position, other.transform.position);
        for (int j = 1; j < blues.Length; j++)
        {
            if (Vector2.Distance(blues[j].transform.position, other.transform.position) < minDist)
            {
                cb = blues[j];
            }
        }
        return cb;
    }
    int closestMagnet(GameObject other, GameObject magnet)
    {
        GameObject cr = closestRed(other);
        float redDist = Vector2.Distance(other.transform.position, cr.transform.position);
        GameObject cb = closestBlue(other);
        float blueDist = Vector2.Distance(other.transform.position, cb.transform.position);
        if (redDist <= blueDist)
        {
            magnet = cr;
            return 0;
        }
        else
        {
            magnet = cb;
            return 1;
        }
    }
}
