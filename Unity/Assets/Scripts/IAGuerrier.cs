using UnityEngine;
using System.Collections;

public class IAGuerrier : MonoBehaviour 
{
    public enum EnemyType
    {
        Normal,
        Player,
        Objectif,
        Magician
    };

    public  Sprite[]    leftSprites;
    public  Sprite      leftIdle;
    public  Sprite[]    leftDeathSprites;
    public  Sprite[]    leftAttackSprites;

    public  Sprite[]    rightSprites;
    public  Sprite      rightIdle;
    public  Sprite[]    rightDeathSprites;
    public  Sprite[]    rightAttackSprites;

    public  Sprite[]    topSprites;
    public  Sprite      topIdle;

    public  Sprite[]    botSprites;
    public  Sprite      botIdle;

    public  GameObject  healthBarGreen;
    public  EnemyType   type;

    public 	GameObject	player;
    private GameObject  gm;
    public  Vector2     newPos;
    public  float       range;
    private int         currentNumeroAnim = 1;
	private	float		timer = 0f;
	private float		animTime = 0.12f;
    private float       attackTimer = 0f;
    private float       attackCooldown = 1f;
    private float       timerCC = 0f;
    private float       cooldownCC = 0f;
    private float       timerFlying = 0f;
    private float       cooldownFlying = 0f;
    private float       timerSlow = 0f;
    private float       cooldownSlow = 0f;

    private int         currHP;
    public  int         maxHP;
    public  int         damage;
    public  int         valueXP;
    private float       speed = 1f;
    private float       slow = 0f;
    private Vector2     baseScale;
    private Vector2     newScale;
    private Vector2     initialScale;
    private bool        canMove = true;
    private bool        isFlying = false;
    private bool        isSlowed = false;
    private bool        isAttacking = false;
    private bool        canAttack = true;
    private bool        rightSide = false;
    private bool        needToMove = true;
    public  GameObject  target = null;
    private int         lastDragonTaken = -1;
    private int         lastTornadoTaken = -1;
    public  bool        isBoss;

	void Start () 
	{
        initialScale = transform.localScale;
        gm = GameObject.Find("MapManager");
        currHP = maxHP;
        if (isBoss == false)
            baseScale = healthBarGreen.transform.localScale;
    }

	void Update ()
	{
        if (gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().gamePaused == false)
        {
            if (isSlowed == true)
            {
                timerSlow += Time.deltaTime;
                if (timerSlow > cooldownSlow)
                {
                    timerSlow = 0f;
                    slow = 0f;
                    isSlowed = false;
                }
            }
            if (canMove == false)
            {
                timerCC += Time.deltaTime;
                if (timerCC > cooldownCC)
                {
                    canAttack = true;
                    canMove = true;
                    timerCC = 0f;
                }
                if (isFlying == true)
                {
                    Vector2 newScaleGo = new Vector2(transform.localScale.x + 0.002f, transform.localScale.y + 0.002f);
                    transform.localScale = newScaleGo;
                    timerFlying += Time.deltaTime;
                    if (timerFlying > cooldownFlying)
                    {
                        canAttack = true;
                        timerFlying = 0f;
                        isFlying = false;
                        transform.localScale = initialScale;
                    }
                }
            }
            if (GetComponent<Enemy>().isDead == false && player.GetComponent<Deplacements>().isDead == false &&
                canMove == true)
            {
                target = FindClosestTarget();
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
                if (Vector2.Distance(target.transform.position, transform.position) <= range &&
                    ((target.tag == "Player" &&
                    target.GetComponent<Deplacements>().isDead == false) || 
                    (target.tag == "AgentGuerrier" &&
                    target.GetComponent<IAGuerrierAgent>().isDead == false) ||
                    (target.tag == "Defense" &&
                    target.GetComponent<Defense>().isDead == false)))
                {
                    needToMove = false;
                    if (canAttack == true)
                    {
                        isAttacking = true;
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
                    if (Vector2.Distance(newPos, transform.position) <= 0.05f ||
                        Vector2.Distance(transform.position, target.transform.position) <= 1f)
                    {
                        target = FindClosestTarget();
                        if (target != null)
                            newPos = GetComponent<AStar>().StartPathFinding(target.transform.position);
                    }
                    transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime * (speed - slow));
                    if (timer > animTime &&
                    (transform.position.y != newPos.y ||
                    transform.position.x != newPos.x))
                    {
                        if ((!(newPos.x - 0.5f < transform.position.x &&
                            transform.position.x < newPos.x + 0.5f) &&
                             transform.position.x > newPos.x) ||
                             (transform.position.x > newPos.x &&
                             Vector2.Distance(transform.position, newPos) < 0.55f))
                        {
                            GetComponent<SpriteRenderer>().sprite = leftSprites[currentNumeroAnim++];
                        }
                        else if ((!(newPos.x - 0.5f < transform.position.x &&
                            transform.position.x < newPos.x + 0.5f) &&
                             transform.position.x < newPos.x) ||
                                (transform.position.x < newPos.x &&
                                Vector2.Distance(transform.position, newPos) < 0.55f))
                        {
                            GetComponent<SpriteRenderer>().sprite = rightSprites[currentNumeroAnim++];
                        }
                        else if (newPos.y > transform.position.y)
                        {
                            GetComponent<SpriteRenderer>().sprite = topSprites[currentNumeroAnim++];
                        }
                        else if (newPos.y < transform.position.y)
                        {
                            GetComponent<SpriteRenderer>().sprite = botSprites[currentNumeroAnim++];
                        }
                        if (currentNumeroAnim == leftSprites.Length)
                            currentNumeroAnim = 0;
                        timer = 0f;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            TakeDamageFromPlayer(other.GetComponent<Projectile>().damage, other.transform.position);
            other.GetComponent<Projectile>().ExplosionChar();
        }
        else if (other.tag == "IceShard")
        {
            TakeDamageFromPlayer(other.GetComponent<IceShard>().damage, other.transform.position);
            other.GetComponent<IceShard>().ExplosionChar();
        }
        else if (other.tag == "DragonDeFeu" &&
                lastDragonTaken != other.GetComponent<DragonDeFeu>().id)
        {
            TakeDamageFromPlayer(other.GetComponent<DragonDeFeu>().damage, other.transform.position);
            lastDragonTaken = other.GetComponent<DragonDeFeu>().id;
            Physics2D.IgnoreCollision(other.GetComponent<PolygonCollider2D>(), GetComponent<BoxCollider2D>());
        }
        else if (other.tag == "Tornado" &&
                lastTornadoTaken != other.GetComponent<Tornado>().id)
        {
            Fly(other.GetComponent<Tornado>().CCDuration);
            lastTornadoTaken = other.GetComponent<Tornado>().id;
            Physics2D.IgnoreCollision(other.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    public void TakeDamageFromPlayer(int damageTaken, Vector2 damagePos)
    {
        currHP -= damageTaken;
        if (currHP < 0)
            currHP = 0;
        if (isBoss == false)
        {
            float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
            float diff;
            diff = baseScale.x * currHP / maxHP;
            newScale = new Vector2(diff, baseScale.y);
            healthBarGreen.transform.localScale = newScale;

            float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

            float difference = newValue - originalValue;

            healthBarGreen.transform.Translate(new Vector2(difference, 0));
        }
        else
            gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().BossTakeDamage(currHP, maxHP);

        if (currHP <= 0)
        {
            player.GetComponent<StatsPlayer>().EarnXP(valueXP);
            GetComponent<Enemy>().isDead = true;
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<CircleCollider2D>());
            StartCoroutine(DeathAnimation(damagePos));
        }
    }

    public void TakeDamageFromAgent(int damageTaken, Vector2 damagePos, GameObject go)
    {
        currHP -= damageTaken;
        if (currHP < 0)
            currHP = 0;
        if (isBoss == false)
        {
            float originalValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;
            float diff;
            diff = baseScale.x * currHP / maxHP;
            newScale = new Vector2(diff, baseScale.y);
            healthBarGreen.transform.localScale = newScale;

            float newValue = healthBarGreen.GetComponent<SpriteRenderer>().bounds.min.x;

            float difference = newValue - originalValue;

            healthBarGreen.transform.Translate(new Vector2(difference, 0));
        }
        else
            gm.GetComponent<MapManager>().gm.GetComponent<GameManager>().BossTakeDamage(currHP, maxHP);


        if (currHP == 0)
        {
            if (gm.GetComponent<MapManager>().IsEnemyAlreadyDead(GetComponent<Enemy>().id) == false)
            {
                go.GetComponent<IAGuerrierAgent>().EarnXP(valueXP);
                gm.GetComponent<MapManager>().FillDeadList(GetComponent<Enemy>().id);
                GetComponent<Enemy>().isDead = true;
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<CircleCollider2D>());
                StartCoroutine(DeathAnimation(damagePos));
            }
        }
    }

    public void ApplySlow(float duration, float slowValue)
    {
        slow = slowValue;
        isSlowed = true;
        cooldownSlow = duration;
        timerSlow = 0f;
    }

    public void Fly(float duration)
    {
        cooldownFlying = duration;
        canAttack = false;
        isFlying = true;
        ApplyCC(duration);
    }

    public void ApplyCC(float duration)
    {
        canMove = false;
        canAttack = false;
        cooldownCC = duration;
        timerCC = 0f;
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

        gm.GetComponent<MapManager>().PopEnemy(GetComponent<Enemy>().id);
        if (isBoss == true)
            gm.GetComponent<MapManager>().WinGame();
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

        if (target.tag == "Player")
            player.GetComponent<StatsPlayer>().TakeDamage(damage, transform.position);
        else if (target.tag == "AgentGuerrier")
            target.GetComponent<IAGuerrierAgent>().TakeDamage(damage, transform.position);
        else if (target.tag == "Defense")
            target.GetComponent<Defense>().TakeDamage(damage);
        isAttacking = false;
        canAttack = false;
        timer = 0.09f;

        if (rightSide == true)
            GetComponent<SpriteRenderer>().sprite = rightIdle;
        else
            GetComponent<SpriteRenderer>().sprite = leftIdle;
    }

    GameObject FindClosestTarget()
    {
        GameObject obj = null;
        float distanceTarget = 10000;
        float distanceNew;
        bool first = true;

        if (type == EnemyType.Normal)
        {
            foreach (GameObject go in gm.GetComponent<MapManager>().alliesList)
            {
                if (go.gameObject == player.gameObject ||
                    go.GetComponent<IAGuerrierAgent>().isDead == false)
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
        }
        else if (type == EnemyType.Player)
            return (player);
        else if (type == EnemyType.Objectif)
            return (gm.GetComponent<MapManager>().defense);

        return (obj);
    }
}
