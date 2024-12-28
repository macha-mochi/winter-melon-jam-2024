using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatformCircle : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float circleChargeMagnitude;
    [SerializeField] GameObject[] reds;
    [SerializeField] GameObject[] blues;

    Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, range);
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<MagnetBehaviour>(out MagnetBehaviour other) && other.transform.parent != transform.parent && other.transform != transform)
            {
                GameObject mag = null;
                float circleCharge = closestMagnet(other.gameObject, mag);

                Vector2 dir = transform.position - other.transform.position;
                float dist = dir.magnitude;
                other.GetComponent<Rigidbody2D>().AddForce(-dir.normalized * circleCharge * other.charge * 0.5f / dist);
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
    float closestMagnet(GameObject other, GameObject magnet)
    {
        GameObject cr = closestRed(other);
        float redDist = Vector2.Distance(other.transform.position, cr.transform.position);
        GameObject cb = closestBlue(other);
        float blueDist = Vector2.Distance(other.transform.position, cb.transform.position);
        if (redDist <= blueDist)
        {
            magnet = cr;
            return circleChargeMagnitude;
        }
        else
        {
            magnet = cb;
            return -circleChargeMagnitude;
        }
    }
}
