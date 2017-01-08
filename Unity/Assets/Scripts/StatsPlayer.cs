using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public  GameObject  gm;
    public  Slider      healthBarGreen;
    public  Slider      xpBar;
    public  GameObject  textHP;
    public  GameObject  textXP;
    public  GameObject  textLevel;
    public  Sprite      rightDeath1;
    public  Sprite      rightDeath2;
    public  Sprite      rightDeath3;
    public  Sprite      rightDeath4;
    public  Sprite      rightDeath5;

    public  Sprite      leftDeath1;
    public  Sprite      leftDeath2;
    public  Sprite      leftDeath3;
    public  Sprite      leftDeath4;
    public  Sprite      leftDeath5;

    public  int         damage;
    private int         currHP;
    private int         maxHP;
    private int         currXP;
    public  int         level;
    private Vector2     baseScale;
    private Vector2     newScale;

    void Start ()
    {
        gm = GameObject.Find("GameManager");
        level = gm.GetComponent<GameManager>().playerLevel;
        damage = gm.GetComponent<GameManager>().playerDamage;
        maxHP = gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        currHP = maxHP;
        currXP = gm.GetComponent<GameManager>().playerXP;
        textHP.GetComponent<Text>().text = currHP + " / " + maxHP;
        textXP.GetComponent<Text>().text = currXP + " / " + gm.GetComponent<GameManager>().playerMaxXP[level - 1];
    }

    public void     TakeDamage(int damageTaken, Vector2 directionPos)
    {
        currHP -= damageTaken;
        healthBarGreen.value = (float)currHP / (float)gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        textHP.GetComponent<Text>().text = currHP + " / " + gm.GetComponent<GameManager>().playerMaxHP[level - 1];

        if (currHP == 0)
        {
            GetComponent<Deplacements>().isDead = true;
            StartCoroutine(DeathAnimation(directionPos));
        }
    }

    public void     EarnXP(int XpGain)
    {
        currXP += XpGain;
        if (currXP >= gm.GetComponent<GameManager>().playerMaxXP[level - 1])
        {
            currXP -= gm.GetComponent<GameManager>().playerMaxXP[level - 1];
            level++;
            textLevel.GetComponent<Text>().text = level.ToString();
            maxHP = gm.GetComponent<GameManager>().playerMaxHP[level - 1];
            TakeDamage(-5, Vector2.zero);
        }
        textXP.GetComponent<Text>().text = currXP + " / " + gm.GetComponent<GameManager>().playerMaxXP[level - 1];
        xpBar.value = (float)currXP / (float)gm.GetComponent<GameManager>().playerMaxXP[level - 1];
    }

    IEnumerator DeathAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x < directionPos.x)
            animRight = false;
        else
            animRight = true;

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath1;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath1;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath2;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath2;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath3;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath3;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath4;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath4;
        yield return new WaitForSeconds(0.08f);

        if (animRight == true)
            GetComponent<SpriteRenderer>().sprite = rightDeath5;
        else
            GetComponent<SpriteRenderer>().sprite = leftDeath5;
        yield return new WaitForSeconds(0.08f);

        gm.GetComponent<GameManager>().StartDefeat();
    }
}
