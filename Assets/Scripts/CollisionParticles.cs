using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CollisionParticles : MonoBehaviour
{
    [SerializeField] AudioSource clink;
    [SerializeField] GameObject particles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {
            clink.Play();
            ContactPoint2D cp = collision.GetContact(Random.Range(0, collision.contactCount - 1));
            GameObject p = Instantiate(particles, cp.point, Quaternion.identity);
            Destroy(p, 1f);
        }
    }
}
