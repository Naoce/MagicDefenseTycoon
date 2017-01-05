using UnityEngine;
using System.Collections;

public class ProjectileBreak : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            collision.GetComponent<Projectile>().Explosion();
        }
    }
}
