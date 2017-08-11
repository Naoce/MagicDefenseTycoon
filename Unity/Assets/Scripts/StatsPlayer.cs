using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public enum Fiole
    {
        RED,
        ORANGE,
        YELLOW,
        GREEN
    };

    public  GameObject  gm;
    public  GameObject  fioleRed;
    public  GameObject  fioleOrange;
    public  GameObject  fioleYellow;
    public  GameObject  fioleGreen;
    public  GameObject  levelUp;
    private Slider      healthBarGreen;
    private Slider      xpBar;
    private GameObject  textHP;
    private GameObject  textXP;
    private GameObject  textLevel;
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
    public  int         currXP;
    public  int         level;
    public  int         levelsWon;
    private Vector2     baseScale;
    private Vector2     newScale;
    public  int         animFiole;
    private Fiole       fioleState = Fiole.GREEN;
    public  int         stockHealthPotion;
    public  int         stockManaPotion;

    void Start ()
    {
        gm = GameObject.Find("GameManager");
        if (gm.GetComponent<GameManager>().currSave == 1)
        {
            level = PlayerPrefs.GetInt("Load1PlayerLevel");
            currXP = PlayerPrefs.GetInt("Load1PlayerXP");
        }
        else if (gm.GetComponent<GameManager>().currSave == 2)
        {
            level = PlayerPrefs.GetInt("Load2PlayerLevel");
            currXP = PlayerPrefs.GetInt("Load2PlayerXP");
        }
        else if (gm.GetComponent<GameManager>().currSave == 3)
        {
            level = PlayerPrefs.GetInt("Load3PlayerLevel");
            currXP = PlayerPrefs.GetInt("Load3PlayerXP");
        }

        levelsWon = 0;
        stockHealthPotion = 3;
        stockManaPotion = 1;
        textHP = gm.GetComponent<GameManager>().textHP;
        textXP = gm.GetComponent<GameManager>().textXP;
        textLevel = gm.GetComponent<GameManager>().textLevel;
        levelUp = gm.GetComponent<GameManager>().levelUpPlayer;
        fioleGreen = gm.GetComponent<GameManager>().fioleGreen;
        fioleYellow = gm.GetComponent<GameManager>().fioleYellow;
        fioleOrange = gm.GetComponent<GameManager>().fioleOrange;
        fioleRed = gm.GetComponent<GameManager>().fioleRed;
        healthBarGreen = gm.GetComponent<GameManager>().healthBarGreen;
        xpBar = gm.GetComponent<GameManager>().xpBar;
        levelUp.SetActive(false);
        fioleGreen.GetComponent<AnimOnStart>().player = this.gameObject;
        fioleGreen.GetComponent<AnimOnStart>().StartAnimationByScript();
        if (level == 0)
            level = 1;
        textLevel.GetComponent<Text>().text = level.ToString();
        damage = gm.GetComponent<GameManager>().playerDamage;
        maxHP = gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        currHP = maxHP;
        textHP.GetComponent<Text>().text = currHP + " / " + maxHP;
        textXP.GetComponent<Text>().text = currXP + " / " + gm.GetComponent<GameManager>().playerMaxXP[level - 1];
        Heal(0);
        textXP.GetComponent<Text>().text = currXP + " / " + gm.GetComponent<GameManager>().playerMaxXP[level - 1];
        xpBar.value = (float)currXP / (float)gm.GetComponent<GameManager>().playerMaxXP[level - 1];
        gm.GetComponent<GameManager>().textStockHealthPotion.GetComponent<Text>().text = GetComponent<StatsPlayer>().stockHealthPotion.ToString();
        gm.GetComponent<GameManager>().textStockManaPotion.GetComponent<Text>().text = GetComponent<StatsPlayer>().stockManaPotion.ToString();
    }

    public void     TakeDamage(int damageTaken, Vector2 directionPos, GameObject attacker)
    {
        if (GetComponent<Deplacements>().isDead == false)
        {
            if (gm.GetComponent<GameManager>().currMageType == 1)
            {
                if (GetComponent<MageElemental>().canRetaliateShield == true && attacker != null)
                    attacker.GetComponent<IAGuerrier>().TakeDamageFromPlayer(GetComponent<MageElemental>().retaliateDamage, transform.position);
                if (GetComponent<MageElemental>().canFreezeShield == true && attacker != null)
                    attacker.GetComponent<IAGuerrier>().ApplySlow(2, GetComponent<MageElemental>().retaliateFreeze);
            }

            damageTaken -= GetComponent<Shoots>().decorationBonusTanking;

            if (damageTaken > 0)
                currHP -= damageTaken;
            if (currHP < 0)
                currHP = 0;
            if (currHP <= 0)
            {
                GetComponent<Deplacements>().isDead = true;
                StartCoroutine(DeathAnimation(directionPos));
            }
            healthBarGreen.value = (float)currHP / (float)gm.GetComponent<GameManager>().playerMaxHP[level - 1];
            textHP.GetComponent<Text>().text = currHP + " / " + gm.GetComponent<GameManager>().playerMaxHP[level - 1];
            if (healthBarGreen.value > 0.75 &&
                fioleState != Fiole.GREEN)
            {
                fioleRed.SetActive(false);
                fioleOrange.SetActive(false);
                fioleYellow.SetActive(false);
                fioleGreen.SetActive(true);
                fioleGreen.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
                fioleGreen.GetComponent<AnimOnStart>().StartAnimationByScript();
                fioleState = Fiole.GREEN;
            }
            else if (healthBarGreen.value > 0.5 &&
                healthBarGreen.value <= 0.75 &&
                fioleState != Fiole.YELLOW)
            {
                fioleRed.SetActive(false);
                fioleOrange.SetActive(false);
                fioleYellow.SetActive(true);
                fioleYellow.GetComponent<AnimOnStart>().player = this.gameObject;
                fioleYellow.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
                fioleYellow.GetComponent<AnimOnStart>().StartAnimationByScript();
                fioleGreen.SetActive(false);
                fioleState = Fiole.YELLOW;
            }
            else if (healthBarGreen.value > 0.25 &&
                healthBarGreen.value <= 0.5 &&
                fioleState != Fiole.ORANGE)
            {
                fioleRed.SetActive(false);
                fioleOrange.SetActive(true);
                fioleOrange.GetComponent<AnimOnStart>().player = this.gameObject;
                fioleOrange.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
                fioleOrange.GetComponent<AnimOnStart>().StartAnimationByScript();
                fioleYellow.SetActive(false);
                fioleGreen.SetActive(false);
                fioleState = Fiole.ORANGE;
            }
            else if (healthBarGreen.value <= 0.25 &&
                fioleState != Fiole.RED)
            {
                fioleRed.SetActive(true);
                fioleRed.GetComponent<AnimOnStart>().player = this.gameObject;
                fioleRed.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
                fioleRed.GetComponent<AnimOnStart>().StartAnimationByScript();
                fioleOrange.SetActive(false);
                fioleYellow.SetActive(false);
                fioleGreen.SetActive(false);
                fioleState = Fiole.RED;
            }
        }
    }

    public void Heal(int healValue)
    {
        healValue += GetComponent<Shoots>().decorationBonusHealing;

        currHP += healValue;
        if (currHP > gm.GetComponent<GameManager>().playerMaxHP[level - 1])
            currHP = gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        healthBarGreen.value = (float)currHP / (float)gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        textHP.GetComponent<Text>().text = currHP + " / " + gm.GetComponent<GameManager>().playerMaxHP[level - 1];
        if (healthBarGreen.value > 0.75 &&
            fioleState != Fiole.GREEN)
        {
            fioleRed.SetActive(false);
            fioleOrange.SetActive(false);
            fioleYellow.SetActive(false);
            fioleGreen.SetActive(true);
            fioleGreen.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
            fioleGreen.GetComponent<AnimOnStart>().StartAnimationByScript();
            fioleState = Fiole.GREEN;
        }
        else if (healthBarGreen.value > 0.5 &&
            healthBarGreen.value <= 0.75 &&
            fioleState != Fiole.YELLOW)
        {
            fioleRed.SetActive(false);
            fioleOrange.SetActive(false);
            fioleYellow.SetActive(true);
            fioleYellow.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
            fioleYellow.GetComponent<AnimOnStart>().StartAnimationByScript();
            fioleGreen.SetActive(false);
            fioleState = Fiole.YELLOW;
        }
        else if (healthBarGreen.value > 0.25 &&
            healthBarGreen.value <= 0.5 &&
            fioleState != Fiole.ORANGE)
        {
            fioleRed.SetActive(false);
            fioleOrange.SetActive(true);
            fioleOrange.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
            fioleOrange.GetComponent<AnimOnStart>().StartAnimationByScript();
            fioleYellow.SetActive(false);
            fioleGreen.SetActive(false);
            fioleState = Fiole.ORANGE;
        }
        else if (healthBarGreen.value <= 0.25 &&
            fioleState != Fiole.RED)
        {
            fioleRed.SetActive(true);
            fioleRed.GetComponent<AnimOnStart>().SetAnimNb(animFiole);
            fioleRed.GetComponent<AnimOnStart>().StartAnimationByScript();
            fioleOrange.SetActive(false);
            fioleYellow.SetActive(false);
            fioleGreen.SetActive(false);
            fioleState = Fiole.RED;
        }
    }

    public void     EarnXP(int XpGain)
    {
        currXP += XpGain;
        if (level < 15 &&
            currXP >= gm.GetComponent<GameManager>().playerMaxXP[level - 1])
        {
            levelUp.SetActive(true);
            levelUp.GetComponent<AnimOnStart>().StartAnimationByScript();
            currXP -= gm.GetComponent<GameManager>().playerMaxXP[level - 1];
            level++;
            levelsWon++;
            textLevel.GetComponent<Text>().text = level.ToString();
            maxHP = gm.GetComponent<GameManager>().playerMaxHP[level - 1];
            Heal(5);
        }

        if (level < 15)
        {
            if (GetComponent<Shoots>().decorationBonusHealing != 0)
                GetComponent<Shoots>().decorationBonusHealing++;

            textXP.GetComponent<Text>().text = currXP + " / " + gm.GetComponent<GameManager>().playerMaxXP[level - 1];
            xpBar.value = (float)currXP / (float)gm.GetComponent<GameManager>().playerMaxXP[level - 1];
        }
        else
        {
            textXP.GetComponent<Text>().text = gm.GetComponent<GameManager>().playerMaxXP[14] + " / " + gm.GetComponent<GameManager>().playerMaxXP[14];
            xpBar.value = 1;
        }
    }

    public bool IsFullLife()
    {
        if ((float)currHP / (float)maxHP == 1)
            return (true);
        else
            return (false);
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProjectileEnemy")
        {
            TakeDamage(other.GetComponent<ProjectileEnemy>().damage, other.transform.position, null);
            other.GetComponent<ProjectileEnemy>().ExplosionChar();
        }
    }
}
