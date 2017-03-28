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
        else if (collision.tag == "IceShard")
        {
            collision.GetComponent<IceShard>().Explosion();
        }
        else if (collision.tag == "CheckPathEnemyProjectile")
        {
            collision.GetComponent<CheckPath>().HasCollided();
        }
        else if (collision.tag == "ProjectileEnemy")
        {
            collision.GetComponent<ProjectileEnemy>().Explosion();
        }
    }
}
