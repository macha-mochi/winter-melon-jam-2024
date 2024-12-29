using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : MonoBehaviour
{
    public float charge;
    [SerializeField] float range;
    public GameLevelManager gml;
    Collider2D[] colliders;

    int offScreen = 0;
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
        if (GetComponent<SpriteRenderer>().isVisible == false) {
            offScreen++;
            if (offScreen >= 5) { 
                Destroy(gameObject);
                if(gml != null) gml.presentsLost++;
            }
        } 
    }

    public float getCharge()
    {
        return charge;
    }
}
