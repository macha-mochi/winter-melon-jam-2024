using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class WorldBoundaries : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.transform.parent.gameObject);
    }
}
