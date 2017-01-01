using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public  GameObject  gm;
    //public  GameObject  healthBarGreen;
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
        damage = gm.GetComponent<GameManager>().playerDamage;
        maxHP = gm.GetComponent<GameManager>().playerMaxHP;
        currHP = maxHP;
        currXP = gm.GetComponent<GameManager>().playerXP;
        level = gm.GetComponent<GameManager>().playerLevel;
        textHP.GetComponent<Text>().text = currHP + " / " + maxHP;
        textXP.GetComponent<Text>().text = currXP + " / " + GameManager.playerMaxXP[level - 1];
        // baseScale = healthBarGreen.transform.localScale;
    }

    public void     TakeDamage(int damageTaken, Vector2 directionPos)
    {
        currHP -= damageTaken;

        /*   float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
           float diff;
           diff = baseScale.x * currHP / maxHP;
           newScale = new Vector2(diff, baseScale.y);
           healthBarGreen.transform.localScale = newScale;

           float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

           float difference = newValue - originalValue;

           healthBarGreen.transform.Translate(new Vector2(difference, 0));*/
        textHP.GetComponent<Text>().text = currHP + " / " + maxHP;


        if (currHP == 0)
        {
            GetComponent<Deplacements>().isDead = true;
            StartCoroutine(DeathAnimation(directionPos));
        }
    }

    public void     EarnXP(int XpGain)
    {
        currXP += XpGain;
        if (currXP >= GameManager.playerMaxXP[level - 1])
        {
            currXP -= GameManager.playerMaxXP[level - 1];
            level++;
            textLevel.GetComponent<Text>().text = level.ToString();
        }
        textXP.GetComponent<Text>().text = currXP + " / " + GameManager.playerMaxXP[level - 1];
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

        Application.LoadLevel(0);
    }
}
