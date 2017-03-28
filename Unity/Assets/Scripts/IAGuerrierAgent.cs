using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IAGuerrierAgent : MonoBehaviour
{
    public Sprite   leftIdle;
    public Sprite[] leftSprites;
    public Sprite[] leftDeathSprites;
    public Sprite[] leftAttackSprites;

    public Sprite   rightIdle;
    public Sprite[] rightSprites;
    public Sprite[] rightDeathSprites;
    public Sprite[] rightAttackSprites;

    public Sprite   topIdle;
    public Sprite[] topSprites;

    public Sprite   botIdle;
    public Sprite[] botSprites;

    public GameObject healthBarGreen;
    public Slider healthBarGreenHUD;
    private Slider xpBarHUD;

    private GameObject  player;
    private GameObject  gm;
    private GameObject  mapManager;
    public  GameObject  target;
    public  GameObject  targetPlayer;
    public  Vector2     newPos = new Vector2(0, 0);
    public  Vector2     obstaclePos = new Vector2(0, 0);
    public  bool        isBypassing = false;
    public  GameObject  lastObstacle = null;
    public  int         lastObstacleCorner = 0;
    private int         currentNumeroAnim = 0;
    private float       timer = 0f;
    private float       animTime = 0.12f;
    private float       attackTimer = 0f;
    private float       attackCooldown = 1f;
    private bool        canAttack = true;
    private bool        changedTarget = false;
    private GameObject  targetAttacking = null;

    private int currHP;
    public int maxHP;
    public int damage;
    public int level;
    public int stockHealthPotion;
    public int stockManaPotion;
    private float speed = 1f;
    private float slow = 0f;
    private Vector2 baseScale;
    private Vector2 newScale;
    public  bool isDead;
    private bool isAttacking = false;
    private bool rightSide = false;
    private bool needToMove = true;
    public  int  currXP;

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
                stockManaPotion = PlayerPrefs.GetInt("Load1Agent1StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent1Level");
                currXP = PlayerPrefs.GetInt("Load2Agent1XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent1StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load2Agent1StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent1Level");
                currXP = PlayerPrefs.GetInt("Load3Agent1XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent1StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load3Agent1StockManaPotion");
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
                stockManaPotion = PlayerPrefs.GetInt("Load1Agent2StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent2Level");
                currXP = PlayerPrefs.GetInt("Load2Agent2XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent2StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load2Agent2StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent2Level");
                currXP = PlayerPrefs.GetInt("Load3Agent2XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent2StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load3Agent2StockManaPotion");
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
                stockManaPotion = PlayerPrefs.GetInt("Load1Agent3StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent3Level");
                currXP = PlayerPrefs.GetInt("Load2Agent3XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent3StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load2Agent3StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent3Level");
                currXP = PlayerPrefs.GetInt("Load3Agent3XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent3StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load3Agent3StockManaPotion");
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
        else if (GetComponent<Agent>().idAgent == 3)
        {
            healthBarGreenHUD = gm.GetComponent<GameManager>().agent4healthBarGreenHUD;
            xpBarHUD = gm.GetComponent<GameManager>().agent4xpBarHUD;

            if (gm.GetComponent<GameManager>().currSave == 1)
            {
                level = PlayerPrefs.GetInt("Load1Agent4Level");
                currXP = PlayerPrefs.GetInt("Load1Agent4XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load1Agent4StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load1Agent4StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 2)
            {
                level = PlayerPrefs.GetInt("Load2Agent4Level");
                currXP = PlayerPrefs.GetInt("Load2Agent4XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load2Agent4StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load2Agent4StockManaPotion");
            }
            else if (gm.GetComponent<GameManager>().currSave == 3)
            {
                level = PlayerPrefs.GetInt("Load3Agent4Level");
                currXP = PlayerPrefs.GetInt("Load3Agent4XP");
                stockHealthPotion = PlayerPrefs.GetInt("Load3Agent4StockHealthPotion");
                stockManaPotion = PlayerPrefs.GetInt("Load3Agent4StockManaPotion");
            }

            if (level > 1)
                gm.GetComponent<GameManager>().agent4Levels[1].SetActive(true);
            if (level > 2)
                gm.GetComponent<GameManager>().agent4Levels[2].SetActive(true);
            if (level > 3)
                gm.GetComponent<GameManager>().agent4Levels[3].SetActive(true);
            if (level > 4)
                gm.GetComponent<GameManager>().agent4Levels[4].SetActive(true);
            if (level > 5)
                gm.GetComponent<GameManager>().agent4Levels[5].SetActive(true);
            if (level > 6)
                gm.GetComponent<GameManager>().agent4Levels[6].SetActive(true);
            if (level > 7)
                gm.GetComponent<GameManager>().agent4Levels[7].SetActive(true);
            if (level > 8)
                gm.GetComponent<GameManager>().agent4Levels[8].SetActive(true);
            if (level > 9)
                gm.GetComponent<GameManager>().agent4Levels[9].SetActive(true);
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
                        }
                    }
                }

                GameObject targetTmp = FindClosestTarget();
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
                                GetComponent<SpriteRenderer>().sprite = leftIdle;
                            else
                                GetComponent<SpriteRenderer>().sprite = rightIdle;
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

                        if (timer > animTime &&
                        (transform.position.y != newPos.y ||
                        transform.position.x != newPos.x))
                        {
                            if (((rightSide == true &&
                                newPos.x > transform.position.x) ||
                                (rightSide == false &&
                                newPos.x < transform.position.x)) &&
                                newPos.y < transform.position.y)
                                GetComponent<SpriteRenderer>().sprite = botSprites[currentNumeroAnim++];
                            else if (((rightSide == true &&
                                newPos.x > transform.position.x) ||
                                (rightSide == false &&
                                newPos.x < transform.position.x)) &&
                                newPos.y > transform.position.y)
                                GetComponent<SpriteRenderer>().sprite = topSprites[currentNumeroAnim++];
                            else if (newPos.x < transform.position.x)
                                GetComponent<SpriteRenderer>().sprite = leftSprites[currentNumeroAnim++];
                            else
                                GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                            if (currentNumeroAnim == leftSprites.Length)
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
                GetComponent<SpriteRenderer>().sprite = rightDeathSprites[animDeath];
            else
                GetComponent<SpriteRenderer>().sprite = leftDeathSprites[animDeath];
            yield return new WaitForSeconds(0.08f);
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
            rightSide = true;
            animRight = false;
        }
        else
        {
            rightSide = false;
            animRight = true;
        }

        int animAttack = 0;
        while (animAttack < rightAttackSprites.Length)
        {
            if (animRight == true)
                GetComponent<SpriteRenderer>().sprite = rightAttackSprites[animAttack];
            else
                GetComponent<SpriteRenderer>().sprite = leftAttackSprites[animAttack];
            yield return new WaitForSeconds(0.08f);
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
        timer = 0.09f;

        if (rightSide == true)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
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
            else if (GetComponent<Agent>().idAgent == 3)
            {
                if (level == 2)
                    gm.GetComponent<GameManager>().agent4Levels[1].SetActive(true);
                else if (level == 3)
                    gm.GetComponent<GameManager>().agent4Levels[2].SetActive(true);
                else if (level == 4)
                    gm.GetComponent<GameManager>().agent4Levels[3].SetActive(true);
                else if (level == 5)
                    gm.GetComponent<GameManager>().agent4Levels[4].SetActive(true);
                else if (level == 6)
                    gm.GetComponent<GameManager>().agent4Levels[5].SetActive(true);
                else if (level == 7)
                    gm.GetComponent<GameManager>().agent4Levels[6].SetActive(true);
                else if (level == 8)
                    gm.GetComponent<GameManager>().agent4Levels[7].SetActive(true);
                else if (level == 9)
                    gm.GetComponent<GameManager>().agent4Levels[8].SetActive(true);
                else if (level == 10)
                    gm.GetComponent<GameManager>().agent4Levels[9].SetActive(true);
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
