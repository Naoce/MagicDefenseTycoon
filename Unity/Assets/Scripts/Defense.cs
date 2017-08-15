using UnityEngine;
using System.Collections;

public class Defense : MonoBehaviour
{
    public  GameObject  mapManager;
    public  GameObject  CaptureObj;
    public  Sprite      Sprite2;
    public  Sprite      Sprite3;
    public  Sprite      Sprite4;
    public  Sprite      Sprite5;
    private int         currHP;
    public  int         maxHP;
    public  bool        isDead;

    private void Start()
    {
        currHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isDead == false &&
            currHP > 0)
        {
            currHP -= damage;
            if (currHP < 0)
                currHP = 0;

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

            mapManager.GetComponent<MapManager>().gm.GetComponent<GameManager>().DefenseTakeDamage(currHP, maxHP);
            if (currHP == 0)
            {
                CaptureObj.GetComponent<SpriteRenderer>().sprite = Sprite5;
                isDead = true;
                StartCoroutine(DeathAnimation());
            }
        }
    }

    IEnumerator DeathAnimation()
    {
        yield return (0f);
        mapManager.GetComponent<MapManager>().LoseGame();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProjectileEnemy")
        {
            TakeDamage(other.GetComponent<ProjectileEnemy>().damage);
            other.GetComponent<ProjectileEnemy>().ExplosionChar();
        }
        else if (other.tag == "EnemyArrow")
        {
            TakeDamage(other.GetComponent<ArrowEnemy>().damage);
            other.GetComponent<ArrowEnemy>().ExplosionChar(true);
        }
    }
}
