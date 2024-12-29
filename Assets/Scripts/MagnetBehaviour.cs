using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : MonoBehaviour
{
    public float charge;
    [SerializeField] float range;

    Collider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<MagnetBehaviour>(out MagnetBehaviour other) && other.transform.parent != transform.parent && other.transform != transform){
                Vector2 dir = transform.position - other.transform.position;
                float dist = dir.magnitude;
                other.GetComponent<Rigidbody2D>().AddForce(-dir.normalized * charge * other.charge / (dist* dist));
            }
        }
    }

    public float getCharge()
    {
        return charge;
    }
}
