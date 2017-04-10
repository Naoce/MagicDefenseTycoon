using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IAGuerrierAgent : MonoBehaviour
{
    public Sprite       rightIdle;
    public Sprite[]     rightSprites;
    public Sprite[]     rightDeathSprites;
    public Sprite[]     rightAttackSprites;
    public float        animMoveCD;
    public float        animAttackCD;
    public float        animDeathCD;

    public GameObject   potionHealthSFX;
    public GameObject   healthBarGreen;
    public Slider       healthBarGreenHUD;
    private Slider      xpBarHUD;

    private GameObject  player;
    private GameObject  gm;
    private GameObject  mapManager;
    public  GameObject  target;
    public  GameObject  targetPlayer;
    public  Vector2     newPos = new Vector2(0, 0);
    private int         currentNumeroAnim = 0;
    private float       timer = 0f;
    private float       attackTimer = 0f;
    private float       attackCooldown = 1f;
    private float       timerPotion = 0f;
    public  float       cooldownPotion;
    private bool        canAttack = true;
    private bool        changedTarget = false;
    private GameObject  targetAttacking = null;

    private int currHP;
    public int maxHP;
    public int damage;
    public int level;
    public int stockHealthPotion;
    private float speed = 1f;
    private float slow = 0f;
    private Vector2 baseScale;
    private Vector2 newScale;
    public  bool isDead;
    private bool isAttacking = false;
    private bool rightSide = false;
    private bool needToMove = true;
    public  int  currXP;
    private bool isTargetMandatory = false;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        mapManager = GameObject.Find("MapManager");
        baseScale = healthBarGreen.transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (GetComponent<Agent>().idAgent == 0)
        {
            healthBarGreenHUD = gm.GetComponent<GameManager>().agent1healthBarGreenHUD;
            xpBarHUD = gm.GetComponent<GameManager>().agent1xpBarHUD;

            if (gm.GetComponent<GameManager>().currSave == 1)
            {
                level = PlayerPrefs.GetInt("Load1Agent1Level");
                currXP = PlayerPrefs.GetInt("Load1Agent1XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load1Agent1StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent1Level");
                currXP = PlayerPrefs.GetInt("Load2Agent1XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent1StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent1Level");
                currXP = PlayerPrefs.GetInt("Load3Agent1XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent1StockHealthPotion");
            }

            if (level > 1)
                gm.GetComponent<GameManager>().agent1Levels[1].SetActive(true);
            if (level > 2)
                gm.GetComponent<GameManager>().agent1Levels[2].SetActive(true);
            if (level > 3)
                gm.GetComponent<GameManager>().agent1Levels[3].SetActive(true);
            if (level > 4)
                gm.GetComponent<GameManager>().agent1Levels[4].SetActive(true);
            if (level > 5)
                gm.GetComponent<GameManager>().agent1Levels[5].SetActive(true);
            if (level > 6)
                gm.GetComponent<GameManager>().agent1Levels[6].SetActive(true);
            if (level > 7)
                gm.GetComponent<GameManager>().agent1Levels[7].SetActive(true);
            if (level > 8)
                gm.GetComponent<GameManager>().agent1Levels[8].SetActive(true);
            if (level > 9)
                gm.GetComponent<GameManager>().agent1Levels[9].SetActive(true);
        }
        else if (GetComponent<Agent>().idAgent == 1)
        {
            healthBarGreenHUD = gm.GetComponent<GameManager>().agent2healthBarGreenHUD;
            xpBarHUD = gm.GetComponent<GameManager>().agent2xpBarHUD;

            if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load1Agent2Level");
                currXP = PlayerPrefs.GetInt("Load1Agent2XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load1Agent2StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent2Level");
                currXP = PlayerPrefs.GetInt("Load2Agent2XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent2StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent2Level");
                currXP = PlayerPrefs.GetInt("Load3Agent2XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent2StockHealthPotion");
            }

            if (level > 1)
                gm.GetComponent<GameManager>().agent2Levels[1].SetActive(true);
            if (level > 2)
                gm.GetComponent<GameManager>().agent2Levels[2].SetActive(true);
            if (level > 3)
                gm.GetComponent<GameManager>().agent2Levels[3].SetActive(true);
            if (level > 4)
                gm.GetComponent<GameManager>().agent2Levels[4].SetActive(true);
            if (level > 5)
                gm.GetComponent<GameManager>().agent2Levels[5].SetActive(true);
            if (level > 6)
                gm.GetComponent<GameManager>().agent2Levels[6].SetActive(true);
            if (level > 7)
                gm.GetComponent<GameManager>().agent2Levels[7].SetActive(true);
            if (level > 8)
                gm.GetComponent<GameManager>().agent2Levels[8].SetActive(true);
            if (level > 9)
                gm.GetComponent<GameManager>().agent2Levels[9].SetActive(true);
        }
        else if (GetComponent<Agent>().idAgent == 2)
        {
            healthBarGreenHUD = gm.GetComponent<GameManager>().agent3healthBarGreenHUD;
            xpBarHUD = gm.GetComponent<GameManager>().agent3xpBarHUD;

            if (gm.GetComponent<GameManager>().currSave == 1)
            {
                level = PlayerPrefs.GetInt("Load1Agent3Level");
                currXP = PlayerPrefs.GetInt("Load1Agent3XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load1Agent3StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent3Level");
                currXP = PlayerPrefs.GetInt("Load2Agent3XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent3StockHealthPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent3Level");
                currXP = PlayerPrefs.GetInt("Load3Agent3XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent3StockHealthPotion");
            }

            if (level > 1)
                gm.GetComponent<GameManager>().agent3Levels[1].SetActive(true);
            if (level > 2)
                gm.GetComponent<GameManager>().agent3Levels[2].SetActive(true);
            if (level > 3)
                gm.GetComponent<GameManager>().agent3Levels[3].SetActive(true);
            if (level > 4)
                gm.GetComponent<GameManager>().agent3Levels[4].SetActive(true);
            if (level > 5)
                gm.GetComponent<GameManager>().agent3Levels[5].SetActive(true);
            if (level > 6)
                gm.GetComponent<GameManager>().agent3Levels[6].SetActive(true);
            if (level > 7)
                gm.GetComponent<GameManager>().agent3Levels[7].SetActive(true);
            if (level > 8)
                gm.GetComponent<GameManager>().agent3Levels[8].SetActive(true);
            if (level > 9)
                gm.GetComponent<GameManager>().agent3Levels[9].SetActive(true);
        }

        if (level == 0)
            level = 1;

        if (GetComponent<Agent>().type == 0)
            maxHP = gm.GetComponent<GameManager>().agentType0MaxHP[level - 1];
        currHP = maxHP;

        if (GetComponent<Agent>().type == 0)
            healthBarGreenHUD.value = (float)currHP / (float)gm.GetComponent<GameManager>().agentType0MaxHP[level - 1];

        xpBarHUD.value = (float)currXP / (float)gm.GetComponent<GameManager>().agentMaxXP[level - 1];
    }

    void Update()
    {
        if (gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (isDead == false && player.GetComponent<Deplacements>().isDead == false)
            {
                if (timerPotion < cooldownPotion)
                    timerPotion += Time.deltaTime;

                if (currHP <= maxHP / 2 &&
                    timerPotion >= cooldownPotion &&
                    stockHealthPotion > 0)
                {
                    timerPotion = 0f;
                    Heal(10);
                    GameObject sfx = (GameObject)Instantiate(potionHealthSFX, transform.position, transform.rotation);
                    sfx.GetComponent<AudioSource>().volume = gm.GetComponent<GameManager>().volumeSFX / 100;
                    stockHealthPotion--;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    RaycastHit2D hit = Physics2D.Raycast(player.GetComponent<Deplacements>().cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "EnemyGuerrier" || hit.collider.tag == "BossGuerrier" || hit.collider.tag == "Capture")
                        {
                            targetPlayer = hit.collider.gameObject;
                            if (target != targetPlayer)
                                changedTarget = true;
                            target = targetPlayer;
                            isTargetMandatory = true;
                        }
                    }
                }

                GameObject targetTmp = target;

                if (isTargetMandatory == false ||
                    target == null ||
                    (isTargetMandatory == true && target.GetComponent<Enemy>().isDead == true))
                {
                    targetTmp = FindClosestTarget();
                    isTargetMandatory = false;
                }

                if (targetTmp != target)
                {
                    target = targetTmp;
                    changedTarget = true;
                }

                if (target != null)
                {
                    if (changedTarget == true ||
                        Vector2.Distance(newPos, transform.position) <= 0.05f ||
                        Vector2.Distance(newPos, transform.position) > 2f)
                    {
                        changedTarget = false;
                        newPos = GetComponent<AStar>().StartPathFinding(target.transform.position);
                    }

                    if (isAttacking == false &&
                        canAttack == false)
                    {
                        attackTimer += Time.deltaTime;
                        if (attackTimer > attackCooldown)
                        {
                            attackTimer = 0f;
                            canAttack = true;
                        }
                    }
                    if (Vector2.Distance(target.transform.position, transform.position) <= 0.51f &&
                        target.GetComponent<Enemy>().isDead == false)
                    {
                        needToMove = false;
                        if (canAttack == true)
                        {
                            isAttacking = true;
                            targetAttacking = target;
                            canAttack = false;
                            StartCoroutine(AttackAnimation(target.transform.position));
                        }
                        else if (isAttacking == false)
                        {
                            if (rightSide == true)
                            {
                                GetComponent<SpriteRenderer>().flipX = false;
                                GetComponent<SpriteRenderer>().sprite = rightIdle;
                            }
                            else
                            {
                                GetComponent<SpriteRenderer>().flipX = true;
                                GetComponent<SpriteRenderer>().sprite = rightIdle;
                            }
                        }
                    }
                    else
                        needToMove = true;
                    if (isAttacking == false && needToMove == true)
                    {
                        timer += Time.deltaTime;

                        if (transform.position.x < target.transform.position.x)
                            rightSide = false;
                        else
                            rightSide = true;

                        transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * (speed - slow));

                        if (timer > animMoveCD &&
                        (transform.position.y != newPos.y ||
                        transform.position.x != newPos.x))
                        {
                            if (target != null &&
                                target.transform.position.x < transform.position.x)
                            {
                                GetComponent<SpriteRenderer>().flipX = true;
                                GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                            }
                            else
                            {
                                GetComponent<SpriteRenderer>().flipX = false;
                                GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                            }

                            if (currentNumeroAnim == rightSprites.Length)
                                currentNumeroAnim = 0;
                            timer = 0f;
                        }
                    }
                }
            }
        }
    }

    GameObject FindClosestTarget()
    {
        GameObject obj = null;
        float distanceTarget = 10000;
        float distanceNew;
        bool first = true;

        foreach(GameObject go in mapManager.GetComponent<MapManager>().enemiesList)
        {
            if (go.name == "Capture" ||
                go.GetComponent<Enemy>().isDead == false)
            {
                distanceNew = Vector2.Distance(transform.position, go.transform.position);
                if (first == false)
                {
                    if (distanceNew < distanceTarget)
                    {
                        distanceTarget = distanceNew;
                        obj = go;
                    }
                }
                else
                {
                    distanceTarget = distanceNew;
                    obj = go;
                    first = false;
                }
            }
        }
        return (obj);
    }

    public void TakeDamage(int damageTaken, Vector2 damagePos)
    {
        currHP -= damageTaken;
        if (currHP < 0)
            currHP = 0;
        float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
        if (GetComponent<Agent>().type == 0)
            healthBarGreenHUD.value = (float)currHP / (float)gm.GetComponent<GameManager>().agentType0MaxHP[level - 1];
        float diff;
        diff = baseScale.x * currHP / maxHP;
        newScale = new Vector2(diff, baseScale.y);
        healthBarGreen.transform.localScale = newScale;

        float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

        float difference = newValue - originalValue;

        healthBarGreen.transform.Translate(new Vector2(difference, 0));

        if (currHP <= 0)
        {
            isDead = true;
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<CircleCollider2D>());
            StartCoroutine(DeathAnimation(damagePos));
        }
    }

    public void Heal(int healAmount)
    {
        currHP += healAmount;
        if (currHP > maxHP)
            currHP = maxHP;

        float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

        if (GetComponent<Agent>().type == 0)
            healthBarGreenHUD.value = (float)currHP / (float)gm.GetComponent<GameManager>().agentType0MaxHP[level - 1];

        float diff;
        diff = baseScale.x * currHP / maxHP;
        newScale = new Vector2(diff, baseScale.y);
        healthBarGreen.transform.localScale = newScale;

        float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

        float difference = newValue - originalValue;

        healthBarGreen.transform.Translate(new Vector2(difference, 0));
    }

    IEnumerator DeathAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x < directionPos.x)
            animRight = false;
        else
            animRight = true;

        int animDeath = 0;
        while (animDeath < rightDeathSprites.Length)
        {
            if (animRight == true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<SpriteRenderer>().sprite = rightDeathSprites[animDeath];
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<SpriteRenderer>().sprite = rightDeathSprites[animDeath];
            }

            yield return new WaitForSeconds(animDeathCD);
            animDeath++;
        }

        mapManager.GetComponent<MapManager>().PopAgent(GetComponent<Agent>().id);
        Destroy(gameObject);
    }

    IEnumerator AttackAnimation(Vector2 directionPos)
    {
        bool animRight;
        if (transform.position.x > directionPos.x)
        {
            rightSide = false;
            animRight = false;
        }
        else
        {
            rightSide = true;
            animRight = true;
        }

        int animAttack = 0;
        while (animAttack < rightAttackSprites.Length)
        {
            if (animRight == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<SpriteRenderer>().sprite = rightAttackSprites[animAttack];
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<SpriteRenderer>().sprite = rightAttackSprites[animAttack];
            }

            yield return new WaitForSeconds(animAttackCD);
            animAttack++;
        }

        if (targetAttacking == target)
        {
            if (target != null &&
            (target.tag == "EnemyGuerrier" || target.tag == "BossGuerrier"))
            {
                target.GetComponent<IAGuerrier>().TakeDamageFromAgent(damage, transform.position, gameObject);
            }
            else if (target != null &&
                target.tag == "Capture")
            {
                target.GetComponent<Capture>().TakeDamage(damage);
            }
        }

        isAttacking = false;
        canAttack = false;
        timer = animMoveCD;

        if (rightSide == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        }
    }

    public void EarnXP(int newXP)
    {
        currXP += newXP;
        player.GetComponent<StatsPlayer>().EarnXP(newXP);
        if (currXP >= gm.GetComponent<GameManager>().agentMaxXP[level - 1])
        {
            currXP -= gm.GetComponent<GameManager>().agentMaxXP[level - 1];
            level++;
            gm.GetComponent<GameManager>().levelUpAgent1.SetActive(true);
            maxHP = gm.GetComponent<GameManager>().agentType0MaxHP[level - 1];
            TakeDamage(-10, Vector2.zero);

            if (GetComponent<Agent>().idAgent == 0)
            {
                if (level == 2)
                    gm.GetComponent<GameManager>().agent1Levels[1].SetActive(true);
                else if (level == 3)
                    gm.GetComponent<GameManager>().agent1Levels[2].SetActive(true);
                else if (level == 4)
                    gm.GetComponent<GameManager>().agent1Levels[3].SetActive(true);
                else if (level == 5)
                    gm.GetComponent<GameManager>().agent1Levels[4].SetActive(true);
                else if (level == 6)
                    gm.GetComponent<GameManager>().agent1Levels[5].SetActive(true);
                else if (level == 7)
                    gm.GetComponent<GameManager>().agent1Levels[6].SetActive(true);
                else if (level == 8)
                    gm.GetComponent<GameManager>().agent1Levels[7].SetActive(true);
                else if (level == 9)
                    gm.GetComponent<GameManager>().agent1Levels[8].SetActive(true);
                else if (level == 10)
                    gm.GetComponent<GameManager>().agent1Levels[9].SetActive(true);
            }
            else if (GetComponent<Agent>().idAgent == 1)
            {
                if (level == 2)
                    gm.GetComponent<GameManager>().agent2Levels[1].SetActive(true);
                else if (level == 3)
                    gm.GetComponent<GameManager>().agent2Levels[2].SetActive(true);
                else if (level == 4)
                    gm.GetComponent<GameManager>().agent2Levels[3].SetActive(true);
                else if (level == 5)
                    gm.GetComponent<GameManager>().agent2Levels[4].SetActive(true);
                else if (level == 6)
                    gm.GetComponent<GameManager>().agent2Levels[5].SetActive(true);
                else if (level == 7)
                    gm.GetComponent<GameManager>().agent2Levels[6].SetActive(true);
                else if (level == 8)
                    gm.GetComponent<GameManager>().agent2Levels[7].SetActive(true);
                else if (level == 9)
                    gm.GetComponent<GameManager>().agent2Levels[8].SetActive(true);
                else if (level == 10)
                    gm.GetComponent<GameManager>().agent2Levels[9].SetActive(true);
            }
            else if (GetComponent<Agent>().idAgent == 2)
            {
                if (level == 2)
                    gm.GetComponent<GameManager>().agent3Levels[1].SetActive(true);
                else if (level == 3)
                    gm.GetComponent<GameManager>().agent3Levels[2].SetActive(true);
                else if (level == 4)
                    gm.GetComponent<GameManager>().agent3Levels[3].SetActive(true);
                else if (level == 5)
                    gm.GetComponent<GameManager>().agent3Levels[4].SetActive(true);
                else if (level == 6)
                    gm.GetComponent<GameManager>().agent3Levels[5].SetActive(true);
                else if (level == 7)
                    gm.GetComponent<GameManager>().agent3Levels[6].SetActive(true);
                else if (level == 8)
                    gm.GetComponent<GameManager>().agent3Levels[7].SetActive(true);
                else if (level == 9)
                    gm.GetComponent<GameManager>().agent3Levels[8].SetActive(true);
                else if (level == 10)
                    gm.GetComponent<GameManager>().agent3Levels[9].SetActive(true);
            }
        }
        xpBarHUD.value = (float)currXP / (float)gm.GetComponent<GameManager>().agentMaxXP[level - 1];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProjectileEnemy")
        {
            TakeDamage(other.GetComponent<ProjectileEnemy>().damage, other.transform.position);
            other.GetComponent<ProjectileEnemy>().ExplosionChar();
        }
    }
}
