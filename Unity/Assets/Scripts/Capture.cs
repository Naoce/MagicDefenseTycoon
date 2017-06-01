using UnityEngine;
using System.Collections;

public class Capture : MonoBehaviour
{
    public  GameObject  mapManager;
    private int         currHP;
    public  int         maxHP;
    private int         lastDragonTaken = -1;

    private void Start()
    {
        currHP = maxHP;   
    }

    public void TakeDamage(int damage)
    {
        if (GetComponent<Enemy>().isDead == false &&
            currHP > 0)
        {
            currHP -= damage;
            if (currHP < 0)
                currHP = 0;
            mapManager.GetComponent<MapManager>().gm.GetComponent<GameManager>().CaptureTakeDamage(currHP, maxHP);
            if (currHP == 0)
            {
                if (mapManager.GetComponent<MapManager>().IsEnemyAlreadyDead(GetComponent<Enemy>().id) == false)
                {
                    mapManager.GetComponent<MapManager>().FillDeadList(GetComponent<Enemy>().id);
                    GetComponent<Enemy>().isDead = true;
                    StartCoroutine(DeathAnimation());
                }
            }
        }
    }

    IEnumerator DeathAnimation()
    {
        yield return (0f);
        mapManager.GetComponent<MapManager>().WinGame();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
            other.GetComponent<Projectile>().ExplosionChar();
        }
        else if (other.tag == "IceShard")
        {
            TakeDamage(other.GetComponent<IceShard>().damage);
            other.GetComponent<IceShard>().ExplosionChar();
        }
        else if (other.tag == "DragonDeFeu" &&
                lastDragonTaken != other.GetComponent<DragonDeFeu>().id)
        {
            TakeDamage(other.GetComponent<DragonDeFeu>().damage);
            lastDragonTaken = other.GetComponent<DragonDeFeu>().id;
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
