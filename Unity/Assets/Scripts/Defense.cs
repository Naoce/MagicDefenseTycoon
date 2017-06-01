using UnityEngine;
using System.Collections;

public class Defense : MonoBehaviour
{
    public  GameObject  mapManager;
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
            mapManager.GetComponent<MapManager>().gm.GetComponent<GameManager>().DefenseTakeDamage(currHP, maxHP);
            if (currHP == 0)
            {
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
}
