using UnityEngine;
using System.Collections;

public class Capture : MonoBehaviour
{
    public  GameObject  mapManager;
    public  GameObject  CaptureObj;
    public  Sprite      Sprite2;
    public  Sprite      Sprite3;
    public  Sprite      Sprite4;
    public  Sprite      Sprite5;
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

            if ((float)currHP / maxHP <= 0.75f &&
                (float)currHP / maxHP > 0.5f)
                CaptureObj.GetComponent<SpriteRenderer>().sprite = Sprite2;
            else if ((float)currHP / maxHP <= 0.5f &&
                     (float)currHP / maxHP > 0.25f)
                CaptureObj.GetComponent<SpriteRenderer>().sprite = Sprite3;
            else if ((float)currHP / maxHP <= 0.25f &&
                    (float)currHP / maxHP > 0f)
                CaptureObj.GetComponent<SpriteRenderer>().sprite = Sprite4;

            mapManager.GetComponent<MapManager>().gm.GetComponent<GameManager>().CaptureTakeDamage(currHP, maxHP);
            if (currHP == 0)
            {
                CaptureObj.GetComponent<SpriteRenderer>().sprite = Sprite5;
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
